// Using Unity
using UnityEngine;

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
