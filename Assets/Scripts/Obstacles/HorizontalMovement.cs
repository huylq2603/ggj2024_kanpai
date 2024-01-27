using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public Vector2 VectorDirection;
    public float Speed;
    public GameObject Target;

    private float SpeedScale = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Target.transform.Translate(VectorDirection.normalized * (Speed * SpeedScale));
    }
}
