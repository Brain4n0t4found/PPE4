using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloorModel
{
    public int FloorNumber { get; set; }

    public FloorModel() { }
    public FloorModel(int floorNumber)
    {
        this.FloorNumber = floorNumber;
    }
}
