using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerRefill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGameObject = other.gameObject;
        string layer = LayerMask.LayerToName(otherGameObject.layer);
        if (layer.Equals(StaticData.Layer.Player))
        {
            var playerController = otherGameObject.GetComponent<PlayerController>();
            playerController.AddHealth();

            transform.parent.gameObject.SetActive(false);
        }
    }
}
