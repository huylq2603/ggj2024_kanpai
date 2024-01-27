using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
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

        //Debug.Log($"Drag: {r2d.drag}");
    }
}
