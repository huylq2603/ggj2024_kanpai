using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    private GameObject Snake;
    private GameObject SnakeOpen;
    // Start is called before the first frame update

    void Awake()
    {
        Snake = transform.parent.Find("Snake").gameObject;
        SnakeOpen = transform.parent.Find("SnakeOpen").gameObject;
    }
    void Start()
    {
        Snake.SetActive(false);
        SnakeOpen.SetActive(true);
    }
}
