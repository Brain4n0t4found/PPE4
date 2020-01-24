using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour
{
    public string Name { get; private set; }
    public int LifeAmount { get; set; }
    public int EnergyAmount { get; set; }

    public List<EquipmentObjectClass> equipmentObjects { get; set; }
    public List<StateClass> characterStates { get; set; }
    public List<WeaponClass> weaponList { get; set; }

    public MainCharacterScript(string name, int lifeAmount, int energyAmount)
    {
        this.Name = name;
        this.LifeAmount = lifeAmount;
        this.EnergyAmount = energyAmount;
    }
}
