using System;
using System.Collections.Generic;

[Serializable]
public class UserProgressData
{
    public int upgradePoints;
    public Dictionary<BlockTypes, UserProgressBlockData> blocks;
    public List<UserProgressTowerLibraryData> towerLibrary;

    public UserProgressData()
    {
        upgradePoints = 2;

        blocks = new Dictionary<BlockTypes, UserProgressBlockData>();
        blocks.Add(BlockTypes.GunTower, new UserProgressBlockData
        {
            level = 1
        });
        blocks.Add(BlockTypes.FrozenFieldTrap, new UserProgressBlockData
        {
            level = 1
        });

        towerLibrary = new List<UserProgressTowerLibraryData>();
        towerLibrary.Add(new UserProgressTowerLibraryData
        {
            mainBlock = BlockTypes.GunTower
        });
    }
}

[Serializable]
public class UserProgressBlockData
{
    public int level;
}

[Serializable]
public class UserProgressTowerLibraryData
{
    public BlockTypes mainBlock;
    public BlockTypes block1;
    public BlockTypes block2;
    public BlockTypes block3;
}