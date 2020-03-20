// Using System
using System;
using System.Linq;

// Using Unity
using UnityEngine;

#region Classe de l'objet final
[Serializable]
public class EquipmentObjectClass
{
    #region Properties
    public string Name { get; set; }
    public string Type { get; set; }
    public string Id { get; set; }
    public int Gain { get; set; }
    protected MainCharacterScript Character { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, MainCharacterScript mainCharacter, string type, string id)
    {
        this.Name = name;
        this.Type = type;
        this.Id = id;

        if (mainCharacter != null)
        {
            AttachToCharacter(mainCharacter);
        }
    }
    #endregion

    #region Functions
    /// <summary>
    /// Attache l'objet au personnage (et applique les effets liés s'il y en a)
    /// </summary>
    /// <param name="character"></param>
    public void AttachToCharacter(MainCharacterScript character)
    {
        this.Character = character;
        this.Character.EquipmentObjects.Add(this);

        switch(Type)
        {
            case "Munition":
                // Récupération du nom de l'arme
                string weaponName = this.Name.Substring(4);

                // Recherche de si le personnage possède une arme de ce nom
                WeaponScript possibleWeapon = this.Character.WeaponList.Where(weap => weap.Id == weaponName).First();

                /* Si oui augmentation du nombre de munitions :
                 * Attribution d'un nombre aléatoire de munitions entre 0.5 et 1.5 fois la taille du chargeur de l'arme */
                if (possibleWeapon != null)
                    possibleWeapon.MunitionAmount += new System.Random().Next(Convert.ToInt32(possibleWeapon.ChargerLength * 0.5), Convert.ToInt32(possibleWeapon.ChargerLength * 1.5));

                // Changement de la valeur de l'arme équippée si c'est la même
                this.Character.EquippedWeapon = possibleWeapon;
                break;

            case "Armure":
                // Augmentation de 15% la résistance aux dégats du personnage, et de 45% s'il s'agit de la dernière pièce d'armure manquante
                this.Character.DamageReductionPercentage = this.Character.DamageReductionPercentage < 0.6
                    ? this.Character.DamageReductionPercentage + 0.15
                    : 0.9;
                break;

            case "Consommable":
                // Récupération de la quantité de boost de stat du personnage que procure le consommable
                ConsommableGainStatsModel gainStatsModel = GetDataFromJson.consommableGainStatsModelsList.SingleOrDefault(gainStat => gainStat.Id == this.Id);

                // Attribution 
                Gain = gainStatsModel.Gain;
                break;
        }
    }
    #endregion
}
#endregion

#region Classes modèles
[Serializable]
public class EquipmentObjectModel
{
    #region Properties
    public string Name { get; set; }
    public string Type { get; set; }
    public string Id { get; set; }
    #endregion

    #region Constructors
    public EquipmentObjectModel() { }
    public EquipmentObjectModel(string name, string type, string id)
    {
        this.Name = name;
        this.Type = type;
        this.Id = id;
    }
    #endregion
}

[Serializable]
public class ConsommableGainStatsModel
{
    #region Properties
    public string Id { get; set; }
    public int Gain { get; set; }
    #endregion

    #region Constructor
    public ConsommableGainStatsModel() { }
    public ConsommableGainStatsModel(string id, int gain)
    {
        this.Id = id;
        this.Gain = gain;
    }
    #endregion
}
#endregion