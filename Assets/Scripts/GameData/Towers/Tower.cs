using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : GObject
{
    public float rotationSpeed;
    public float attackRadius;
    public float currentReloadAttackTime;

    public Attack attack;
    public List<AttackEffect> attackEffects;

    public ReloadTimeTowerParameter reloadTime;
    private List<TowerParameter> parameters;
    private List<BlockData> blocks;

    protected BlockData towerBlockData;

    protected virtual void Awake()
    {
        currentReloadAttackTime = 0.0f;
        parameters = new List<TowerParameter>();
        parameters.Add(reloadTime);
        blocks = new List<BlockData>();
        blocks.Add(towerBlockData);
        RecalculateParameters();
    }

    protected override void PausableUpdate()
    {
        Reload();
    }

    private void Reload()
    {
        if (currentReloadAttackTime >= 0.0f)
        {
            currentReloadAttackTime -= Time.deltaTime;
        }
    }

    protected bool DoAttack()
    {
        if (currentReloadAttackTime <= 0.0f)
        {
            currentReloadAttackTime += reloadTime.CalculatedValue;
            return true;
        }
        else
        {
            return false;
        }
    }

    protected bool RotateToTarget(Vector3 target)
    {
        Vector3 vectorToTarget = target - gameObject.transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, q, Time.deltaTime * rotationSpeed);

        vectorToTarget.Normalize();
        return vectorToTarget == gameObject.transform.right;
    }

    protected void RecalculateParameters()
    {
        var totalModifiersValues = new Dictionary<ModifierType, float>();

        var blockModifiersValues = towerBlockData.GetModifiersValues();
        foreach (KeyValuePair<ModifierType, float> modifierValue in blockModifiersValues)
        {
            totalModifiersValues.Add(modifierValue.Key, modifierValue.Value);
        }

        foreach (KeyValuePair<ModifierType, float> modifierValue in totalModifiersValues)
        {
            switch (modifierValue.Key)
            {
                case ModifierType.TowerReloadTime:
                    reloadTime.Upgrade(modifierValue.Value);
                    break;
            }
        }
    }

    public List<string> GetParametersDescriptions()
    {
        var descriptions = new List<string>();
        descriptions.Add(string.Format(reloadTime.LocalizedName, reloadTime.CalculatedValue));
        return descriptions;
    }

    public List<BlockData> GetBlocks()
    {
        return blocks;
    }

    public void Upgrade()
    {
        RecalculateParameters();
    }
}
