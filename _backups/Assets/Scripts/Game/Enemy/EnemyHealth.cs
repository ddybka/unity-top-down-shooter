using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 10f;

    public void SetDamage(float damage)
    {
        TakeAwayHealth(damage);
    }

    //
    // Voids
    //

    private void TakeAwayHealth(float healthAway)
    {
        health -= healthAway;

        Debug.Log(health);

        if(health <= 0) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Dead enemy");
    }
}
