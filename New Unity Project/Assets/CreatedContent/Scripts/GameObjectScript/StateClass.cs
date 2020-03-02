// Using System
using System;

// Using Unity
using UnityEngine;

#region Classe de l'objet final
[Serializable]
public class StateClass
{
    #region Properties
    public string Name { get; set; }
    public int DamageRate { get; set; }

    private GameObject EntityAttachedTo { get; set; }
    private MainCharacterScript MainCharacterScript { get; set; }
    private EnemyScript EnemyScript { get; set; }
    #endregion

    #region Constructor
    public void Initialize(string name, int damageRate, GameObject entityAttachedTo)
    {
        this.Name = name;
        this.DamageRate = damageRate;
        this.EntityAttachedTo = entityAttachedTo;

        if (this.EntityAttachedTo.GetComponent<EnemyScript>() != null) 
        {
            this.MainCharacterScript = this.EntityAttachedTo.GetComponent<MainCharacterScript>();
        }
        else if (this.EntityAttachedTo.GetComponent<MainCharacterScript>() != null)
        {
            this.EnemyScript = this.EntityAttachedTo.GetComponent<EnemyScript>();
        }
    }
    #endregion

    #region Functions
    public void ApplyDamages()
    {
        if (EnemyScript != null)
        {
            MainCharacterScript.Health -= DamageRate;
        }
        else if (MainCharacterScript != null)
        {
            EnemyScript.Health -= DamageRate;
        }
    }
    #endregion
}
#endregion

#region Classe modèle
[Serializable]
public class StateModel
{
    #region Properties
    public string Name { get; set; }
    public int DamageRate { get; set; }
    #endregion

    #region Constructors
    public StateModel() { }
    public StateModel(string name, int damageRate)
    {
        this.Name = name;
        this.DamageRate = damageRate;
    }
    #endregion
}
#endregion