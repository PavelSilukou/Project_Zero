using System.Collections.Generic;

public class Attack : GObject
{
    protected float speed;

    protected List<AttackEffect> attackEffects = new List<AttackEffect>();

    public virtual void SetTarget(GObject target) { }

    public void AddAttackEffect(AttackEffect attackEffect)
    {
        attackEffects.Add(attackEffect);
    }

    protected virtual void Awake()
    {
        
    }
}
