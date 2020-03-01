// Using Unity
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    #region Properties
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damages { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Remplit les valeurs du script
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="damages"></param>
    public void Initialize(string name, int health, int damages)
    {
        Name = name;
        Health = health;
        Damages = damages;
    }
    #endregion
}