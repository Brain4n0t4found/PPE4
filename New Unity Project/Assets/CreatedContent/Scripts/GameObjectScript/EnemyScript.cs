using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damages { get; set; }

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
}