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

    private GameObject character { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name)
    {
        this.Name = name;
    }
    #endregion

    #region Functions
    public void AttachToCharacter(GameObject character)
    {
        this.character = character;
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
    #endregion

    #region Constructors
    public EquipmentObjectModel() { }
    public EquipmentObjectModel(string name)
    {
        this.Name = name;
    }
    #endregion
}
#endregion