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

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        //     rb.AddForce(new Vector3(100, 100, 0));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject otherGameObject = other.gameObject;
        string layer = LayerMask.LayerToName(otherGameObject.layer);

        if (layer.Equals(StaticData.Layer.Wall))
        {
            direction = -1;
        }

        if (layer.Equals(StaticData.Layer.Environment))
        {
            rb.velocity = new Vector2(0, 0);
            IEnumerator coroutine = WaitAndJump(Random.Range(0.25f, 0.5f));
            StartCoroutine(coroutine);
        }
    }

    IEnumerator WaitAndJump(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        rb.AddForce(new Vector3(100 * direction, 100, 0));
    }
}
