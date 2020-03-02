// Using System
using System;

// Using Unity
using UnityEngine;

#region Classe du GameObject
public class WeaponScript : MonoBehaviour
{
    #region Properties
    public string Name { get; set; }
    public int Damages { get; set; }
    public int MunitionAmount { get; set; }

    private GameObject character { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, int damages, int munitionsAmount)
    {
        this.Name = name;
        this.Damages = damages;
        this.MunitionAmount = munitionsAmount;
    }
    #endregion

    #region Functions
    public void AttachToCharacter(GameObject character)
    {
        this.character = character;
    }
    #endregion
}
#endregion

#region Classe modèle
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
#endregion