// Using System
using System.Linq;
using System.Collections.Generic;

// Using Unity
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    #region Properties
    protected static ObjectFactory Instance; // Nécessaire
    public GameObject EnemyPreFab;
    public GameObject MainCharacterPreFab;
    public GameObject BuildingPreFab;
    public GameObject FloorPreFab;
    public GameObject WeaponPreFab;
    public GameObject ContainerPreFab;

    private static MainCharacterScript mainCharacter;
    #endregion

    #region Unity Functions
    void Start()
    {
        #region À GARDER
        Instance = this;

        GetDataFromJson.setClassContent();
        #endregion

        /*BuildingModel buildingModel = GetDataFromJson.buildingModelsList.Single(build => build.Name == "Commissariat");

        CreateBuilding(buildingModel.Name, buildingModel.FloorsNumber);

        BuildingScript building = GameObject.FindGameObjectWithTag("Building").GetComponent<BuildingScript>();
        GameObject[] listFloors = GameObject.FindGameObjectsWithTag("Floor");
        GameObject[] listEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] listContainers = GameObject.FindGameObjectsWithTag("Container");*/

        MainCharacterModel characterModel = GetDataFromJson.mainCharacterModelsList.Single(c => c.Name == "John");
        mainCharacter = CreateCharacter(characterModel.Name, characterModel.Health, characterModel.EnergyAmount);

        EquipmentObjectModel equipmentObject = GetDataFromJson.equipmentObjectModelsList.Single(equipObj => equipObj.Id == "TinCan");
        EquipmentObjectClass equipmentObjectClass = CreateEquipmentObject(equipmentObject.Name, equipmentObject.Type, equipmentObject.Id);

        equipmentObjectClass.AttachToCharacter(mainCharacter);

        Debug.Log(mainCharacter.Health);
        mainCharacter.TakeDamages(35);
        Debug.Log(mainCharacter.Health);

        mainCharacter.ConsumeObject(equipmentObject);
        Debug.Log(mainCharacter.Health);
    }

    // Permet au gameObject de ne pas être détruit lors du changement de scènes
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

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
    public static BuildingScript CreateBuilding(string name, int floorsNumber)
    {
        BuildingScript building = Instantiate(Instance.BuildingPreFab, Vector3.zero, Quaternion.identity).GetComponent<BuildingScript>();
        building.Initialize(name, floorsNumber);
        return building;
    }

    /// <summary>
    /// Crée un objet Floor et renvoie son script
    /// </summary>
    /// <param name="floorNumber"></param>
    /// <returns>Script du Floor créé</returns>
    public static FloorScript CreateFloor(int floorNumber, int totalFloorsNumber)
    {
        FloorScript floor = Instantiate(Instance.FloorPreFab, Vector3.zero, Quaternion.identity).GetComponent<FloorScript>();
        floor.Initialize(floorNumber, totalFloorsNumber);
        return floor;
    }

    /// <summary>
    /// Crée un objet Container et renvoie son script
    /// </summary>
    /// <param name="name"></param>
    /// <param name="storageCapacity"></param>
    /// <param name="listEquipmentObjects"></param>
    /// <param name="weapon"></param>
    /// <returns>Script du Container créé</returns>
    public static ContainerScript CreateContainer(string name, int storageCapacity, List<EquipmentObjectClass> listEquipmentObjects, WeaponScript weapon)
    {
        ContainerScript container = Instantiate(Instance.ContainerPreFab, Vector3.zero, Quaternion.identity).GetComponent<ContainerScript>();
        container.Initialize(name, storageCapacity, listEquipmentObjects, weapon);
        return container;
    }

    /// <summary>
    /// Crée un objet C# EquipmentObject et le renvoie
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Objet C# EquipmentObjectClass</returns>
    public static EquipmentObjectClass CreateEquipmentObject(string name, string type, string id)
    {
        EquipmentObjectClass equipmentObject = new EquipmentObjectClass();
        equipmentObject.Initialize(name, mainCharacter, type, id);
        return equipmentObject;
    }

    /// <summary>
    /// Crée un objet C# State et le renvoie 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="damageRate"></param>
    /// <param name="entityAttachedTo"></param>
    /// <returns>Objet C# StateClass</returns>
    public static StateClass CreateState(string name, int damageRate, GameObject entityAttachedTo)
    {
        StateClass state = new StateClass();
        state.Initialize(name, damageRate, entityAttachedTo);

        return state;
    }
    #endregion
}
