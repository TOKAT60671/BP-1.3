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
using System.Linq;

public class SaveMaker : MonoBehaviour
{
    public GameObject NewSave1, NewSave2, NewSave3, NewSave4, NewSave5;
    public GameObject SaveMaker1, SaveMaker2, SaveMaker3, SaveMaker4, SaveMaker5;
    public GameObject Save1, Save2, Save3, Save4, Save5;
    public TMP_InputField NameField1, NameField2, NameField3, NameField4, NameField5;
    public TMP_Text SaveName1, SaveName2, SaveName3, SaveName4, SaveName5;

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
        Debug.Log("Confirming save for slot: " + confirmSaveIndex);
        string newSaveName = confirmSaveIndex switch
        {
            1 => NameField1.text,
            2 => NameField2.text,
            3 => NameField3.text,
            4 => NameField4.text,
            5 => NameField5.text,
            _ => ""
        };

        if (!CheckSaveName(newSaveName))
        {
            Debug.LogWarning("Save name must be between 1 and 25 characters.");
            return;
        }

        try
        {
            await ApiHelper.NewSave(newSaveName, confirmSaveIndex - 1);
            await RefreshSavesUI();
            SetSaveMakerActive(confirmSaveIndex, false);
            SetSaveActive(confirmSaveIndex, true);
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to create save: " + ex.Message);
        }
    }

    public async Task RefreshSavesUI()
    {
        try
        {
            Debug.Log("Refreshing saves UI...");
            string savesJson = await ApiHelper.GetSaves();
            SaveDto[] saves = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveDto[]>(savesJson) ?? new SaveDto[0];

            // Reset all slots to "new save" state
            SetAllSlotsToNew();

            foreach (var save in saves)
            {
                switch (save.Slot)
                {
                    case 0: NewSave1.SetActive(false); Save1.SetActive(true); SaveName1.text = save.Name; break;
                    case 1: NewSave2.SetActive(false); Save2.SetActive(true); SaveName2.text = save.Name; break;
                    case 2: NewSave3.SetActive(false); Save3.SetActive(true); SaveName3.text = save.Name; break;
                    case 3: NewSave4.SetActive(false); Save4.SetActive(true); SaveName4.text = save.Name; break;
                    case 4: NewSave5.SetActive(false); Save5.SetActive(true); SaveName5.text = save.Name; break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to refresh saves: " + ex.Message);
        }
    }

    public void ReturnToSaveMenu(int returnToSaveMenuIndex)
    {
        SetSaveMakerActive(returnToSaveMenuIndex, false);
        SetNewSaveActive(returnToSaveMenuIndex, true);
    }

    public async void DeleteSave(int deleteSaveIndex)
    {
        try
        {
            Debug.Log("Deleting save for slot: " + deleteSaveIndex);
            var savesJson = await ApiHelper.GetSaves();
            var saves = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveDto[]>(savesJson);
            var save = saves?.FirstOrDefault(s => s.Slot == deleteSaveIndex - 1);
            if (save != null)
            {
                await ApiHelper.DeleteSave(save.Id);
            }
            await RefreshSavesUI();
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to delete save: " + ex.Message);
        }
    }

    public async void LoadSave(int loadSaveIndex)
    {
        Debug.Log("Loading save for slot: " + loadSaveIndex);   
        try
        {
            var savesJson = await ApiHelper.GetSaves();
            var saves = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveDto[]>(savesJson);
            var save = saves?.FirstOrDefault(s => s.Slot == loadSaveIndex - 1);
            if (save != null)
            {
                string saveJson = await ApiHelper.GetSave(save.Id);
                Debug.Log("Loaded save: " + saveJson);

                var objectManager = FindFirstObjectByType<ObjectManager>();
                var screenManager = FindFirstObjectByType<ScreenManagerScript>();
                if (screenManager != null)
                {
                    objectManager.currentSaveId = save.Id;
                    screenManager.ToGame(); // Activate the Game UI first!
                }
                else
                {
                    Debug.LogWarning("ScreenManagerScript not found in scene.");
                }

                if (objectManager != null)
                {
                    Debug.Log("Loading objects into ObjectManager...");
                    objectManager.LoadFromJson(saveJson);
                }
                else
                {
                    Debug.LogWarning("ObjectManager not found in scene.");
                }

            }
            else
            {
                Debug.LogWarning($"No save found for slot {loadSaveIndex}");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to load save: " + ex.Message);
        }
    }

    // --- Helper Methods ---

    private void SetAllSlotsToNew()
    {
        NewSave1.SetActive(true); Save1.SetActive(false); SaveName1.text = "";
        NewSave2.SetActive(true); Save2.SetActive(false); SaveName2.text = "";
        NewSave3.SetActive(true); Save3.SetActive(false); SaveName3.text = "";
        NewSave4.SetActive(true); Save4.SetActive(false); SaveName4.text = "";
        NewSave5.SetActive(true); Save5.SetActive(false); SaveName5.text = "";
    }

    private void SetSaveMakerActive(int index, bool active)
    {
        switch (index)
        {
            case 1: SaveMaker1.SetActive(active); break;
            case 2: SaveMaker2.SetActive(active); break;
            case 3: SaveMaker3.SetActive(active); break;
            case 4: SaveMaker4.SetActive(active); break;
            case 5: SaveMaker5.SetActive(active); break;
        }
    }

    private void SetSaveActive(int index, bool active)
    {
        switch (index)
        {
            case 1: Save1.SetActive(active); break;
            case 2: Save2.SetActive(active); break;
            case 3: Save3.SetActive(active); break;
            case 4: Save4.SetActive(active); break;
            case 5: Save5.SetActive(active); break;
        }
    }

    private void SetNewSaveActive(int index, bool active)
    {
        switch (index)
        {
            case 1: NewSave1.SetActive(active); break;
            case 2: NewSave2.SetActive(active); break;
            case 3: NewSave3.SetActive(active); break;
            case 4: NewSave4.SetActive(active); break;
            case 5: NewSave5.SetActive(active); break;
        }
    }

    public static bool CheckSaveName(string saveName)
    {
        return !string.IsNullOrWhiteSpace(saveName) && saveName.Length >= 1 && saveName.Length <= 25;
    }
}

