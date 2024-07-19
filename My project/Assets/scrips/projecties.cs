using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject explosionPrefab; // เรียกใช้ Explosion prefab

    void OnCollisionEnter(Collision collision)
    {
        // Check the tag of the object it collided with
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("floor"))
        {
            // Create the explosion effect at the position of the projectile
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            // Remove the projectile
            Destroy(gameObject);
        }
    }
}