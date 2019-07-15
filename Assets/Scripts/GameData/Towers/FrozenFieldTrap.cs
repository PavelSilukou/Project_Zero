using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenFieldTrap : Tower
{
    protected override void Awake()
    {
        towerBlockData = new FrozenFieldTrapBlockData();
        base.Awake();
    }

    protected override void PausableUpdate()
    {
        base.PausableUpdate();

        List<Enemy> targetEnemies = GetEnemiesInRadius();
        if (targetEnemies.Count > 0)
        {
            Attack(targetEnemies);
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

    private void Attack(List<Enemy> enemies)
    {
        if (DoAttack())
        {
            Debug.Log("shoot");
            foreach (var enemy in enemies)
            {
                var newAttack = Instantiate(attack);
                newAttack.transform.position = gameObject.transform.position;
                newAttack.SetTarget(enemy);

                var newAttackEffects = new List<AttackEffect>();
                foreach (var attackEffect in attackEffects)
                {
                    newAttack.AddAttackEffect(new AttackEffect(attackEffect));
                }
            }
        }
    }
}
