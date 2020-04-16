// Using System
using System.Linq;
using System.Collections.Generic;

// Using Unity
using UnityEngine;
using System;

// Using Project
using Assets.CreatedContent.Scripts.Utilities;

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

    private GameProgressScript GameProgressScript;

    private static MainCharacterScript MainCharacter;
    #endregion

    #region Unity Functions
    void Start()
    {
        #region À GARDER
        Instance = this;

        GetDataFromJson.setClassContent();

        // Lancement de la génération de la première scène
        GameProgressScript = GameObject.FindGameObjectWithTag("GameProgress").GetComponent<GameProgressScript>();
        #endregion
    }

       
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
        enemy.transform.position = new Vector3(10f, 15f, -1f);
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
        MainCharacter = mainCharacter;
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
        building.transform.position = new Vector3(3f, 1f);
        return building;
    }

    /// <summary>
    /// Crée un objet Floor et renvoie son script
    /// </summary>
    /// <param name="floorNumber"></param>
    /// <returns>Script du Floor créé</returns>
    public static FloorScript CreateFloor(int floorNumber, int totalFloorsNumber)
    {
        FloorScript floor = Instantiate(Instance.FloorPreFab, new Vector3(0, 10f + floorNumber * 10f, 0), Quaternion.identity).GetComponent<FloorScript>();
        floor.Initialize(floorNumber, totalFloorsNumber);
        floor.transform.position = new Vector3(3f, 15f);
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
        container.transform.position = new Vector3(12f, 16f);
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
        equipmentObject.Initialize(name, MainCharacter, type, id);
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
