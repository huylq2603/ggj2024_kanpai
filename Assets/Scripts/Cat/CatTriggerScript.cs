using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatTriggerScript : MonoBehaviour
{
    public Transform target;
    Rigidbody2D rb;
    GameObject cat;
    
    // Start is called before the first frame update
    void Awake()
    {
        cat = gameObject.transform.parent.transform.Find("Cat").gameObject;
        rb = cat.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        CatController catController = cat.GetComponent<CatController>();
        catController.enabled = false;
        rb.velocity = new Vector2(0, 0);
        Vector3 pointAheadTarget = target.transform.position;
        float distance = Vector2.Distance(pointAheadTarget, cat.transform.position);

        pointAheadTarget.y -= Mathf.Sqrt(distance);

        rb.AddForce(((Vector2)(pointAheadTarget-cat.transform.position)).normalized * 1000);
        cat.GetComponent<CircleCollider2D>().isTrigger = true;
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     GameObject otherGameObject = other.gameObject;
    //     string layer = LayerMask.LayerToName(otherGameObject.layer);

    //     Debug.Log("layer "+layer);
    //     if (layer.Equals(StaticData.Layer.Environment))
    //     {
    //         Debug.Log("called trigger");
    //         rb.AddForce(target.transform.position-gameObject.transform.position);
    //     }
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     // if (Input.GetMouseButtonDown(0))
    //     //     rb.AddForce(new Vector3(100, 100, 0));
    // }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     GameObject otherGameObject = other.gameObject;
    //     string layer = LayerMask.LayerToName(otherGameObject.layer);

    //     if (layer.Equals(StaticData.Layer.Wall))
    //     {
    //         direction = -1;
    //     }

    //     if (layer.Equals(StaticData.Layer.Environment))
    //     {
    //         rb.velocity = new Vector2(0, 0);
    //         IEnumerator coroutine = WaitAndJump(Random.Range(0.25f, 0.5f));
    //         StartCoroutine(coroutine);
    //     }
    // }

    // IEnumerator WaitAndJump(float seconds)
    // {
    //     yield return new WaitForSeconds(seconds);
    //     rb.AddForce(new Vector3(100 * direction, 100, 0));
    // }
}
