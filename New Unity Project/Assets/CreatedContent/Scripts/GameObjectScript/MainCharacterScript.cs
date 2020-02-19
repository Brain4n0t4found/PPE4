using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    public string Name { get; private set; }
    public int Health { get; set; }
    public int EnergyAmount { get; set; }
    public WeaponClass EquippedWeapon { get; set; }

    public List<EquipmentObjectClass> EquipmentObjects { get; set; }
    public List<StateClass> CharacterStates { get; set; }
    public List<WeaponClass> WeaponList { get; set; }

    /// <summary>
    /// Remplit les valeurs du script
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="energyAmount"></param>
    public void Initialize(string name, int health, int energyAmount)
    {
        Name = name;
        Health = health;
        EnergyAmount = energyAmount;

        EquipmentObjects = new List<EquipmentObjectClass>();
        CharacterStates = new List<StateClass>();
        WeaponList = new List<WeaponClass>();
    }

    /// <summary>
    /// Change l'arme actuellement équipée
    /// </summary>
    public void SwapWeapon()
    {
        if (EquippedWeapon != null)
        {
            if (WeaponList.IndexOf(EquippedWeapon) + 1 < WeaponList.Count)
                EquippedWeapon = WeaponList[WeaponList.IndexOf(EquippedWeapon) + 1];
            else
                EquippedWeapon = WeaponList[0];
        }
        else
        {
            if (WeaponList.Count > 0)
                EquippedWeapon = WeaponList[0];
        }
    }
}
