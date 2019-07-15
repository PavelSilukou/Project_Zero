public static class UserProgress
{
    private static UserProgressData Data { get; set; }

    public static void Init()
    {
        Data = new UserProgressIO().Read();
        Save();
    }

    public static void Save()
    {
        if (Data != null)
        {
            new UserProgressIO().Write(Data);
        }
    }

    public static UserProgressBlockData GetBlockData(BlockTypes type)
    {
        return Data.blocks[type];
    }

    public static void IncreaseBlockDataLevel(BlockTypes type)
    {
        Data.blocks[type].level += 1;
    }

    public static int GetUpgradePoints()
    {
        return Data.upgradePoints;
    }

    public static void DecreaseUpgradePoints()
    {
        Data.upgradePoints -= 1;
    }
}