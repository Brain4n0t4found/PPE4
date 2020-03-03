// Using System
using System;
using System.Collections.Generic;

// Using Unity
using UnityEngine;

#region Classe du GameObject
public class ContainerScript : MonoBehaviour
{
    #region Properties
    public string Name { get; set; }
    public int StorageCapacity { get; set; }
    public bool HasLockOnIt { get; set; }
    public List<EquipmentObjectClass> ListEquipmentObjects { get; set; }
    public WeaponScript Weapon { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, int storageCapacity, List<EquipmentObjectClass> listEquipmentObjects, WeaponScript weapon)
    {
        this.Name = name;
        this.StorageCapacity = storageCapacity;
        this.ListEquipmentObjects = listEquipmentObjects;
        this.Weapon = weapon;

        switch (this.Name)
        {
            case "Sac":
                this.HasLockOnIt = false;
                break;
            case "Armoire":
                this.HasLockOnIt = new System.Random().Next(1) == 0 ? true : false;
                break;
            case "Coffre":
                this.HasLockOnIt = true;
                break;
        }
    }
    #endregion
}
#endregion

#region Classe modèle
[Serializable]
public class ContainerModel
{
    #region Properties
    public string Name { get; set; }
    public int StorageCapacity { get; set; }
    #endregion

    #region Constructors
    public ContainerModel() { }
    public ContainerModel(string name, int storageCapactity)
    {
        this.Name = name;
        this.StorageCapacity = storageCapactity;
    }
    #endregion
}
#endregion