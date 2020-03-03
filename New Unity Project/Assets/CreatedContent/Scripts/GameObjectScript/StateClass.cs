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
            this.EnemyScript = this.EntityAttachedTo.GetComponent<EnemyScript>();
        }
        else if (this.EntityAttachedTo.GetComponent<MainCharacterScript>() != null)
        {
            this.MainCharacterScript = this.EntityAttachedTo.GetComponent<MainCharacterScript>();
        }
    }
    #endregion

    #region Functions
    /// <summary>
    /// Application des dégats de la classe, tue l'entité liée si elle n'a plus suffisamment de PV
    /// </summary>
    public void ApplyDamages()
    {
        if (EnemyScript != null)
        {
            if (EnemyScript.Health > DamageRate)
            {
                EnemyScript.Health -= DamageRate;
            }
            else
            {
                UnityEngine.Object.Destroy(EnemyScript.gameObject);
            }
        }
        else if (MainCharacterScript != null)
        {
            if (MainCharacterScript.Health > DamageRate)
            {
                MainCharacterScript.Health -= DamageRate;
            }
            else
            {
                UnityEngine.Object.Destroy(MainCharacterScript.gameObject);
            }
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