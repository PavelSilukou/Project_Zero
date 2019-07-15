using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    protected const string Start = "start";
    protected const string StartLanguages = "start_languages";
    protected const string Menu = "menu";
    protected const string Loading = "loading";
    protected const string Upgrades = "upgrades";
    protected const string SelectLevel = "select_level";
    protected const string NewGame = "new_game";
    protected const string GameOver = "game_over";
    protected const string TowerLibrary = "tower_library";

    private static string NextScene;

    protected IEnumerator LoadNextScene(string sceneName)
    {
        NextScene = sceneName;
        SceneManager.LoadScene(Loading);
        return null;
    }

    protected IEnumerator LoadNextSceneAsync(string sceneName = null)
    {
        sceneName = string.IsNullOrEmpty(sceneName) ? NextScene : sceneName;
        var async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}