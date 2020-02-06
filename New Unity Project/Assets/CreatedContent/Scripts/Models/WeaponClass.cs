using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponClass : MonoBehaviour
{
    public string Name { get; set; }
    public int Damages { get; set; }
    public int MunitionAmount { get; set; }

    public WeaponClass() { }
}
