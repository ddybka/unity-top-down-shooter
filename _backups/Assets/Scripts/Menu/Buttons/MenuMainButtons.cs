using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainButtons : MonoBehaviour
{
    [Header("Main page")]
    [SerializeField] private GameObject menuPlay;
    [SerializeField] private GameObject menuShop;
    [SerializeField] private GameObject menuSettings;
    [SerializeField] private GameObject menuAuthor;

    private void OnEnable()
    {
        PlayDisable();
        ShopDisable();
        SettingsDisable();
        AuthorDisable();
    }

    public void Play() { See(menuPlay); }

    public void PlayDisable() { Disable(menuPlay); }

    public void Shop() { See(menuShop); }

    public void ShopDisable() { Disable(menuShop); }

    public void Settings() { See(menuSettings); }

    public void SettingsDisable() { Disable(menuSettings); }

    public void Author() { See(menuAuthor); }

    public void AuthorDisable() { Disable(menuAuthor); }

    public void Quit() { Application.Quit(); }

    private void See(GameObject menu)
    {
        if(menu != null) menu.SetActive(true);
    }

    private void Disable(GameObject menu)
    {
        if(menu != null) menu.SetActive(false);
    }
}
