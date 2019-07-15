using System;

[Serializable]
public class AttackEffect
{
    public EnemyParameterTypes type;
    public EffectTypes effectType;

    public float InitialEffectValue;
    public float CalculatedEffectValue;

    public float InitialDurationValue;
    public float CalculatedDurationValue;

    private float currentDuration;

    public AttackEffect(float initialEffectValue, float initialDurationValue)
    {
        CalculatedEffectValue = initialEffectValue;
        CalculatedDurationValue = initialDurationValue;
        currentDuration = CalculatedDurationValue;
    }

    public AttackEffect(AttackEffect other)
    {
        type = other.type;
        effectType = other.effectType;
        CalculatedEffectValue = other.CalculatedEffectValue;
        CalculatedDurationValue = other.CalculatedDurationValue;
        currentDuration = CalculatedDurationValue;
    }

    public bool CalculateDuration(float deltaTime)
    {
        currentDuration -= deltaTime;
        return currentDuration <= 0;
    }

    public void UpgradeEffectValue(float value)
    {
        CalculatedEffectValue = InitialEffectValue + InitialEffectValue * value;
    }

    public void UpgradeDurationValue(float value)
    {
        CalculatedDurationValue = InitialDurationValue + InitialDurationValue * value;
    }
}
