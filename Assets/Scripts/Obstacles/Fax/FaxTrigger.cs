using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaxTrigger : MonoBehaviour
{
    public GameObject paper;

    void Start()
    {
        paper = Instantiate(paper, transform);
        paper.transform.Find("Paper").GetComponent<PaperScript>().InitialVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
