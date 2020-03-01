// Using System
using System;

[Serializable]
public class StateModel
{
    #region Properties
    public string Name { get; set; }
    public int DamageRate { get; set; }
    #endregion

    #region Constructors
    public StateModel() { }
    public StateModel(string name, int damageRate)
    {
        this.Name = name;
        this.DamageRate = damageRate;
    }
    #endregion
}
