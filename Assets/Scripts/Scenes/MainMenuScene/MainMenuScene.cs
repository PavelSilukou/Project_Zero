using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScene : GameScene
{
    public void LoadUpgradesScene()
    {
        LoadNextScene(Upgrades);
    }

    public void LoadNewGameScene()
    {
        LoadNextScene(SelectLevel);
    }

    public void LoadTowerLibraryScene()
    {
        LoadNextScene(TowerLibrary);
    }
}
