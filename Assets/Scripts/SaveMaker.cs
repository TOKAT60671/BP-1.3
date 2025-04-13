using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class SaveMaker : MonoBehaviour
{
    public GameObject NewSave1;
    public GameObject NewSave2;
    public GameObject NewSave3;
    public GameObject NewSave4;
    public GameObject NewSave5;

    public GameObject SaveMaker1;
    public GameObject SaveMaker2;
    public GameObject SaveMaker3;
    public GameObject SaveMaker4;
    public GameObject SaveMaker5;

    public GameObject Save1;
    public GameObject Save2;
    public GameObject Save3;
    public GameObject Save4;
    public GameObject Save5;

    public TMP_InputField NameField1;
    public TMP_InputField NameField2;
    public TMP_InputField NameField3;
    public TMP_InputField NameField4;
    public TMP_InputField NameField5;

    public TMP_Text SaveName1;
    public TMP_Text SaveName2;
    public TMP_Text SaveName3;
    public TMP_Text SaveName4;
    public TMP_Text SaveName5;

    public string saveName1;
    public string saveName2;
    public string saveName3;
    public string saveName4;
    public string saveName5;

    public void NewSave(int newSaveIndex)
    {
        switch (newSaveIndex)
        {
            case 1:
                //new save 1 button pressed
                NewSave1.gameObject.SetActive(false);
                SaveMaker1.gameObject.SetActive(true);
                break;
            case 2:
                //new save 2 button pressed
                NewSave2.gameObject.SetActive(false);
                SaveMaker2.gameObject.SetActive(true);
                break;
            case 3:
                //new save 3 button pressed
                NewSave3.gameObject.SetActive(false);
                SaveMaker3.gameObject.SetActive(true);
                break;
            case 4:
                //new save 4 button pressed
                NewSave4.gameObject.SetActive(false);
                SaveMaker4.gameObject.SetActive(true);
                break;
            case 5:
                //new save 5 button pressed
                NewSave5.gameObject.SetActive(false);
                SaveMaker5.gameObject.SetActive(true);
                break;
        }
    }
    public void ConfirmSave(int confirmSaveIndex)
    {
        switch (confirmSaveIndex)
        {
            case 1:
                //new save 1 confirmed
                SaveMaker1.gameObject.SetActive(false);
                Save1.gameObject.SetActive(true);
                saveName1 = NameField1.text;
                SaveName1.text = saveName1;
                break;

            case 2:
                //new save 2 confirmed
                SaveMaker2.gameObject.SetActive(false);
                Save2.gameObject.SetActive(true);
                saveName2 = NameField2.text;
                SaveName2.text = saveName2;
                break;

            case 3:
                //new save 3 confirmed
                SaveMaker3.gameObject.SetActive(false);
                Save3.gameObject.SetActive(true);
                saveName3 = NameField3.text;
                SaveName3.text = saveName3;
                break;

            case 4:
                //new save 4 confirmed
                SaveMaker4.gameObject.SetActive(false);
                Save4.gameObject.SetActive(true);
                saveName4 = NameField4.text;
                SaveName4.text = saveName4;
                break;

            case 5:
                //new save 5 confirmed
                SaveMaker5.gameObject.SetActive(false);
                Save5.gameObject.SetActive(true);
                saveName5 = NameField5.text;
                SaveName5.text = saveName5;
                break;
        }
    }

    public void ReturnToSaveMenu(int returnToSaveMenuIndex)
    {
        switch (returnToSaveMenuIndex)
        {
            case 1:
                //return to save menu from new save 1
                SaveMaker1.gameObject.SetActive(false);
                NewSave1.gameObject.SetActive(true);
                break;
            case 2:
                //return to save menu from new save 2
                SaveMaker2.gameObject.SetActive(false);
                NewSave2.gameObject.SetActive(true);
                break;
            case 3:
                //return to save menu from new save 3
                SaveMaker3.gameObject.SetActive(false);
                NewSave3.gameObject.SetActive(true);
                break;
            case 4:
                //return to save menu from new save 4
                SaveMaker4.gameObject.SetActive(false);
                NewSave4.gameObject.SetActive(true);
                break;
            case 5:
                //return to save menu from new save 5
                SaveMaker5.gameObject.SetActive(false);
                NewSave5.gameObject.SetActive(true);
                break;
        }
    }
    public void DeleteSave(int deleteSaveIndex)
    {
        switch (deleteSaveIndex)
        {
            case 1:
                //delete save 1
                Save1.gameObject.SetActive(false);
                NewSave1.gameObject.SetActive(true);
                saveName1 = null;
                break;
            case 2:
                //delete save 2
                Save2.gameObject.SetActive(false);
                NewSave2.gameObject.SetActive(true);
                saveName2 = null;
                break;
            case 3:
                //delete save 3
                Save3.gameObject.SetActive(false);
                NewSave3.gameObject.SetActive(true);
                saveName3 = null;
                break;
            case 4:
                //delete save 4
                Save4.gameObject.SetActive(false);
                NewSave4.gameObject.SetActive(true);
                saveName4 = null;
                break;
            case 5:
                //delete save 5
                Save5.gameObject.SetActive(false);
                NewSave5.gameObject.SetActive(true);
                saveName5 = null;
                break;
        }
    }

    public void LoadSave(int loadSaveIndex)
    {

    }
}

