using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GObject
{
    public SpeedEnemyParameter speed;
    public HealthEnemyParameter health;
    public float damage;
    public float timeCreation;
    public float killPoints;

    private RouteIterator routeIterator;

    private List<AttackEffect> attackEffects;

    public void SetAttackEffects(List<AttackEffect> attackEffects)
    {
        this.attackEffects = attackEffects;
    }

    public void SetRoute(Route route)
    {
        routeIterator = route.GetIterator();
        transform.position = routeIterator.First();
        routeIterator.Next();
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetTimeCreation()
    {
        return timeCreation;
    }

    protected override void PausableUpdate()
    {
        if (attackEffects != null)
        {
            foreach (var attackEffect in attackEffects)
            {
                switch (attackEffect.type)
                {
                    case EnemyParameterTypes.Health:
                        {
                            health.Calculate(attackEffect.CalculatedEffectValue);

                            if (health.CalculatedValue <= 0)
                            {
                                EnemiesManager.Instance.EnemyIsDead(this);
                            }
                            break;
                        }
                    case EnemyParameterTypes.Speed:
                        {
                            speed.Calculate(attackEffect.CalculatedEffectValue);
                            break;
                        }
                }
                
            }

            attackEffects.RemoveAll(attackEffect => attackEffect.CalculateDuration(Time.deltaTime));
        }

        //health.Reload();

        Move();
        speed.Reload();
    }

    private void Move()
    {
        var step = speed.CalculatedValue * Time.deltaTime;
        transform.position = routeIterator.Next(transform.position, step);
        if (routeIterator.IsDone)
        {
            var castleTile = routeIterator.GetLastTile() as CastleTile;
            var castle = castleTile.GetCastle();
            castle.SubHealth(damage);
            EnemiesManager.Instance.EnemyIsDead(this);
        }
    }

    public float GetDistanceToCastle()
    {
        return routeIterator.Distance(transform.position);
    }
}
