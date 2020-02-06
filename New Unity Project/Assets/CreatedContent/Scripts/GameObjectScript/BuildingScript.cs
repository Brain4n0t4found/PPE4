using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public string Name { get; set; }
    public int FloorNumber { get; set; }
    public List<FloorScript> FloorList { get; set; }

    public void Initialize()
    {
        FloorNumber = new System.Random().Next(1, 3);  // Création d'un nombre d'étages aléatoire

        // Création et remplissage de la liste d'étages
        FloorList = new List<FloorScript>();
        for (int i = 0; i < FloorNumber; i++)
        {
            FloorList.Add(ObjectFactory.CreateFloor(i));
        }
    }
}
