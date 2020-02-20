using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloorScript : MonoBehaviour
{
    public int FloorNumber { get; set; }
    public EnemyScript EnemyScript { get; set; }  // Réaliser le GameObject de l'ennemi
    public GameObject Container { get; set; }  // Réaliser le GameObject du coffre

    /// <summary>
    /// Remplit les valeurs du script
    /// </summary>
    /// <param name="floorNumber"></param>
    public void Initialize(int floorNumber)
    {
        this.FloorNumber = floorNumber;

        this.EnemyScript = ObjectFactory.CreateEnemy("trucmuche", 50, 25);
        // TODO - Faire un script de génération pour un ennemi et un coffre
    }
}
