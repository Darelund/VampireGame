using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : Damageable
{
    //Maybe use this one later, but for now Damagable object will have to do

    //[SerializeField] private event EventHandler<EventArgs> OnHealthChanged;
    //protected override void Awake()
    //{
    //    //maxHealth = 
    //    base.Awake();
    //}
    //private void Start()
    //{
    //    OnHealthChanged?.Invoke(this, EventArgs.Empty);
    //}

    //public override void TakeDamage(float dmg)
    //{
    //    base.TakeDamage(dmg);
    //    OnHealthChanged?.Invoke(this, EventArgs.Empty);
    //}
    //public override void Died()
    //{
    //}
    //public override void Init()
    //{
    //    base.Init();
    //}
}
