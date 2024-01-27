using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    public Vector2? InitialVelocity;

    private float InitialVelocityMagnitude = 500f;

    private Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        InitialVelocity ??= new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)) * InitialVelocityMagnitude;

        r2d.AddForce(InitialVelocity.Value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
