using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPanel : NewGameScenePanel
{
    public FormattedText trapTitle;
    public List<FormattedText> parametersTexts;

    public List<TowerBlock> blocks;

    private Tower selectedTower;
    private RouteTile routeTile;

    public void SetTower(RouteTile routeTile, Tower tower)
    {
        this.routeTile = routeTile;
        selectedTower = tower;
        var towerBlocks = selectedTower.GetBlocks();
        for (var blockIndex = 0; blockIndex < towerBlocks.Count; blockIndex++)
        {
            blocks[blockIndex].SetBlock(towerBlocks[blockIndex]);
        }

        ShowTowerInfo();
        ShowPanel();
    }

    private void ShowTowerInfo()
    {
        trapTitle.SetValue(selectedTower.LocalizedName);
        var parametersDescriptions = selectedTower.GetParametersDescriptions();
        for (int parameterIndex = 0; parameterIndex < parametersDescriptions.Count; parameterIndex++)
        {
            parametersTexts[parameterIndex].SetValue(parametersDescriptions[parameterIndex]);
        }
        for (var blockIndex = 0; blockIndex < blocks.Count; blockIndex++)
        {
            blocks[blockIndex].ShowInfo();
        }
    }

    public void UpgradeBlock()
    {
        selectedTower.Upgrade();
        ShowTowerInfo();
    }
}