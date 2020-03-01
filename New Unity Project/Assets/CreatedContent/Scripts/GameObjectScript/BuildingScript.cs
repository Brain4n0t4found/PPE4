// Using System
using System.Collections.Generic;

// USing Unity
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    #region properties
    public string Name { get; set; }
    public int FloorNumber { get; set; }
    public List<FloorScript> FloorList { get; set; }
    #endregion

    #region Constructor
    /// <summary>
    /// Remplit les valeurs du script
    /// </summary>
    public void Initialize()
    {
        FloorNumber = 2; //new System.Random().Next(1, 4);  // Création d'un nombre d'étages aléatoire

        // Création et remplissage de la liste d'étages
        FloorList = new List<FloorScript>();
        for (int i = 0; i < FloorNumber; i++)
        {
            FloorList.Add(ObjectFactory.CreateFloor(i));
        }
    }
    #endregion
}
