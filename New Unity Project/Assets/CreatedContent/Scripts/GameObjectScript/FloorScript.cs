using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public int FloorNumber { get; set; }
    public EnemyScript Enemy { get; set; }  // Réaliser le GameObject de l'ennemi
    public GameObject Container { get; set; }  // Réaliser le GameObject du coffre

    public void Initialize(int floorNumber)
    {
        this.FloorNumber = floorNumber;

        this.Enemy = ObjectFactory.CreateEnemy("trucmuche", 50, 25);
        // TODO - Faire un script de génération pour un ennemi et un coffre
    }
}
