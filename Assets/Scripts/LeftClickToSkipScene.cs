using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftClickToSkipScene : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.LoadNextScene();
        }
    }
}
