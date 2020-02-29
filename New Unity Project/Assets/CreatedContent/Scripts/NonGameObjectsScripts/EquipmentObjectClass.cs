using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentObjectClass : MonoBehaviour
{
    public string Name { get; set; }

    private GameObject character { get; set; }


    #region Constructors
    public EquipmentObjectClass() { }
    public EquipmentObjectClass(string name)
    {
        this.Name = name;
    }
    #endregion

    public void AttachToCharacter(GameObject character)
    {
        this.character = character;
    }
}
