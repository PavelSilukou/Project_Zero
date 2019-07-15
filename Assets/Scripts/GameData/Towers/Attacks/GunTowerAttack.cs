using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTowerAttack : Attack
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
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, step);
        RotateToTarget(targetEnemy.transform.position);
        if (transform.position == targetEnemy.transform.position)
        {
            targetEnemy.SetAttackEffects(attackEffects);
            Destroy(gameObject);
        }
    }

    protected void RotateToTarget(Vector3 target)
    {
        Vector3 vectorToTarget = target - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = q;
    }

    protected override void Awake()
    {
        speed = 3.0f;
        base.Awake();
    }
}
