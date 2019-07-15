using UnityEngine;

public class NewGameScene : GameScene
{
    public void LoadGameOverScene()
    {
        LoadNextScene(GameOver);
    }
}