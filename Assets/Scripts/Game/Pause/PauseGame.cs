using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private bool see = false;

    private Controls controls;

    private void Awake()
    {
        controls = new Controls();

        controls.Main.PauseActive.performed += context => Active();

        controls.Main.PauseDisable.performed += context => Disable();
    }

    private void OnEnable() { controls.Enable(); }

    private void OnDisable() { controls.Disable(); }


    private void Start()
    {
        Disable();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TurnMenu();
        }
    }

    public void TurnMenu()
    {
        see = !see;
        SetMenu(see);
    }

    public void Active()
    {
        SetMenu(true);
    }

    public void Disable()
    {
        SetMenu(false);
    }

    private void SetMenu(bool active)
    {
        menu.SetActive(active);
        Time.timeScale = active ? 0f : 1f;
    }
}
