// Using System
using System;
using System.Linq;

// Using Unity
using UnityEngine;

#region Classe du GameObject
[Serializable]
public class FloorScript : MonoBehaviour
{
    #region Properties
    public int FloorNumber { get; set; }
    public EnemyScript EnemyScript { get; set; }
    public ContainerScript Container { get; set; }
    #endregion

    #region Constructor
    public void Initialize(int floorNumber, int totalFloorsNumber)
    {
        this.FloorNumber = floorNumber;

        // Récupération des models adaptés à l'étage
        ContainerModel containerModel = GetAdaptedContainer();
        EnemyModel enemyModel = GetAdaptedEnemy(totalFloorsNumber);

        // Création des objets depuis les données des models
        this.EnemyScript = ObjectFactory.CreateEnemy(enemyModel.Name, enemyModel.Health, enemyModel.Damages);
        this.Container = ObjectFactory.CreateContainer(containerModel.Name, containerModel.StorageCapacity, null, null);
    }

    /// <summary>
    /// Selon le numéro de l'étage renvoie un model de sac, coffre ou armoire
    /// </summary>
    /// <returns></returns>
    private ContainerModel GetAdaptedContainer()
    {
        switch (this.FloorNumber)
        {
            case 0:
                return GetDataFromJson.containerModelsList.Single(cont => cont.Name == "Sac");
            case 1:
                // 80% de chances de renvoyer une armoire
                return new System.Random().Next(100) >= 80
                    ? GetDataFromJson.containerModelsList.Single(cont => cont.Name == "Coffre")
                    : GetDataFromJson.containerModelsList.Single(cont => cont.Name == "Armoire");
            case 2:
                return GetDataFromJson.containerModelsList.Single(cont => cont.Name == "Coffre");
            default:
                return null;
        }
    }

    /// <summary>
    /// Selon le numéro de l'étage renvoie un model d'ennemi correspondant à un ennemi standard ou un boss
    /// </summary>
    /// <returns></returns>
    private EnemyModel GetAdaptedEnemy(int totalFloorsNumber)
    {
        // Si le numéro d'étage ne correspond pas au dernier du bâtiment
        if (this.FloorNumber + 1 != totalFloorsNumber)
        {
            return GetDataFromJson.enemyModelsList[new System.Random().Next(GetDataFromJson.enemyModelsList.Count)];
        }
        else
        {
            return GetDataFromJson.bossModelsList[new System.Random().Next(GetDataFromJson.bossModelsList.Count)];
        }
    }
    #endregion
}
#endregion

#region Classe modèle
[Serializable]
public class FloorModel
{
    #region Properties
    public int FloorNumber { get; set; }
    #endregion

    #region Constructors
    public FloorModel() { }
    public FloorModel(int floorNumber)
    {
        this.FloorNumber = floorNumber;
    }
    #endregion
}
#endregion