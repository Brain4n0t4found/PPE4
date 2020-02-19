using System;
using System.IO;
using System.Text;

using UnityEngine;
using Newtonsoft.Json.Linq;

public class ObjectFactory : MonoBehaviour
{
    protected static ObjectFactory instance; // Nécessaire
    public GameObject enemyPreFab;
    public GameObject mainCharacterPreFab;
    public GameObject buildingPreFab;
    public GameObject floorPreFab;
    public GameObject weaponPreFab;
    public StateClass stateScript;
    public EquipmentObjectClass equipmentObjectScript;

    private GetDataFromJson getDataFromJsonScript;

    private string JsonContent { get; set; }

    void Start()
    {
        instance = this;
        getDataFromJsonScript = gameObject.GetComponent<GetDataFromJson>();

        getDataFromJsonScript.SearchDataFromJsonRessources();
    }

    #region Creation d'objets

    /// <summary>
    /// Crée un objet Enemy et renvoie son script
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="damages"></param>
    /// <returns>Script de l'Enemy créé</returns>
    public static EnemyScript CreateEnemy(string name, int health, int damages)
    {
        EnemyScript enemy = Instantiate(instance.enemyPreFab, Vector3.zero, Quaternion.identity).GetComponent<EnemyScript>();
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
        MainCharacterScript mainCharacter = Instantiate(instance.mainCharacterPreFab, Vector3.zero, Quaternion.identity).GetComponent<MainCharacterScript>();
        mainCharacter.Initialize(name, health, energyAmount);
        return mainCharacter;
    }

    /// <summary>
    /// Crée un objet Building et renvoie son script
    /// </summary>
    /// <returns>Script du Building créé</returns>
    public static BuildingScript CreateBuilding()
    {
        BuildingScript building = Instantiate(instance.buildingPreFab, Vector3.zero, Quaternion.identity).GetComponent<BuildingScript>();
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
        FloorScript floor = Instantiate(instance.floorPreFab, Vector3.zero, Quaternion.identity).GetComponent<FloorScript>();
        floor.Initialize(floorNumber);
        return floor;
    }

    /*public static StateClass CreateState(string name)
    {
        StateClass state = new StateClass();
        return state;
    }*/

    #endregion
}
