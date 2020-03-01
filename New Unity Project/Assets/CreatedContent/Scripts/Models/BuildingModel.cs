// Using System
using System;

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
