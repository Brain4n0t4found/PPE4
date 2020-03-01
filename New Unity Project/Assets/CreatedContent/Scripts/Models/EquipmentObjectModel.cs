// Using System
using System;

[Serializable]
public class EquipmentObjectModel
{
    #region Properties
    public string Name { get; set; }
    #endregion

    #region Constructors
    public EquipmentObjectModel() { }
    public EquipmentObjectModel(string name)
    {
        this.Name = name;
    }
    #endregion
}
