// Using System
using System;
using System.Collections.Generic;

// USing Unity
using UnityEngine;

#region Classe du GameObject
public class BuildingScript : MonoBehaviour
{
    #region properties
    public string Name { get; set; }
    public int FloorNumber { get; set; }
    public List<FloorScript> FloorList { get; set; }
    #endregion

    #region Constructor
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
#endregion

#region Classe modèle
[Serializable]
public class BuildingModel
{
    #region Properties
    public string Name { get; set; }
    public int FloorNumber { get; set; }
    #endregion

    #region Constructors
    public BuildingModel() { }
    public BuildingModel(string name, int floorNumber)
    {
        this.Name = name;
        this.FloorNumber = floorNumber;
    }
    #endregion
}
#endregion