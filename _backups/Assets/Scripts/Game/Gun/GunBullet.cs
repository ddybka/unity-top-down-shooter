using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    [Header("Config")]

    [SerializeField] private float speedMove = 18f;

    [SerializeField] private float liveTime = 10f;

    [SerializeField] private float defaultDamage = 1f;

    [Header("Touch")]

    [SerializeField] private float distanceConnect = .5f;

    [SerializeField] private LayerMask layerTouch;

    [Header("Bullet")]

    [SerializeField] private GameObject effectOnTouch;

    private float liveTimeNow;

    private void FixedUpdate()
    {
        if (liveTimeNow >= liveTime) Destroy(gameObject);

        liveTimeNow += 1f * Time.deltaTime;

        transform.Translate(Vector2.up * speedMove * Time.deltaTime);
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distanceConnect, layerTouch);

        if (hit.collider == null) return;

        if(hit.collider.gameObject.CompareTag("Enemy"))
        {
            if(hit.collider.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
            {
                enemy.SetDamage(defaultDamage);
            }
        }

        Destroy(gameObject);
    }

    //
    // Voids
    //

    private void OnDestroy()
    {
        // Debug.Log("Dead");
    }
}
