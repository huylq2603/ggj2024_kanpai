using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public List<GameObject> frames;
    int currentFrame = 0;

    public AudioClip naniSound;
    
    AudioSource audioSrc;

    private void Awake() {
        audioSrc = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentFrame < frames.Count - 1)
            {
                frames[currentFrame].SetActive(false);
                frames[++currentFrame].SetActive(true);
                if (currentFrame == 2) {
                    audioSrc.PlayOneShot(naniSound);
                }
            } else {
                GameManager.LoadNextScene();
            }
        }
    }
}
