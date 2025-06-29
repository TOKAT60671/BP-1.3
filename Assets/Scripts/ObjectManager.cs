using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Dtos;
using API;

public class ObjectManager : MonoBehaviour
{
    public GameObject UISideMenu;
    public List<GameObject> prefabObjects;

    private List<GameObject> placedObjects;

    private void Awake()
    {
        placedObjects = new List<GameObject>();
    }

    /// <summary>
    /// Place a new 2D object in the world and start dragging it.
    /// </summary>
    public void PlaceObjectButton(int typeObjectIndex)
    {
        Vector2 spawnPosition = Vector2.zero;
        PlaceNewObject2D(typeObjectIndex, spawnPosition);
    }
    public void PlaceNewObject2D(int typeObjectIndex, Vector2? location = null, bool isDragging = true)
    {
        UISideMenu.SetActive(false);
        Vector2 spawnPosition = location ?? Vector2.zero;
        GameObject instanceOfPrefab = Instantiate(prefabObjects[typeObjectIndex], spawnPosition, Quaternion.identity);
        Object2D object2D = instanceOfPrefab.GetComponent<Object2D>();
        object2D.objectManager = this;
        object2D.isDragging = isDragging;
        object2D.id = Guid.NewGuid();
        object2D.typeIndex = typeObjectIndex;
        placedObjects.Add(instanceOfPrefab);
    }

    /// <summary>
    /// Get all placed objects as GObjectDto for saving.
    /// </summary>
    public List<GObjectDto> GetAllGObjectDtos(Guid saveGameId)
    {
        var dtos = new List<GObjectDto>();
        foreach (var obj in placedObjects)
        {
            var object2D = obj.GetComponent<Object2D>();
            if (object2D != null)
            {
                dtos.Add(new GObjectDto
                {
                    Id = object2D.id,
                    TypeIndex = object2D.typeIndex,
                    PositionX = obj.transform.position.x,
                    PositionY = obj.transform.position.y,
                    SaveGameId = saveGameId
                });
            }
        }
        return dtos;
    }

    /// <summary>
    /// Save all placed objects to the API for the given saveGameId.
    /// </summary>

    public Guid currentSaveId;
    public void Savebutton()
    { SaveAllObjectsToApi(currentSaveId); }

    //public void Resetbutton()
    //{
        //SaveMaker.LoadSave(currentSaveId);
    //}

    public async void SaveAllObjectsToApi(Guid saveGameId)
    {
        var dtos = GetAllGObjectDtos(saveGameId);
        Debug.Log($"Saving {dtos.Count} objects to API for saveGameId: {saveGameId}");
        await ApiHelper.SaveObjects(saveGameId, dtos.ToArray());

        // Go back to saves screen
        var screenManager = FindFirstObjectByType<ScreenManagerScript>();
        if (screenManager != null)
        {
            screenManager.ToSaves();
        }
        else
        {
            Debug.LogWarning("ScreenManagerScript not found in scene.");
        }
    }

    /// <summary>
    /// Load all objects from a JSON string (as returned by the API).
    /// </summary>
    public void LoadFromJson(string saveJson)
    {
        List<GObjectDto> objects = null;
        try
        {
            var wrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveWithObjectsWrapper>(saveJson);
            if (wrapper != null && wrapper.objects != null)
                objects = wrapper.objects;
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to parse save JSON: " + ex.Message);
        }

        if (objects == null)
        {
            Debug.LogWarning("No objects found in save data.");
            return;
        }

        foreach (var dto in objects)
        {
            PlaceNewObject2D(dto.TypeIndex, new Vector2(dto.PositionX, dto.PositionY), false);
            Debug.Log($"Placing object {dto.Id} at ({dto.PositionX}, {dto.PositionY}) of type {dto.TypeIndex}");
        }
        Debug.Log($"Loaded {objects.Count} objects from save data.");
        UISideMenu.SetActive(true);

    }

    public void ClearAllObjects()
    {
        foreach (var obj in placedObjects)
        {
            Destroy(obj);
        }
        placedObjects.Clear();
    }

    public void ShowMenu()
    {
        UISideMenu.SetActive(true);
    }

    [Serializable]
    private class SaveWithObjectsWrapper
    {
        public string id;
        public string name;
        public List<GObjectDto> objects;

    }
}