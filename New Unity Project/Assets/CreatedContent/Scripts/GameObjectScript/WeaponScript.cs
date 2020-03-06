// Using System
using System;

// Using Unity
using UnityEngine;

#region Classe du GameObject
public class WeaponScript : MonoBehaviour
{
    #region Properties
    public string Id { get; set; }
    public string Name { get; set; }
    public int Damages { get; set; }
    public int MunitionAmount { get; set; }
    public int ChargerLength { get; set; }
    public int ChargerMunitionAmout { get; set; }

    private GameObject character { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, int damages, int munitionsAmount, int chargerLength, int chargerMunitionAmout, string id)
    {
        this.Name = name;
        this.Damages = damages;
        this.MunitionAmount = munitionsAmount;
        this.ChargerLength = chargerLength;
        this.ChargerMunitionAmout = chargerMunitionAmout;
        this.Id = id;
    }
    #endregion

    #region Functions
    public void AttachToCharacter(GameObject character)
    {
        this.character = character;
    }

    /// <summary>
    /// Recharge l'arme instanciée
    /// </summary>
    public void Reload()
    {
        if (MunitionAmount < ChargerLength)
        {
            ChargerMunitionAmout += MunitionAmount;
            MunitionAmount = 0;
        }
        else
        {
            MunitionAmount += ChargerMunitionAmout;
            ChargerMunitionAmout = ChargerLength;
            MunitionAmount -= ChargerLength;
        }
    }
    #endregion
}
#endregion

#region Classe modèle
[Serializable]
public class WeaponModel
{
    #region Properties
    public string Id { get; set; }
    public string Name { get; set; }
    public int Damages { get; set; }
    public int MunitionAmount { get; set; }
    public int ChargerLength { get; set; }
    public int ChargerMunitionAmout { get; set; }
    #endregion

    #region Constructors
    public WeaponModel() { }
    public WeaponModel(string name, int damages, int munitionAmount, int chargerLength, int chargerMunitionAmout, string id)
    {
        this.Name = name;
        this.Damages = damages;
        this.MunitionAmount = munitionAmount;
        this.ChargerLength = chargerLength;
        this.ChargerMunitionAmout = chargerMunitionAmout;
        this.Id = id;
    }
    #endregion
}
#endregion