using Dtos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using API;

public class ScreenManagerScript : MonoBehaviour
{
    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject saves;
    public GameObject Game;
    public SaveMaker saveMaker;

    public void UnLoad()
    {
        registerPanel.SetActive(false);
        loginPanel.SetActive(false);
        saves.SetActive(false);
        Game.SetActive(false);
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
    public async void ToSaves()
    {
        UnLoad();
        Debug.Log("To Saves Screen");
        if (saveMaker != null)
        {
            await saveMaker.RefreshSavesUI();
        }
        else
        {
            Debug.LogWarning("SaveMaker is not assigned in ScreenManagerScript.");
        }
        saves.SetActive(true);
    }
    public void ToGame()
    {
        UnLoad();
        Debug.Log("To Game Screen");
    }
}
