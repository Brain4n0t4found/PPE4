using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ContainerModel
{
    public string Name { get; set; }
    public int StorageCapacity { get; set; }

    public ContainerModel() { }
    public ContainerModel(string name, int storageCapactity)
    {
        this.Name = name;
        this.StorageCapacity = storageCapactity;
    }
}
