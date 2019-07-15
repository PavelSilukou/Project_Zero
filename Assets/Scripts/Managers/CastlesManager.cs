using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlesManager : MonoBehaviour
{
    public FormattedText healthText;

    private int currentHealth;

    public void ChangeHealth(int health)
    {
        currentHealth = health;
        OnHealthChanged();
    }

    private void SetHealthText()
    {
        healthText.SetValue(currentHealth);
    }

    // monobehaviour events

    private void Awake()
    {
        CreateInstance();
    }

    // events

    public delegate void HealthChangedHandler();
    public event HealthChangedHandler HealthChanged;

    public delegate void HealthEndedHandler();
    public event HealthEndedHandler HealthEnded;

    private void OnHealthChanged()
    {
        if (HealthChanged != null)
        {
            HealthChanged();
        }

        SetHealthText();

        if (currentHealth <= 0)
        {
            OnHealthEnded();
        }
    }

    private void OnHealthEnded()
    {
        if (HealthEnded != null)
        {
            HealthEnded();
        }
    }

    // singleton

    public static CastlesManager Instance;

    private void CreateInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (this == Instance)
        {
            Instance = null;
        }
    }
}
