using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTower : Tower
{
    private Enemy targetEnemy;

    protected override void Awake()
    {
        towerBlockData = new GunTowerBlockData();
        base.Awake();
    }

    protected override void PausableUpdate()
    {
        base.PausableUpdate();

        List<Enemy> targetEnemies = GetEnemiesInRadius();
        if (targetEnemies.Count > 0)
        {
            if (targetEnemy == null)
            {
                targetEnemy = targetEnemies[0];
            }
            else
            {
                if (!targetEnemies.Contains(targetEnemy))
                {
                    targetEnemy = targetEnemies[0];
                }
            }
        }

        if (targetEnemy)
        {
            if (RotateToTarget(targetEnemy.transform.position))
            {
                Attack();
            }
        }
    }

    private List<Enemy> GetEnemiesInRadius()
    {
        List<Enemy> enemies = EnemiesManager.Instance.GetEnemiesInWave();

        List<Enemy> targetEnemies = new List<Enemy>();
        foreach (var enemy in enemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) <= attackRadius)
            {
                targetEnemies.Add(enemy);
            }
        }
        return targetEnemies;
    }

    private void Attack()
    {
        if (DoAttack())
        {
            Debug.Log("shoot");
            var newAttack = Instantiate(attack);
            newAttack.transform.position = gameObject.transform.position;
            newAttack.SetTarget(targetEnemy);

            var newAttackEffects = new List<AttackEffect>();
            foreach (var attackEffect in attackEffects)
            {
                newAttack.AddAttackEffect(new AttackEffect(attackEffect));
            }
        }
    }
}
