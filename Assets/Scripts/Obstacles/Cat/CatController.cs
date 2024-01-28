using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    Rigidbody2D rb;

    private int direction;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!this.enabled)
        {
            return;
        }
        GameObject otherGameObject = other.gameObject;
        string layer = LayerMask.LayerToName(otherGameObject.layer);

        if (layer.Equals(StaticData.Layer.ObstacleWall))
        {
            direction = -direction;
        }

        if (layer.Equals(StaticData.Layer.ObstacleEnvironment))
        {
            rb.velocity = new Vector2(0, 0);
            IEnumerator coroutine = WaitAndJump(Random.Range(0.15f, 0.25f));
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WaitAndJump(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        rb.GetComponent<SpriteRenderer>().flipX = direction < 0;
        rb.AddForce(new Vector3(150 * direction, 150, 0));
    }
}
