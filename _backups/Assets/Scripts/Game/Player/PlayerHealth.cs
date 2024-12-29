using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthImage;

    [SerializeField] private Image armorImage;

    private float health = 1f;

    private float armor;

    private void Start()
    {
        UpdateInterface();
    }

    public void HealthTakeAway(float healthValue) { HealthDown(healthValue); }

    public void HealthAdd(float healthValue) { HealthUp(healthValue); }

    public void ArmorAdd(float armorValue) { ArmorUp(armorValue); }

    //
    // Voids
    //

    private void HealthUp(float healthValue)
    {
        health += healthValue;

        if (health <= 0.01f) Destroy(gameObject);

        if (health >= 1f) health = 1f;

        UpdateInterface();
    }

    private void HealthDown(float damage)
    {
        if(armor <= 0f)
        {
            health -= damage;
        }
        else
        {
            armor -= damage;
        }

        if(health <= 0.01f) Destroy(gameObject);

        if (health >= 1f) health = 1f;

        UpdateInterface();
    }

    private void ArmorUp(float armorValue)
    {
        armor += armorValue;

        if (armor <= 0f) armor = 0f;

        if (armor >= 1f) armor = 1f;

        UpdateInterface();
    }

    private void UpdateInterface()
    {
        healthImage.fillAmount = health;
        armorImage.fillAmount = armor;
    }
 
    private void OnDestroy()
    {
        Debug.Log("Is Dead");
    }

    //
    // Debug
    //

    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 300, 50), "++ Health"))
        {
            HealthAdd(0.1f);
        }

        if (GUI.Button(new Rect(100, 200, 300, 50), "-- Health"))
        {
            HealthTakeAway(0.1f);
        }

        if (GUI.Button(new Rect(500, 100, 300, 50), "++ Armor"))
        {
            ArmorAdd(0.1f);
        }
    }
}
