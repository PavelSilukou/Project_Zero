using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesBlocksInfoPanel : MonoBehaviour
{
    public FormattedText blockTitle;
    public List<FormattedText> modifiersTexts;

    private BlockData selectedBlock;

    private UpgradesScene upgradesScene;
    private Button upgradeButton;

    private void Awake()
    {
        upgradesScene = GetComponentInParent<UpgradesScene>();
        upgradeButton = GetComponentInChildren<Button>();

        SetUpgradeButtonState();
    }

    public void SelectBlock(BlockData data)
    {
        selectedBlock = data;
        ShowBlockInfo();
        gameObject.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void ClickUpgradeButton()
    {
        upgradeButton.interactable = false;
        upgradesScene.UpgradeBlock(selectedBlock);
        ShowBlockInfo();
        SetUpgradeButtonState();
    }

    private void SetUpgradeButtonState()
    {
        upgradeButton.interactable = UserProgress.GetUpgradePoints() != 0;
        
    }

    private void ShowBlockInfo()
    {
        blockTitle.SetValue(selectedBlock.LocalizedName);
        var modifiersDescriptions = selectedBlock.GetModifiersDescriptions();
        for (int modifierIndex = 0; modifierIndex < modifiersDescriptions.Count; modifierIndex++)
        {
            modifiersTexts[modifierIndex].SetValue(modifiersDescriptions[modifierIndex]);
        }
    }
}
