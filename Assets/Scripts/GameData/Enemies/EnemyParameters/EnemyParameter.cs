using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParameter
{
    public EnemyParameter()
    {
        CalculatedValue = InitialValue;
    }

    public float InitialValue;
    public float CalculatedValue;
    protected EnemyParameterTypes type;

    public virtual void Calculate(float effectValue) { }

    public virtual void Reload() { }
}
