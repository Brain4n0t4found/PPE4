using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    public string Name { get; set; }
    public int StorageCapacity { get; set; }
    public List<EquipmentObjectClass> ListEquipmentObjects { get; set; }
    public WeaponClass Weapon { get; set; }

    public static string Test { get; set; }

    public void Initialize(string name, int storageCapacity, List<EquipmentObjectClass> listEquipmentObjects, WeaponClass weapon)
    {
        this.Name = name;
        this.StorageCapacity = storageCapacity;
        this.ListEquipmentObjects = listEquipmentObjects;
        this.Weapon = weapon;
    }
}
