// Using System
using System.Collections.Generic;

// Using Unity
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    #region Properties
    public string Name { get; set; }
    public int StorageCapacity { get; set; }
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
    }
    #endregion
}
