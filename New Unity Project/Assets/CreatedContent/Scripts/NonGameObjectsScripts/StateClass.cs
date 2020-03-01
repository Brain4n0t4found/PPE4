// Using System
using System;

// Using Unity
using UnityEngine;

[Serializable]
public class StateClass : MonoBehaviour
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

        if (this.EntityAttachedTo.GetComponent<MainCharacterScript>() != null)
        {
            this.MainCharacterScript = this.EntityAttachedTo.GetComponent<MainCharacterScript>();
        }
        else if (this.EntityAttachedTo.GetComponent<EnemyScript>() != null)
        {
            this.EnemyScript = this.EntityAttachedTo.GetComponent<EnemyScript>();
        }
    }
    #endregion

    #region Functions
    public void ApplyDamages()
    {
        if (MainCharacterScript != null)
        {
            MainCharacterScript.Health -= DamageRate;
        }
        else if (EnemyScript != null)
        {
            EnemyScript.Health -= DamageRate;
        }
    }
    #endregion
}
