using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : GameScene
{
    private void Awake()
    {
        Settings.Init();
        Localization.Init();
        UserProgress.Init();
    }

    new private void Start()
    {
        if (Settings.Data.isLocaleSet)
        {
            StartCoroutine(LoadNextSceneAsync(Menu));
        }
        else
        {
            StartCoroutine(LoadNextSceneAsync(StartLanguages));
        }
    }
}
