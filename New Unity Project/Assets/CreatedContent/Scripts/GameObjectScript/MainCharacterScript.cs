// Using System
using System;
using System.Collections.Generic;
using System.Linq;

// Using Unity
using UnityEngine;

#region Classe du gameObject
public class MainCharacterScript : MonoBehaviour
{
    #region Properties
    public string Name { get; set; }
    public int Health { get; set; }
    public int EnergyAmount { get; set; }
    public double DamageReductionPercentage { get; set; }
    public WeaponScript EquippedWeapon { get; set; }

    public List<EquipmentObjectClass> EquipmentObjects { get; set; }
    public List<StateClass> CharacterStates { get; set; }
    public List<WeaponScript> WeaponList { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, int health, int energyAmount)
    {
        Name = name;
        Health = health;
        EnergyAmount = energyAmount;
        //ArmorPercentage = 0;

        EquipmentObjects = new List<EquipmentObjectClass>();
        CharacterStates = new List<StateClass>();
        WeaponList = new List<WeaponScript>();
    }
    #endregion

    #region Unity Functions
    // Permet au gameObject de ne pas être détruit lors du changement de scènes
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Functions
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
        FinalEquipmentObjectClass potentialKey = EquipmentObjects.Any(obj => obj.Name == "Key")
            ? EquipmentObjects.Where(obj => obj.Name == "Key").First()
            : null;

        if (potentialKey != null)
        {
            // Si le personnage possède une clé
            EquipmentObjects.Remove(potentialKey);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ConsumeObject(EquipmentObjectModel objectToSearch)
    {
        if (EquipmentObjects.Any(obj => obj.Name == objectToSearch.Name))
        {

        }
    }

    /// <summary>
    /// Modifie la propriété Health par rapport à la valeur damages
    /// </summary>
    public void TakeDamages(int damages)
    {
        if (Health > damages)
        {
            Health -= damages;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
#endregion

#region Classe modèle
[Serializable]
public class MainCharacterModel
{
    #region Properties
    public string Name { get; set; }
    public int Health { get; set; }
    public int EnergyAmount { get; set; }
    #endregion

    #region Constructors
    public MainCharacterModel() { }
    public MainCharacterModel(string name, int health, int energyAmount)
    {
        this.Name = name;
        this.Health = health;
        this.EnergyAmount = energyAmount;
    }
    #endregion
}
#endregion