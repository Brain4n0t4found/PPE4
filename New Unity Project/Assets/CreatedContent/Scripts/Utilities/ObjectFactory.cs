// Using System
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
    private GetDataFromJson GetDataFromJsonScript;
    #endregion

    #region Unity Functions
    void Start()
    {
        Instance = this;

        // Création de l'objet de récupération JSON
        GetDataFromJsonScript = new GetDataFromJson();

        // Récupération de la liste de charactères dans le fichier des ressources du jeu
        List<MainCharacterModel> listCharacters = GetDataFromJsonScript.SearchDataFromJsonRessources<MainCharacterModel>("characters");

        // Création du personnage
        mainCharacter = CreateCharacter(listCharacters[0].Name, listCharacters[0].Health, listCharacters[0].EnergyAmount);

        // Log pour test
        Debug.Log(mainCharacter.Name);

        mainCharacter.EquipmentObjects.Add(CreateEquipmentObject("Key"));
        mainCharacter.EquipmentObjects.Add(CreateEquipmentObject("Key"));

        mainCharacter.EquipmentObjects.ForEach(obj => Debug.Log(obj.Name));
        Debug.Log(mainCharacter.TryUseKey().ToString());

        mainCharacter.EquipmentObjects.ForEach(obj => Debug.Log(obj.Name));
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
    /// Crée un objet EquipmentObject et renvoie son script 
    /// </summary>
    /// <param name="name"></param>
    /// <returns>Script de l'EquipmentObject</returns>
    public static EquipmentObjectClass CreateEquipmentObject(string name)
    {
        EquipmentObjectClass equipmentObject = new EquipmentObjectClass();
        equipmentObject.Initialize(name);

        if (mainCharacter != null)
        {
            equipmentObject.AttachToCharacter(mainCharacter.gameObject);
        }

        return equipmentObject;
    }

    public static StateClass CreateStateObject(string name, int damageRate, GameObject entityAttachedTo)
    {
        StateClass state = new StateClass();
        state.Initialize(name, damageRate, entityAttachedTo);


    }
    #endregion
}
