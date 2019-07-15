using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GObject : MonoBehaviour
{
    private bool isPause = false;

    public bool GetPauseState()
    {
        return isPause;
    }

    public void SetPauseState(bool state)
    {
        isPause = state;
    }

    private void Awake()
    {
        var parent = GetComponentInParent<GObject>();
        if (parent != null)
        {
            isPause = parent.GetPauseState();
        }
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

    protected virtual void PausableUpdate() { }

    private void Update()
    {
        if (!isPause)
        {
            PausableUpdate();
        }
    }
    
    public string LocalizedName
    {
        get
        {
            return Localization.GetLocalizedTextByType(this.GetType());
        }
    }
}