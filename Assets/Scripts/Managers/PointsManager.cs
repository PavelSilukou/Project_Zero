using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField]
    private float points;

    public FormattedText pointsText;

    private int GetPoints()
    {
        return Mathf.FloorToInt(points);
    }

    public void AddPoints(float value)
    {
        points += value;
        OnPointsChanged();
    }

    public void SubPoints(float value)
    {
        points -= value;
        OnPointsChanged();
    }

    private void SetPointsText()
    {
        pointsText.SetValue(GetPoints());
    }

    // monobehaviour events

    private void Awake()
    {
        CreateInstance();
        OnPointsChanged();
    }

    // events

    public delegate void PointsChangedHandler();
    public event PointsChangedHandler PointsChanged;

    private void OnPointsChanged()
    {
        if (PointsChanged != null)
        {
            PointsChanged();
        }

        SetPointsText();
    }

    // singleton

    public static PointsManager Instance;

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
