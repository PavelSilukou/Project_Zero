using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouteTilePanel : NewGameScenePanel
{
    public Button frozenFieldTrapBtn;

    private RouteTile selectedTile;

    public Tower tower;

    private void Awake()
    {
        frozenFieldTrapBtn.onClick.AddListener(delegate { CreateTower(); });
    }

    public void SetTowerTile(RouteTile routeTile)
    {
        selectedTile = routeTile;
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
