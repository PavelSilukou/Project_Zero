using UnityEngine;

public class Castle : GObject
{
    [SerializeField]
    private float health;

    private void Awake()
    {
        CastlesManager.Instance.ChangeHealth(GetHealth());
    }

    private int GetHealth()
    {
        return Mathf.CeilToInt(health);
    }

    public void AddHealth(float health)
    {
        this.health += health;
        CastlesManager.Instance.ChangeHealth(GetHealth());
    }

    public void SubHealth(float health)
    {
        this.health -= health;
        CastlesManager.Instance.ChangeHealth(GetHealth());
    }
}
