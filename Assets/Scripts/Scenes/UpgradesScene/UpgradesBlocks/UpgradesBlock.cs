using UnityEngine;
using UnityEngine.UI;

public class UpgradesBlock : MonoBehaviour
{
    public BlockData Data { get; protected set; }

    private UpgradesBlocksArea upgradesBlocksArea;
    private FormattedText text;

    public void UpgradeBlock()
    {
        SetBlockLevel();
    }

    private void Awake()
    {
        upgradesBlocksArea = GetComponentInParent<UpgradesBlocksArea>();
        gameObject.GetComponent<Button>().onClick.AddListener(SelectBlock);

        text = gameObject.GetComponentInChildren<FormattedText>();
    }

    private void Start()
    {
        SetBlockLevel();
    }

    private void SetBlockLevel()
    {
        text.SetValue(Data.CurrentMaxLevel);
    }

    private void SelectBlock()
    {
        upgradesBlocksArea.SelectBlock(this);
    }
}
