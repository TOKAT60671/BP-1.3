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

    // Plaats een nieuw 2D object in de wereld
    public void PlaceNewObject2D(int typeObjectIndex)
    {
        UISideMenu.SetActive(false);
        GameObject instanceOfPrefab = Instantiate(prefabObjects[typeObjectIndex], Vector2.zero, Quaternion.identity);
        Object2D object2D = instanceOfPrefab.GetComponent<Object2D>();
        object2D.objectManager = this;
        object2D.isDragging = true;
        object2D.id = Guid.NewGuid(); // Zorg dat elk object een unieke id krijgt
        object2D.typeIndex = typeObjectIndex;
        placedObjects.Add(instanceOfPrefab);
    }

    // Haal alle geplaatste objecten op als GObjectDto's
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

    public async void SaveAllObjectsToApi(Guid saveGameId)
    {
        var dtos = GetAllGObjectDtos(saveGameId);
        await API.ApiHelper.SaveObjects(saveGameId, dtos.ToArray());
    }
    public async void LoadObjectsFromApi(Guid saveGameId)
    {
        // Verwijder alle bestaande objecten in de scene
        foreach (var obj in placedObjects)
        {
            Destroy(obj);
        }
        placedObjects.Clear();

        string json = await API.ApiHelper.GetSave(saveGameId);
        // Verwacht dat het JSON een veld "Objects" bevat met een array van GObjectDto
        var wrapper = JsonUtility.FromJson<GObjectDtoArrayWrapper>(json);
        if (wrapper != null && wrapper.Objects != null)
        {
            foreach (var dto in wrapper.Objects)
            {
                GameObject obj = Instantiate(prefabObjects[dto.TypeIndex], new Vector2(dto.PositionX, dto.PositionY), Quaternion.identity);
                Object2D object2D = obj.GetComponent<Object2D>();
                object2D.id = dto.Id;
                object2D.typeIndex = dto.TypeIndex;
                object2D.objectManager = this;
                object2D.isDragging = false;
                placedObjects.Add(obj);
            }
        }
    }

    [Serializable]
    private class GObjectDtoArrayWrapper
    {
        public GObjectDto[] Objects;
    }

    public void ShowMenu()
    {
        UISideMenu.SetActive(true);
    }
}
