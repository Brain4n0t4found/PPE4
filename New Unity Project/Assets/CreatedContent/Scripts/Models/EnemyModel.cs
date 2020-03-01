// Using System
using System;

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
