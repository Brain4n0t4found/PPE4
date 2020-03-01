using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyModel
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damages { get; set; }

    public EnemyModel() { }
    public EnemyModel(string name, int health, int damages)
    {
        this.Name = name;
        this.Health = health;
        this.Damages = damages;
    }
}
