using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public float WorldSpeedScale = 1f;
    public float HorizontalSpeed = 0f;
    private float HorizontalSpeedScale = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((Vector3.up * GameManager.WorldSpeed * WorldSpeedScale) + (HorizontalSpeed * HorizontalSpeedScale * Vector3.right));
    }
}
