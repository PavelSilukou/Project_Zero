using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteTile : Tile
{
    private TrapPanel trapPanel;
    private RouteTilePanel routeTilePanel;

    public void SetTower(Tower tower)
    {
        ShowSelectedInfo();
    }

    private void Awake()
    {
        trapPanel = FindObjectOfType<NewGameScene>().transform.GetComponentInChildren<TrapPanel>(true);
        routeTilePanel = FindObjectOfType<NewGameScene>().transform.GetComponentInChildren<RouteTilePanel>(true);
    }

    private void OnMouseDown()
    {
        ShowSelectedInfo();
    }

    private void ShowSelectedInfo()
    {
        var tower = GetTower();
        if (tower != null)
        {
            trapPanel.SetTower(this, tower);
        }
        else
        {
            routeTilePanel.SetTowerTile(this);
        }
    }

    private Tower GetTower()
    {
        return GetComponentInChildren<Tower>();
    }
}
