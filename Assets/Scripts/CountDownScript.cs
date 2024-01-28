using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownScript : MonoBehaviour
{
    public List<GameObject> numbers;
    void Start()
    {
        GameManager.configWorldSpeed = 0f;
        StartCoroutine(CountDownCoroutine());
    }

    IEnumerator CountDownCoroutine(){
        yield return new WaitForSeconds(1f);
        numbers[0].SetActive(false);
        numbers[1].SetActive(true);
        yield return new WaitForSeconds(1f);
        numbers[1].SetActive(false);
        numbers[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        GameManager.configWorldSpeed = 0.5f;
    }
}
