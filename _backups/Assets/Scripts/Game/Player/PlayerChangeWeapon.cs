using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChangeWeapon : MonoBehaviour
{
    [SerializeField] private int countWeapon = 3;

    [SerializeField] private GameObject[] weapons;

    [SerializeField] private int numberActiveWeapon = 0;

    private Controls controls;

    private void Awake()
    {
        controls = new Controls();

        controls.Main.NextWeapon.performed += context => NextWeapon();

        controls.Main.PreviousWeapon.performed += context => PreviousWeapon();
    }

    private void OnEnable() { controls.Enable(); }

    private void OnDisable() { controls.Disable(); }

    private void Start()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            var weapon = weapons[i];

            weapon.SetActive(i == numberActiveWeapon);
        }
    }

    public void NextWeapon()
    {
        int id = numberActiveWeapon;
        id += 1;

        if (id >= countWeapon) id = 0;

        ChangeWeapon(id);
    }

    public void PreviousWeapon()
    {
        int id = numberActiveWeapon;
        id -= 1;

        if(id < 0)
        {
            id = countWeapon;
            id -= 1;
        }

        ChangeWeapon(id);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChangeWeapon(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChangeWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChangeWeapon(2);
        }
    }

    //
    // Voids
    //

    private void ChangeWeapon(int numberWeapon)
    {
        if (weapons[numberActiveWeapon].TryGetComponent<GunShootBullet>(out GunShootBullet gun))
        {
            if (gun.CanChangeWeapon())
            {
                SetActiveCurrentWeapon(false);

                numberActiveWeapon = numberWeapon;

                SetActiveCurrentWeapon(true);
            }
        }
    }

    private void SetActiveCurrentWeapon(bool active)
    {
        if (weapons.Length > numberActiveWeapon)
        {
            weapons[numberActiveWeapon].SetActive(active);
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
