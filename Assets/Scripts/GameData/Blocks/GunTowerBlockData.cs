using System.Collections.Generic;

public class GunTowerBlockData : BlockData
{
    public GunTowerBlockData()
    {
        Type = BlockTypes.GunTower;

        Modifiers = new List<Modifier>
        {
            new TowerReloadTimeModifier(-0.1f)
        };
    }
}
