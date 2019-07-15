using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradesScene : GameScene
{
    private UpgradesBlocksInfoPanel upgradesBlocksInfoPanel;
    public FormattedText upgradePoints;
    private UpgradesBlocksArea upgradesBlocksArea;

    private void Awake()
    {
        upgradesBlocksInfoPanel = GetComponentInChildren<UpgradesBlocksInfoPanel>();
        upgradesBlocksArea = GetComponentInChildren<UpgradesBlocksArea>();

        UpdateUpgradePointsText();
    }

    public void SelectBlock(BlockData data)
    {
        upgradesBlocksInfoPanel.SelectBlock(data);
    }

    public void UpgradeBlock(BlockData data)
    {
        UserProgress.DecreaseUpgradePoints();
        data.UpgradeCurrentMaxLevel();
        UserProgress.Save();
        upgradesBlocksArea.UpgradeBlock();
        UpdateUpgradePointsText();
    }

    private void UpdateUpgradePointsText()
    {
        upgradePoints.SetValue(UserProgress.GetUpgradePoints());
    }
}
