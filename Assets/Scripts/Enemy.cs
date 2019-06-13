﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    [SerializeField]
    private CanvasGroup healthGroup = null;

    private IState currentState = null;

    public float MyAttackRange { get; set; }

    public float MyAttackTime { get; set; }

    protected void Awake()
    {
        MyAttackRange = 1;
        ChangeState(new IdleState());
    }

    protected override void Update()
    {
        if (IsAlive)
        {
            if (!IsAttacking)
            {
                MyAttackTime += Time.deltaTime;
            }
            currentState.Update();
        }

        base.Update();
    }

    public override Transform Select()
    {
        healthGroup.alpha = 1;
        return base.Select();
    }

    public override void DeSelect()
    {
        healthGroup.alpha = 0;
        base.DeSelect();
    }

    public override void TakeDamage(float damage, Transform source)
    {
        base.TakeDamage(damage, source);

        onHealthChanged(health.MyCurrentValue);
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }
}
