// Using System
using System;

[Serializable]
public class WeaponModel
{
    #region Properties
    public string Name { get; set; }
    public int Damages { get; set; }
    public int MunitionAmount { get; set; }
    #endregion

    #region Constructors
    public WeaponModel() { }
    public WeaponModel(string name, int damages, int munitionAmount)
    {
        this.Name = name;
        this.Damages = damages;
        this.MunitionAmount = munitionAmount;
    }
    #endregion
}
