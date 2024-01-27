using System.Collections;
using UnityEngine;

public class FaxTrigger : MonoBehaviour
{
    public GameObject Paper;
    private GameObject Fax;

    void Start()
    {
        Fax = transform.parent.Find("Fax").gameObject;

        IEnumerator coroutine = PrintPaper();
        StartCoroutine(coroutine);
    }

    IEnumerator PrintPaper()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject paperClone = Instantiate(Paper, Fax.transform);

            paperClone.transform.Find("Paper").GetComponent<PaperScript>().InitialVelocity = Vector2.zero;
        }
    }
}
