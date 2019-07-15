using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpeedEnemyParameter : EnemyParameter
{
    public SpeedEnemyParameter()
    {
        type = EnemyParameterTypes.Speed;
    }

    public override void Calculate(float effectValue)
    {
        CalculatedValue = CalculatedValue * effectValue;
    }

    public override void Reload()
    {
        CalculatedValue = InitialValue;
    }
}