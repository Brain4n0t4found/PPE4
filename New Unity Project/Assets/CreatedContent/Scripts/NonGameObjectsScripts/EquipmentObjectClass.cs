// Using System
using System;

// Using Unity
using UnityEngine;

[Serializable]
public class EquipmentObjectClass : MonoBehaviour
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
