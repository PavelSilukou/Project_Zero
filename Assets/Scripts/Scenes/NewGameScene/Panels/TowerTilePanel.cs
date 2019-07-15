using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerTilePanel : NewGameScenePanel
{
    public Button normalTowerBtn;

    private TowerTile selectedTile;

    public Tower tower;

    private void Awake()
    {
        normalTowerBtn.onClick.AddListener(delegate { CreateTower(); });
    }

    public void SetTowerTile(TowerTile towerTile)
    {
        selectedTile = towerTile;
        ShowPanel();
    }

    private void CreateTower()
    {
        // simplify
        var t = Instantiate(tower, selectedTile.transform);
        var towerCost = CostManager.TowerCost;
        PointsManager.Instance.SubPoints(towerCost);
        selectedTile.SetTower(tower);
    }
}
