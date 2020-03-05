// Using System
using System;

// Using Unity
using UnityEngine;

#region Classe de l'objet final
[Serializable]
public class EquipmentObjectClass
{
    #region Properties
    public string Name { get; set; }
    protected MainCharacterScript character { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, MainCharacterScript mainCharacter)
    {
        switch (name)
        {
            case""
        }
        /*
        this.Name = name;

        if (mainCharacter != null)
        {
            AttachToCharacter(mainCharacter);
        }
        */
    }
    #endregion

    #region Functions
    public void AttachToCharacter(MainCharacterScript character)
    {
        this.character = character;
        this.character.EquipmentObjects.Add(this);
    }
    #endregion
}
#endregion

#region Classe modèle
[Serializable]
public class EquipmentObjectModel
{
    #region Properties
    public string Name { get; set; }
    public string Type { get; set; }
    #endregion

    #region Constructors
    public EquipmentObjectModel() { }
    public EquipmentObjectModel(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }
    #endregion
}
#endregion

#region Classes enfants de EquipmentObjectClass
public class EquipmentObjectArmor : EquipmentObjectClass
{
    public EquipmentObjectArmor()
    {
        character.DamageReductionPercentage = character.DamageReductionPercentage < 0.6
            ? character.DamageReductionPercentage + 0.15
            : 0.9;
    }
}
#endregion