using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRange : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject otherGameObject = other.gameObject;
        string layer = LayerMask.LayerToName(otherGameObject.layer);

        if (layer.Equals(StaticData.Layer.Player))
        {
            GameObject parent = gameObject.transform.parent.gameObject;
            GameObject trigger = parent.transform.Find("Trigger").gameObject;
            trigger.SetActive(true);
            Debug.Log("Hit " + parent);
            Debug.Log("Hit Player");
        }
    }
}
