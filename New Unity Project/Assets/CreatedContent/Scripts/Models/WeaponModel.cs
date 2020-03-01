using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponModel
{
    public string Name { get; set; }
    public int Damages { get; set; }
    public int MunitionAmount { get; set; }

    public WeaponModel() { }
    public WeaponModel(string name, int damages, int munitionAmount)
    {
        this.Name = name;
        this.Damages = damages;
        this.MunitionAmount = munitionAmount;
    }
}
