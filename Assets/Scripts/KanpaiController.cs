using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanpaiController : MonoBehaviour
{
    public float smallScale;
    public float bigScale;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Pulsing());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.LoadNextScene();
        }
    }

    IEnumerator Pulsing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            transform.localScale = new Vector3(bigScale, bigScale, 0);
            yield return new WaitForSeconds(0.1f);
            transform.localScale = new Vector3(smallScale, smallScale, 0);
        };
    }
}
