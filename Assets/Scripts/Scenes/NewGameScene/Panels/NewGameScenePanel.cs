using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameScenePanel : MonoBehaviour
{
    private static NewGameScenePanel activePanel;
    
    protected virtual void ShowPanel()
    {
        if (activePanel != null)
        {
            activePanel.HidePanel();
        }
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
        gameObject.GetComponent<CanvasGroup>().interactable = true;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = true;
        activePanel = this;
    }

    protected virtual void HidePanel()
    {
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().interactable = false;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
