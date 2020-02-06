using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int EnergyAmount { get; set; }

    public List<EquipmentObjectClass> equipmentObjects { get; set; }
    public List<StateClass> characterStates { get; set; }
    public List<WeaponClass> weaponList { get; set; }

    public void Initialize(string name, int health, int energyAmount)
    {
        Name = name;
        Health = health;
        EnergyAmount = energyAmount;

        equipmentObjects = new List<EquipmentObjectClass>();
        characterStates = new List<StateClass>();
        weaponList = new List<WeaponClass>();
    }
}
