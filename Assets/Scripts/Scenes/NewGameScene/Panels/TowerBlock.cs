using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBlock : MonoBehaviour
{
    public Button button;
    public FormattedText text;

    private BlockData block;

    public void SetBlock(BlockData block)
    {
        this.block = block;
        button.onClick.AddListener(Upgrade);
    }

    public void ShowInfo()
    {
        text.SetValue(block.CurrentLevel);
    }

    public void Upgrade()
    {
        block.UpgradeCurrentLevel();
        text.SetValue(block.CurrentLevel);
        GetComponentInParent<TowerPanel>().UpgradeBlock();
    }
}
