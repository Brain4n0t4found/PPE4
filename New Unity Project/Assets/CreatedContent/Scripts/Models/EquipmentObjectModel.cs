using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentObjectModel
{
    public string Name { get; set; }
    
    public EquipmentObjectModel() { }
    public EquipmentObjectModel(string name)
    {
        this.Name = name;
    }
}
