using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArmEndgameScript : MonoBehaviour
{
    public GameObject playerBeerMugPos;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        destination = playerBeerMugPos.transform.position;
        destination.y -= 4.5f;
        destination.x -= 1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, 5*Time.deltaTime);
    }
}
