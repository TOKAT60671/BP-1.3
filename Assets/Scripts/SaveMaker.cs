using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using API;
using Dtos;
using System;
using System.Threading.Tasks;
using UnityEditor.Overlays;

public class SaveMaker : MonoBehaviour
{
    public GameObject NewSave1, NewSave2, NewSave3, NewSave4, NewSave5;
    public GameObject SaveMaker1, SaveMaker2, SaveMaker3, SaveMaker4, SaveMaker5;
    public GameObject Save1, Save2, Save3, Save4, Save5;
    public TMP_InputField NameField1, NameField2, NameField3, NameField4, NameField5;
    public TMP_Text SaveName1, SaveName2, SaveName3, SaveName4, SaveName5;

    public string saveName1, saveName2, saveName3, saveName4, saveName5;


    private Guid? saveId1, saveId2, saveId3, saveId4, saveId5;

    private string accessToken => ApiClient.Token;

    public void NewSave(int newSaveIndex)
    {
        switch (newSaveIndex)
        {
            case 1: NewSave1.SetActive(false); SaveMaker1.SetActive(true); break;
            case 2: NewSave2.SetActive(false); SaveMaker2.SetActive(true); break;
            case 3: NewSave3.SetActive(false); SaveMaker3.SetActive(true); break;
            case 4: NewSave4.SetActive(false); SaveMaker4.SetActive(true); break;
            case 5: NewSave5.SetActive(false); SaveMaker5.SetActive(true); break;
        }
    }

    public async void ConfirmSave(int confirmSaveIndex)
    {
        switch (confirmSaveIndex)
        {
            case 1:
                SaveMaker1.SetActive(false); Save1.SetActive(true);
                saveName1 = NameField1.text; SaveName1.text = saveName1;
                saveId1 = await CreateSaveOnApi(saveName1);
                break;
            case 2:
                SaveMaker2.SetActive(false); Save2.SetActive(true);
                saveName2 = NameField2.text; SaveName2.text = saveName2;
                saveId2 = await CreateSaveOnApi(saveName2);
                break;
            case 3:
                SaveMaker3.SetActive(false); Save3.SetActive(true);
                saveName3 = NameField3.text; SaveName3.text = saveName3;
                saveId3 = await CreateSaveOnApi(saveName3);
                break;
            case 4:
                SaveMaker4.SetActive(false); Save4.SetActive(true);
                saveName4 = NameField4.text; SaveName4.text = saveName4;
                saveId4 = await CreateSaveOnApi(saveName4);
                break;
            case 5:
                SaveMaker5.SetActive(false); Save5.SetActive(true);
                saveName5 = NameField5.text; SaveName5.text = saveName5;
                saveId5 = await CreateSaveOnApi(saveName5);
                break;
        }
    }

    private async Task<Guid?> CreateSaveOnApi(string saveName)
    {
        try
        {
            await ApiHelper.NewSave(saveName);
            string savesJson = await ApiHelper.GetSaves();
            Debug.Log("Saves JSON: " + savesJson);

            if (string.IsNullOrWhiteSpace(savesJson) || !savesJson.TrimStart().StartsWith("["))
            {
                Debug.LogError("Saves JSON is null, empty, or not an array.");
                return null;
            }

            SaveDto[] saves = null;
            try
            {
                saves = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveDto[]>(savesJson);
            }
            catch (Exception ex)
            {
                Debug.LogError("Deserialization failed: " + ex.Message);
                return null;
            }

            if (saves != null)
            {
                foreach (var save in saves)
                {
                    if (save != null && save.Name == saveName)
                        return save.Id;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to create save: " + ex.Message);
        }
        return null;
    }

    public void ReturnToSaveMenu(int returnToSaveMenuIndex)
    {
        switch (returnToSaveMenuIndex)
        {
            case 1: SaveMaker1.SetActive(false); NewSave1.SetActive(true); break;
            case 2: SaveMaker2.SetActive(false); NewSave2.SetActive(true); break;
            case 3: SaveMaker3.SetActive(false); NewSave3.SetActive(true); break;
            case 4: SaveMaker4.SetActive(false); NewSave4.SetActive(true); break;
            case 5: SaveMaker5.SetActive(false); NewSave5.SetActive(true); break;
        }
    }

    public async void DeleteSave(int deleteSaveIndex)
    {
        Guid? saveId = null;
        switch (deleteSaveIndex)
        {
            case 1:
                saveId = saveId1; Save1.SetActive(false); NewSave1.SetActive(true); saveName1 = null; saveId1 = null; break;
            case 2:
                saveId = saveId2; Save2.SetActive(false); NewSave2.SetActive(true); saveName2 = null; saveId2 = null; break;
            case 3:
                saveId = saveId3; Save3.SetActive(false); NewSave3.SetActive(true); saveName3 = null; saveId3 = null; break;
            case 4:
                saveId = saveId4; Save4.SetActive(false); NewSave4.SetActive(true); saveName4 = null; saveId4 = null; break;
            case 5:
                saveId = saveId5; Save5.SetActive(false); NewSave5.SetActive(true); saveName5 = null; saveId5 = null; break;
        }
        if (saveId.HasValue)
        {
            try
            {
                await ApiHelper.DeleteSave(saveId.Value);
            }
            catch (Exception ex)
            {
                Debug.LogError("Failed to delete save: " + ex.Message);
            }
        }
    }

    public async void LoadSave(int loadSaveIndex)
    {
        Guid? saveId = null;
        switch (loadSaveIndex)
        {
            case 1: saveId = saveId1; break;
            case 2: saveId = saveId2; break;
            case 3: saveId = saveId3; break;
            case 4: saveId = saveId4; break;
            case 5: saveId = saveId5; break;
        }
        if (saveId.HasValue)
        {
            try
            {
                string saveJson = await ApiHelper.GetSave(saveId.Value);
                Debug.Log("Loaded save: " + saveJson);
                // TODO: Pass this data to your ObjectManager or other systems
            }
            catch (Exception ex)
            {
                Debug.LogError("Failed to load save: " + ex.Message);
            }
        }
    }

}

