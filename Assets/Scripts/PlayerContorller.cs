using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 3;
    public int drunkLevel = 0;

    private readonly int MaxHealth = 3;

    public List<Sprite> mugSprites;
    SpriteRenderer sr;
    private bool freezeControl = false;
    private bool isInvincible = false;
    public float movementForce;
    public float movementDrag;
    public float dragtolerance = 0;

    public Vector3 delta = Vector3.zero;
    public Vector3 lastPos = Vector3.zero;

    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    public GameObject gameOverObj;
    public GameObject bossArmObj;
    public GameObject mainGuyLongNeckObj;

    public AudioClip ehSound;
    public AudioClip wastedSound;
    AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        sr = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.IsGameOver && health <= 0)
        {
            Debug.Log("Game Over");
            GameManager.IsGameOver = true;
            StartCoroutine(GameOver());
        }

        if (!freezeControl)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                delta = Input.mousePosition - lastPos;
                //           Debug.Log($"X: {delta.x}; Y: {delta.y}");
                //         Debug.Log($"Direction: {delta.normalized}");
                // Do Stuff here

                float dragForce = 1f;
                switch (drunkLevel)
                {
                    case 0:
                        break;
                    case 1:
                        dragForce = 0.8f;
                        break;
                    default:
                        dragForce = 0.5f;
                        break;
                }

                r2d.AddRelativeForce(delta.normalized * movementForce * dragForce);

                // End do stuff

                lastPos = Input.mousePosition;
            }

            if (!Input.GetMouseButton(0) && r2d.velocity.magnitude > 0)
            {
                float dragValue = 100f;

                switch (drunkLevel)
                {
                    case 0:
                        break;
                    case 1:
                        dragValue = 5f;
                        break;
                    case 2:
                        dragValue = 2f;
                        break;
                    case 3:
                        dragValue = 0.5f;
                        break;
                    default:
                        dragValue = 0.2f;
                        break;
                }

                r2d.drag = dragValue;
            }
            else
            {
                r2d.drag = movementDrag;
            }
        }
        //Debug.Log($"Drag: {r2d.drag}");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGameObject = other.gameObject;
        string layer = LayerMask.LayerToName(otherGameObject.layer);
        if (!GameManager.IsGameOver && layer.Equals(StaticData.Layer.EndingGround) && health > 0)
        {
            GameManager.IsGameOver = true;
            StartCoroutine(ClearLevel());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGameObject = other.gameObject;
        Destroy(otherGameObject);
        string layer = LayerMask.LayerToName(otherGameObject.layer);
        if (layer.Equals(StaticData.Layer.Obstacle) && !isInvincible)
        {
            ProcessPlayerHit();
        }
    }

    private void ProcessPlayerHit()
    {
        if (GameManager.IsGameOver) {
            return;
        }
        health -= 1;
        audioSrc.PlayOneShot(ehSound);
        Debug.Log(health + " health");
        sr.sprite = mugSprites[health];
        r2d.drag = movementDrag;
        r2d.velocity = Vector2.zero;
        r2d.AddRelativeForce(Vector2.up * 100);
        StartCoroutine(PlayerHit());
    }

    IEnumerator PlayerHit()
    {
        isInvincible = true;
        freezeControl = true;
        Renderer rd = GetComponent<Renderer>();
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
        freezeControl = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }

    IEnumerator GameOver()
    {
        audioSrc.PlayOneShot(wastedSound);
        freezeControl = true;
        Renderer rd = GetComponent<Renderer>();
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
        GameManager.configWorldSpeed = 0;
        // yield return new WaitForSeconds(1.5f);
        gameOverObj.SetActive(true);
        GameManager.configWorldSpeed = 0.5f;
        yield return new WaitForSeconds(4f);
        GameManager.LoadNextScene(true);
    }

    IEnumerator ClearLevel()
    {
        Debug.Log("Win");
        freezeControl = true;
        r2d.velocity = Vector2.zero;
        bossArmObj.SetActive(true);
        mainGuyLongNeckObj.SetActive(true);
        GameManager.configWorldSpeed = 0;
        yield return new WaitForSeconds(7f);
        GameManager.configWorldSpeed = 0.5f;
        GameManager.LoadNextScene();
    }

    public void AddHealth()
    {
        if (health < MaxHealth)
        {
            health += 1;
            sr.sprite = mugSprites[health];
            drunkLevel += 1;
            Debug.Log($"Health: {health}");
            Debug.Log($"Drunk level: {drunkLevel}");
        }
    }
}
