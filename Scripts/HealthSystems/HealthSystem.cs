using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MyBox;

public class HealthSystem : MonoBehaviour 
{
    [SerializeField]
    public float Health;
    [SerializeField]
    public AdaptiveValue MaxHealth = new AdaptiveValue();
    
    [SerializeField]
    UnityEvent OnHit;
    [SerializeField]
    UnityEvent OnHeal;
    [SerializeField]
    UnityEvent OnFull;
    [SerializeField]
    UnityEvent OnDeath;

    public bool IsImmune; //I frame
    public bool IsParry; //Hits can land, but you get blowback

    private void Awake()
    {
        MaxHealth.Initialize();
        //AdaptiveValue.AdaptiveLayer Layer = new AdaptiveValue.AdaptiveLayer();
        //MaxHealth.AddLayer(Layer);
        Health = MaxHealth.FullValue;
    }

    private void Update()
    {
        Debug.Log(MaxHealth.FullValue);
    }

    public void SetIsImmuneTrue()
    {
        IsImmune = true;
    }
    public void SetIsImmuneFalse()
    {
        IsImmune = false;
    }
    public void SetIsParryTrue()
    {
        IsParry = true;
    }
    public void SetIsParryFalse()
    {
        IsParry = false;
    }

    public void Hurt(float Value)
    {
        if (!IsImmune)
        {
            Health -= Value;
            if (Health <= 0) 
            {
                OnDeath.Invoke(); 
                return;
            };
            OnHit.Invoke();
        }
    }
    public void Heal(float Value)
    {
        Health += Value;
        if (Health > MaxHealth.FullValue)
        {
            Health = MaxHealth.FullValue;
            OnFull.Invoke();
        }
        OnHeal.Invoke();
    }

    [ButtonMethod]
    public void TestDamage()
    {
        Hurt(5);
    }
}
