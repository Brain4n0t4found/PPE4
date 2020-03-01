using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingModel
{
    public string Name { get; set; }
    public int FloorNumber { get; set; }

    public BuildingModel() { }
    public BuildingModel(string name, int floorNumber)
    {
        this.Name = name;
        this.FloorNumber = floorNumber;
    }
}
