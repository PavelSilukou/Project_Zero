using System;

public class SelectLevelScene : GameScene
{
    public void SelectGameLevel(Map map)
    {
        DataManager.selectedMap = map;
    }

    public void StartGame()
    {
        StartCoroutine(LoadNextSceneAsync(NewGame));
    }
}
