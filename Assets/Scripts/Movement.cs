using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int health = 3;
    private bool freezeControl = false;
    public float movementForce;
    public float movementDrag;
    public float dragtolerance = 0;

    public Vector3 delta = Vector3.zero;
    public Vector3 lastPos = Vector3.zero;

    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Debug.Log("Game Over");
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

                r2d.AddRelativeForce(delta.normalized * movementForce);

                // End do stuff

                lastPos = Input.mousePosition;
            }
            if (!Input.GetMouseButton(0) && r2d.velocity.magnitude > 0)
            {
                r2d.drag = 100f;
            }
            else
            {
                r2d.drag = movementDrag;
            }
        }
        //Debug.Log($"Drag: {r2d.drag}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGameObject = other.gameObject;
        string layer = LayerMask.LayerToName(otherGameObject.layer);
        if (layer.Equals(StaticData.Layer.Obstacle))
        {
            health -= 1;
            Debug.Log(health + " health");
            r2d.drag = movementDrag;
            r2d.velocity = Vector2.zero;
            r2d.AddRelativeForce(Vector2.up * 100);
            StartCoroutine(PlayerHit());
        }
    }

    IEnumerator PlayerHit()
    {
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
        freezeControl = false;
    }
}
