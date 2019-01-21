using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField]
    AudioClip coinPickupSFX;

    [SerializeField]
    int pointsValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D)
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(pointsValue);

            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
        }
    }
}
