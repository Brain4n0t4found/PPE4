// Using System
using System;

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
    public void Initialize(int floorNumber)
    {
        this.FloorNumber = floorNumber;

        this.EnemyScript = ObjectFactory.CreateEnemy("trucmuche", 50, 25);
        this.Container = ObjectFactory.CreateContainer("oui", 10, null, null);
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