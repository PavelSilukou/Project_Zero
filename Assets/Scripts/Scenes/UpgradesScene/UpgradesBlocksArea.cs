using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesBlocksArea : MonoBehaviour
{
    private UpgradesScene upgradesScene;
    private UpgradesBlock selectedBlock;

    private void Awake()
    {
        upgradesScene = GetComponentInParent<UpgradesScene>();
    }

    public void SelectBlock(UpgradesBlock block)
    {
        selectedBlock = block;
        upgradesScene.SelectBlock(block.Data);
    }

    public void UpgradeBlock()
    {
        selectedBlock.UpgradeBlock();
    }
}
