using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using UnityEngine;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ObjectFactory : MonoBehaviour
{
    protected static ObjectFactory Instance; // Nécessaire
    public GameObject EnemyPreFab;
    public GameObject MainCharacterPreFab;
    public GameObject BuildingPreFab;
    public GameObject FloorPreFab;
    public GameObject WeaponPreFab;
    public GameObject ContainerPreFab;
    public StateClass StateScript;
    public EquipmentObjectClass EquipmentObjectScript;

    private GetDataFromJson GetDataFromJsonScript;

    private string JsonContent { get; set; }

    void Start()
    {
        Instance = this;
        /*GetDataFromJsonScript = gameObject.GetComponent<GetDataFromJson>();

        GetDataFromJsonScript.SearchDataFromJsonRessources();*/

        CreateBuilding();
    }

    #region Creation d'objets

    /// <summary>
    /// Crée un objet EnemyScript et renvoie son script
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="damages"></param>
    /// <returns>Script de l'EnemyScript créé</returns>
    public static EnemyScript CreateEnemy(string name, int health, int damages)
    {
        EnemyScript enemy = Instantiate(Instance.EnemyPreFab, Vector3.zero, Quaternion.identity).GetComponent<EnemyScript>();
        enemy.Initialize(name, health, damages);
        return enemy;
    }

    /// <summary>
    /// Crée un objet MainCharacter et renvoie son script
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="energyAmount"></param>
    /// <returns>Script du MainCharacter créé</returns>
    public static MainCharacterScript CreateCharacter(string name, int health, int energyAmount)
    {
        MainCharacterScript mainCharacter = Instantiate(Instance.MainCharacterPreFab, Vector3.zero, Quaternion.identity).GetComponent<MainCharacterScript>();
        mainCharacter.Initialize(name, health, energyAmount);
        return mainCharacter;
    }

    /// <summary>
    /// Crée un objet Building et renvoie son script
    /// </summary>
    /// <returns>Script du Building créé</returns>
    public static BuildingScript CreateBuilding()
    {
        BuildingScript building = Instantiate(Instance.BuildingPreFab, Vector3.zero, Quaternion.identity).GetComponent<BuildingScript>();
        building.Initialize();
        return building;
    }

    /// <summary>
    /// Crée un objet Floor et renvoie son script
    /// </summary>
    /// <param name="floorNumber"></param>
    /// <returns>Script du Floor créé</returns>
    public static FloorScript CreateFloor(int floorNumber)
    {
        FloorScript floor = Instantiate(Instance.FloorPreFab, Vector3.zero, Quaternion.identity).GetComponent<FloorScript>();
        floor.Initialize(floorNumber);
        return floor;
    }

    public static ContainerScript CreateContainer(string name, int storageCapacity, List<EquipmentObjectClass> listEquipmentObjects, WeaponScript weapon)
    {
        ContainerScript container = Instantiate(Instance.ContainerPreFab, Vector3.zero, Quaternion.identity).GetComponent<ContainerScript>();
        container.Initialize(name, storageCapacity, listEquipmentObjects, weapon);
        return container;
    }
    #endregion
}
