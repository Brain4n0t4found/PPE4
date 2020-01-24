using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public string Name { get; set; }
    public int LifeAmount { get; set; }
    public int Damages { get; set; }

    public EnemyScript(string name, int lifeAmount, int damages)
    {
        this.Name = name;
        this.LifeAmount = lifeAmount;
        this.Damages = damages;
    }
}