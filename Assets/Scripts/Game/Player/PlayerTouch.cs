using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerTouch : MonoBehaviour
{
    private PlayerHealth health;

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Pickup_Health"))
        {
            health.HealthAdd(.2f);
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("Pickup_Armor"))
        {
            health.ArmorAdd(.2f);
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.CompareTag("Pickup_Cartridges_Pistol"))
        {
            // Add to pistol

            Destroy(collider.gameObject);
        }
    }
}
