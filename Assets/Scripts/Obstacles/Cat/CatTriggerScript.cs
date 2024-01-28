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
        float distance = Vector2.Distance(target.transform.position, cat.transform.position);

        Vector2 direction = ((Vector2)(target.transform.position-cat.transform.position)).normalized;
        rb.GetComponent<SpriteRenderer>().flipX = direction.x < 0;
        rb.AddForce(direction * distance * 100);
        cat.GetComponent<CircleCollider2D>().isTrigger = true;
    }

}
