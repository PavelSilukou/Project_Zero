using System.Collections.Generic;

public class BlockData : LocalizedObject
{
    protected int GlobalMaxLevel;
    protected BlockTypes Type;

    public List<Modifier> Modifiers { get; protected set; }

    public int CurrentMaxLevel
    {
        get
        {
            return UserProgress.GetBlockData(Type).level;
        }
    }

    public int CurrentLevel { get; protected set; }

    public void UpgradeCurrentMaxLevel()
    {
        UserProgress.IncreaseBlockDataLevel(Type);
    }

    public void UpgradeCurrentLevel()
    {
        CurrentLevel += 1;
    }

    public List<string> GetModifiersDescriptions()
    {
        var descriptions = new List<string>();
        foreach (var modifier in Modifiers)
        {
            descriptions.Add(string.Format(modifier.LocalizedName, modifier.Value * CurrentLevel));
        }
        return descriptions;
    }

    public Dictionary<ModifierType, float> GetModifiersValues()
    {
        var modifiersValues = new Dictionary<ModifierType, float>();
        foreach (var modifier in Modifiers)
        {
            modifiersValues.Add(modifier.Type, modifier.Value * CurrentLevel);
        }
        return modifiersValues;
    }

    public BlockData()
    {
        CurrentLevel = 1;
    }
}