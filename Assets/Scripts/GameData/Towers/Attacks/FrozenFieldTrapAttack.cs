using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenFieldTrapAttack : Attack
{
    private Enemy targetEnemy;

    public override void SetTarget(GObject target)
    {
        targetEnemy = target.GetComponent<Enemy>();
    }

    protected override void PausableUpdate()
    {
        if (targetEnemy == null || targetEnemy.gameObject == null)
        {
            Destroy(gameObject);
            return;
        }
        
        targetEnemy.SetAttackEffects(attackEffects);
        Destroy(gameObject);
    }

    protected override void Awake()
    {
        base.Awake();
    }
}
