using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorClass : MonoBehaviour
{
    public int FloorNumber { get; set; }
    public GameObject Enemy { get; set; }  // Réaliser le GameObject de l'ennemi
    public GameObject Container { get; set; }  // Réaliser le GameObject du coffre

    // Constructeurs
    public FloorClass() { }
    public FloorClass(int floorNumber)
    {
        this.FloorNumber = floorNumber;

        // TODO - Faire un script de génération pour un ennemi et un coffre
    }
}
