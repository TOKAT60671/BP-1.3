using Dtos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManagerScript : MonoBehaviour
{
    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject saves;
    public GameObject Game;

    public void UnLoad()
    {
        registerPanel.SetActive(false);
        loginPanel.SetActive(false);
    }

    public void ToRegister()
    {
        UnLoad();
        Debug.Log("To Register Screen");
        registerPanel.SetActive(true);

    }
    public void ToLogin()
    {
        UnLoad();
        Debug.Log("To Login Screen");
        loginPanel.SetActive(true);
    }
    public void ToSaves()
    {
        UnLoad();
        Debug.Log("To Saves Screen");
        saves.SetActive(true);

    }
    public void ToGame()
    {
        UnLoad();
        Debug.Log("To Game Screen");
    }
}
