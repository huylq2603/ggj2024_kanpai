using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopierTrigger : MonoBehaviour
{
    GameObject copier;
    public GameObject paper;
    // Start is called before the first frame update
    void Awake()
    {
        copier = transform.parent.Find("Copier").gameObject;
    }

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(paper, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
