using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanpaiController : MonoBehaviour
{
    public float smallScale;
    public float bigScale;
    public AudioClip kanpaiSound;
    AudioSource audioSrc;
    // Start is called before the first frame update
    private void Awake() {
        audioSrc = GetComponent<AudioSource>();
    }
    void Start()
    {
        StartCoroutine(Pulsing());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(StartNextScene());
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
    IEnumerator StartNextScene()
    {
        audioSrc.PlayOneShot(kanpaiSound);
        yield return new WaitForSeconds(1f);
        GameManager.LoadNextScene();
    }
}
