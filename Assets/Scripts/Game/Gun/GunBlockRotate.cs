using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunBlockRotate : MonoBehaviour
{
    [SerializeField] private bool useJoystick = false;

    private Controls controls;

    private GunShootBullet gunShoot;

    private float offset = -90;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable() { controls.Enable(); }

    private void OnDisable() { controls.Disable(); }

    private void Start()
    {
        gunShoot = GetComponent<GunShootBullet>();
    }

    private void Update()
    {
        if(gunShoot != null)
        {
            if (gunShoot.NowReloading() == true) return;
        }

        if (Time.timeScale <= 0f) return;

        Vector3 vectorCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector2 joystick = new Vector2(controls.Main.RightMoveX.ReadValue<float>(), controls.Main.RightMoveY.ReadValue<float>());

        Vector2 vector;
        if (useJoystick == false)
        {
            vector = new Vector2(vectorCamera.x, vectorCamera.y);
        }
        else
        {
            vector = new Vector2(joystick.x, joystick.y);
        }

        float rotation = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotation + offset);
    }
}
