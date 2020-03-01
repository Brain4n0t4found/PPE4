// Using System
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Using Unity
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int EnergyAmount { get; set; }
    public WeaponScript EquippedWeapon { get; set; }

    public List<EquipmentObjectClass> EquipmentObjects { get; set; }
    public List<StateClass> CharacterStates { get; set; }
    public List<WeaponScript> WeaponList { get; set; }

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
        WeaponList = new List<WeaponScript>();
    }

    // Permet au gameObject de ne pas être détruit lors du changement de scènes
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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

    /// <summary>
    /// Cherche et détruit une clé dans l'inventaire du personnage
    /// </summary>
    /// <returns>boolean si le personnage a une clé ou non</returns>
    public bool TryUseKey()
    {
        // Tentative de récupération d'une clé dans la liste d'objets du personnage
        EquipmentObjectClass potentialKey = EquipmentObjects.Any(obj => obj.Name == "Key")
            ? EquipmentObjects.Where(obj => obj.Name == "Key").First()
            : null;
        
        if (potentialKey != null)
        {
            Destroy(potentialKey.gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Renvoie un booléen selon si le personnage est fatigué ou non
    /// </summary>
    /// <returns>Boolean</returns>
    public bool CanDoAction()
    {
        return CharacterStates.Any(stat => stat.Name == "Fatigué") 
            ? false  // Si le personnage est affecté par l'état "fatigué"
            : true;  // Sinon
    }
}
