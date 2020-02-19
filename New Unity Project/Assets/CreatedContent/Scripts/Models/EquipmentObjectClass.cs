using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentObjectClass : MonoBehaviour
{
    public string Name { get; set; }
    public int DamageBoost { get; set; }
    public int EnergyBoost { get; set; }
    public int InstantLife { get; set; }
    public int InstantEnergy { get; set; }
}
