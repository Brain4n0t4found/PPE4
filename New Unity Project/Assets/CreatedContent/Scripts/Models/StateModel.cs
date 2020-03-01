using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateModel
{
    public string Name { get; set; }
    public int DamageRate { get; set; }

    public StateModel() { }
    public StateModel(string name, int damageRate)
    {
        this.Name = name;
        this.DamageRate = damageRate;
    }
}
