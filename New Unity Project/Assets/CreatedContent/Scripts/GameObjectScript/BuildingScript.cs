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
    public int FloorsNumber { get; set; }
    public List<FloorScript> FloorList { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, int floorsNumber)
    {
        this.Name = name;
        this.FloorsNumber = floorsNumber;

        // Déclaration de la liste d'étages et remplissage selon le nombre d'étages récupéré du JSON
        FloorList = new List<FloorScript>();
        for (int i = 0; i < this.FloorsNumber; i++)
        {
            FloorList.Add(ObjectFactory.CreateFloor(i, this.FloorsNumber));
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
    public int FloorsNumber { get; set; }
    #endregion

    #region Constructors
    public BuildingModel() { }
    public BuildingModel(string name, int floorNumber)
    {
        this.Name = name;
        this.FloorsNumber = floorNumber;
    }
    #endregion
}
#endregion