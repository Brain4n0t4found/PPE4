// Using System
using System;

[Serializable]
public class MainCharacterModel
{
    #region Properties
    public string Name { get; set; }
    public int Health { get; set; }
    public int EnergyAmount { get; set; }
    #endregion

    #region Constructors
    public MainCharacterModel() { }
    public MainCharacterModel(string name, int health, int energyAmount)
    {
        this.Name = name;
        this.Health = health;
        this.EnergyAmount = energyAmount;
    }
    #endregion
}
