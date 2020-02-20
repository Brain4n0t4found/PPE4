using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public string Name { get; set; }
    public int Damages { get; set; }
    public int MunitionAmount { get; set; }

    private GameObject character { get; set; }

    #region Constructors
    public WeaponScript() { }
    public WeaponScript(string name, int damages, int munitionsAmount)
    {
        this.Name = name;
        this.Damages = damages;
        this.MunitionAmount = munitionsAmount;
    }
    #endregion

    public void AttachToCharacter(GameObject character)
    {
        this.character = character;
    }
}
