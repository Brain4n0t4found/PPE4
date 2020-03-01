// Using System
using System;

[Serializable]
public class FloorModel
{
    #region Properties
    public int FloorNumber { get; set; }
    #endregion

    #region Constructors
    public FloorModel() { }
    public FloorModel(int floorNumber)
    {
        this.FloorNumber = floorNumber;
    }
    #endregion
}
