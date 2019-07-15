using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : Tile
{
    private TowerPanel towerPanel;
    private TowerTilePanel towerTilePanel;

    public void SetTower(Tower tower)
    {
        ShowSelectedInfo();
    }

    private void Awake()
    {
        towerPanel = FindObjectOfType<NewGameScene>().transform.GetComponentInChildren<TowerPanel>(true);
        towerTilePanel = FindObjectOfType<NewGameScene>().transform.GetComponentInChildren<TowerTilePanel>(true);
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
            towerPanel.SetTower(this, tower);
        }
        else
        {
            towerTilePanel.SetTowerTile(this);
        }
    }

    private Tower GetTower()
    {
        return GetComponentInChildren<Tower>();
    }
}
