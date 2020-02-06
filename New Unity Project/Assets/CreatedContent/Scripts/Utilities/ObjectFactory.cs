using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    protected static ObjectFactory instance; // Needed
    public GameObject enemyPreFab;
    public GameObject mainCharacterPreFab;
    public GameObject buildingPreFab;
    public GameObject floorPrefab;

    void Start()
    {
        instance = this;
    }

    #region Creation d'objets
    public static EnemyScript CreateEnemy(string name, int health, int damages)
    {
        EnemyScript enemy = Instantiate(instance.enemyPreFab, Vector3.zero, Quaternion.identity).GetComponent<EnemyScript>();
        enemy.Initialize(name, health, damages);
        return enemy;
    }

    public static MainCharacterScript CreateCharacter(string name, int health, int energyAmount)
    {
        MainCharacterScript mainCharacter = Instantiate(instance.mainCharacterPreFab, Vector3.zero, Quaternion.identity).GetComponent<MainCharacterScript>();
        mainCharacter.Initialize(name, health, energyAmount);
        return mainCharacter;
    }

    public static BuildingScript CreateBuilding()
    {
        BuildingScript building = Instantiate(instance.buildingPreFab, Vector3.zero, Quaternion.identity).GetComponent<BuildingScript>();
        building.Initialize();
        return building;
    }

    public static FloorScript CreateFloor(int floorNumber)
    {
        FloorScript floor = Instantiate(instance.floorPrefab, Vector3.zero, Quaternion.identity).GetComponent<FloorScript>();
        floor.Initialize(floorNumber);
        return floor;
    }
    #endregion
}
