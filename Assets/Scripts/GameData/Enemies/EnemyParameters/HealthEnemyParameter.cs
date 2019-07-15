using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HealthEnemyParameter : EnemyParameter
{
    public HealthEnemyParameter()
    {
        type = EnemyParameterTypes.Health;
    }

    public override void Calculate(float effectValue)
    {
        CalculatedValue = CalculatedValue - effectValue;
    }

    public override void Reload()
    {
    }
}
