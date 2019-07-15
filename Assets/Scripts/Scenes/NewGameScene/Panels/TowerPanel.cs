using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : NewGameScenePanel
{
    public FormattedText towerTitle;
    public List<FormattedText> parametersTexts;

    public List<TowerBlock> blocks;

    private Tower selectedTower;
    private TowerTile towerTile;

    public void SetTower(TowerTile towerTile, Tower tower)
    {
        this.towerTile = towerTile;
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
        towerTitle.SetValue(selectedTower.LocalizedName);
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
