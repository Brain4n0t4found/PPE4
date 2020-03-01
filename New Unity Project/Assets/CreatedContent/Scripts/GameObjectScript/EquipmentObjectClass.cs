using System;

using UnityEngine;

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
