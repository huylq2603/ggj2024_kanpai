using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGuyLongNeckEndgameScript : MonoBehaviour
{
    public GameObject playerBeerMugPos;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
        destination.y = playerBeerMugPos.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, 5*Time.deltaTime);
    }
}
