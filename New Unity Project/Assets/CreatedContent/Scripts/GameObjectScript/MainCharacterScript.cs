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
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int EnergyAmount { get; set; }
    public Transform mainCharacter;
    public int InitialisePosition { get; set; }
    public int FinalPosition { get; set; }
    public int InitialiseSize { get; set; }
    public int FinalSize { get; set; }
    public float startingDistFromBuilding;
    public float differenceMinMaxSize;
    public bool IsMoving = false;
    public bool isTaking = false;
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
        MaxHealth = health;
        EnergyAmount = energyAmount;
        DamageReductionPercentage = 0;

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

    public void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("Character").GetComponent<Transform>();
        Transform Building = GameObject.FindGameObjectWithTag("Building").GetComponent<Transform>();

        startingDistFromBuilding = Math.Abs(mainCharacter.position.x - Building.position.x);
        differenceMinMaxSize = Math.Abs(InitialiseSize - FinalSize);
    }

    public void Update()
    {
        Transform Building = GameObject.FindGameObjectWithTag("Building").GetComponent<Transform>();

        if (IsMoving == true)
        {
            float dist = Math.Abs(mainCharacter.position.x - Building.position.x);
            float movePercentageToDo = dist / startingDistFromBuilding;

            //mainCharacter.localScale = new Vector3(InitialiseSize - (1 - movePercentageToDo) * differenceMinMaxSize, InitialiseSize - (1 - movePercentageToDo) * differenceMinMaxSize);

            mainCharacter.position = new Vector3(mainCharacter.position.x + 0.1f, mainCharacter.position.y);
        }
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
        EquipmentObjectClass potentialKey = EquipmentObjects.Any(obj => obj.Name == "Key")
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
        // Si l'objet est bien un consommable
        if (objectToSearch.Type == "Consommable")
        {
            // Recherche dans la liste d'objets pour un qui a le même nom
            if (EquipmentObjects.Any(obj => obj.Name == objectToSearch.Name))
            {
                // Récupération de l'objet
                EquipmentObjectClass equipmentObject = EquipmentObjects.Where(obj => obj.Name == objectToSearch.Name).FirstOrDefault();

                // Si elle a été faite avec succés
                if (equipmentObject != null)
                {
                    // Différenciation de la boisson énergisante
                    if (equipmentObject.Id != "EnergyDrink")
                    {
                        // Gain de vie de la quantité rendue par l'objet
                        GainLife(equipmentObject.Gain);
                    }
                    else
                    {
                        // Perte de 1 ou 2 points de vie (aléatoire)
                        TakeDamages(new System.Random().Next(1, 3));

                        // Gain d'énergie rendue par l'objet
                        EnergyAmount += equipmentObject.Gain;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Modifie la propriété Health par rapport à la valeur damages
    /// </summary>
    /// <param name="damages"></param>
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
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            IsMoving = false;
            Destroy(collision.gameObject.GetComponent<BoxCollider2D>());

            Transform mainObjectCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
            Transform Floor = GameObject.FindGameObjectWithTag("Floor").GetComponent<Transform>();
            mainCharacter.position = new Vector3(5f, 15f);
            mainCharacter.rotation = Quaternion.Euler(0, 0, 0);
            mainObjectCamera.position = new Vector3(9f, 17f, -1f);
            //gameCamera.transform.position = Vector2.MoveTowards(transform.position, groundFloor.position, (100 * 100) * Time.deltaTime);
        }
    }

    /// <summary>
    /// Modifie la propriété Health par rapport à la valeur gainValue
    /// </summary>
    /// <param name="gainValue"></param>
    public void GainLife(int gainValue)
    {
        Health = (Health + gainValue) > MaxHealth ? MaxHealth : Health + gainValue; 
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