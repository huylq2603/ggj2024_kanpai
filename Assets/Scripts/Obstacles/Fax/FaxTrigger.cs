using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FaxTrigger : MonoBehaviour
{
    public GameObject paper;

    void Start()
    {
        IEnumerator coroutine = PrintPaper();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PrintPaper()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log(transform);
            GameObject paperClone = Instantiate(paper, transform.parent.transform);
            paperClone.transform.Find("Paper").GetComponent<PaperScript>().InitialVelocity = Vector2.zero;
        }
    }
}
