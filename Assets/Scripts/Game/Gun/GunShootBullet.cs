using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class GunShootBullet : MonoBehaviour
{
    [Header("Bullet")]

    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject effectSpawn;

    [Header("Config")]

    [SerializeField] private float timeReload = 3f;

    [SerializeField] private float timeAfterShoot = .05f;

    [Header("Count bullets")]

    [SerializeField] private int countBulletInArmory = 7;

    [SerializeField] private int countAllBullets = 21;

    private int countBulletNow;

    private bool canshoot = true;

    private bool reload = false;

    private Controls controls;

    private void Awake()
    {
        controls = new Controls();

        controls.Main.Reload.performed += context => ReloadGun();

        controls.Main.Shoot.performed += context => ShootGun();
    }

    private void OnEnable() { controls.Enable(); }

    private void OnDisable() { controls.Disable(); }

    private void Start()
    {
        countBulletNow = countBulletInArmory;
    }

    private void Update()
    {
        if (reload == true) return;

        if(Input.GetMouseButton(0))
        {
            ShootGun();
        }

        if(countBulletNow <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            ReloadGun();
        } 
    }

    public bool EmptyArmory() { return countBulletNow <= 0; }

    public bool FullArmory() { return countBulletNow >= countBulletInArmory; }

    public bool NowReloading() { return reload; }

    public bool AllArmoryEmpty() { return countBulletNow == 0 && countAllBullets == 0; }

    public bool CanChangeWeapon() { return reload == false && canshoot == true; }

    public void ReloadGun() 
    {
        if (countAllBullets > 0 && reload == false && FullArmory() == false && Time.timeScale > 0f)
        {
            StartCoroutine(Reload());
        }
    }

    public void ShootGun()
    {
        if(canshoot == true && countBulletNow > 0 && Time.timeScale > 0f)
        {
            StartCoroutine(Shoot());
        }
    }

    //
    // Coroutines
    //

    private IEnumerator Shoot()
    {
        canshoot = false;

        SpawnBullet();
        countBulletNow -= 1;

        yield return new WaitForSeconds(timeAfterShoot);

        canshoot = true;

        yield return false;
    }

    private IEnumerator Reload()
    {
        canshoot = false;
        reload = true;

        yield return new WaitForSeconds(timeReload);

        if(countAllBullets > countBulletInArmory)
        {
            if(countBulletNow == 0)
            {
                countBulletNow = countBulletInArmory;
                countAllBullets -= countBulletInArmory;
            }
            else
            {
                int diff = countBulletInArmory - countBulletNow;
                countBulletNow = countBulletInArmory;
                countAllBullets -= diff;
            }
        }
        else if(countAllBullets == countBulletInArmory)
        {
            if(countBulletNow == 0)
            {
                countBulletNow = countBulletInArmory;
                countAllBullets -= countBulletInArmory;
            }
            else
            {
                int diff = countBulletInArmory - countBulletNow;
                countAllBullets -= diff;
                countBulletNow = countBulletInArmory;
            }
        }
        else
        {
            if(countBulletNow == 0)
            {
                countBulletNow = countAllBullets;
                countAllBullets = 0;
            }
            else
            {
                int sum = countBulletNow + countAllBullets;

                if(sum >= countBulletInArmory)
                {
                    int diff = countBulletInArmory - countBulletNow;
                    countBulletNow = countBulletInArmory;

                    countAllBullets -= diff;
                }
                else
                {
                    countBulletNow += countAllBullets;
                    countAllBullets = 0;
                }
            }
        }

        canshoot = true;
        reload = false;

        yield return false;
    }

    //
    // Voids
    //

    private void SpawnBullet()
    {
        Instantiate(bullet, spawnPoint.position, transform.rotation);
    }
}
