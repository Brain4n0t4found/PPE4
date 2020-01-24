using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClass : MonoBehaviour
{
    public string Name { get; set; }
    public int FloorNumber { get; set; }
    public List<FloorClass> FloorList{ get; set; }

    public BuildingClass()
    {
        this.FloorNumber = new System.Random().Next(1, 3);  // Création d'un nombre d'étages aléatoire

        // Création et remplissage de la liste d'étages
        this.FloorList = new List<FloorClass>();
        for (int i = 0; i < this.FloorNumber; i++)
        {
            FloorList.Add(new FloorClass(i));
        }
    }
}
