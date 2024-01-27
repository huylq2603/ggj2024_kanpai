using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public int health = 3;

    private void Update() {
        if (health <= 0) {
            Debug.Log("GameOver");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGameObject = other.gameObject;
        string layer = LayerMask.LayerToName(otherGameObject.layer);
        if (layer.Equals(StaticData.Layer.Obstacle))
        {
            health -= 3;
            StartCoroutine(PlayerHit());
        }
    }

    IEnumerator PlayerHit()
    {
        Renderer rd = GetComponent<Renderer>();
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = false;
        yield return new WaitForSeconds(0.1f);
        rd.enabled = true;
    }
}
