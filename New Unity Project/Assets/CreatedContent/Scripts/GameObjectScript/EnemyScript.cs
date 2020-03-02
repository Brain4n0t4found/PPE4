// Using System
using System;

// Using Unity
using UnityEngine;

#region Classe du GameObject
public class EnemyScript : MonoBehaviour
{
    #region Properties
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damages { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, int health, int damages)
    {
        Name = name;
        Health = health;
        Damages = damages;
    }
    #endregion
}
#endregion

#region Classe modèle
[Serializable]
public class EnemyModel
{
    #region Properties
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damages { get; set; }
    #endregion

    #region Constructors
    public EnemyModel() { }
    public EnemyModel(string name, int health, int damages)
    {
        this.Name = name;
        this.Health = health;
        this.Damages = damages;
    }
    #endregion
}
#endregion