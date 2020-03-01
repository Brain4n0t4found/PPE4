// Using System
using System;

[Serializable]
public class ContainerModel
{
    #region Properties
    public string Name { get; set; }
    public int StorageCapacity { get; set; }
    #endregion

    #region Constructors
    public ContainerModel() { }
    public ContainerModel(string name, int storageCapactity)
    {
        this.Name = name;
        this.StorageCapacity = storageCapactity;
    }
    #endregion
}
