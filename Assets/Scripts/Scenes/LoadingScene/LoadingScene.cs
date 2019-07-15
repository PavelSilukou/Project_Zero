using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : GameScene
{
    new private void Start()
    {
        StartCoroutine(LoadNextSceneAsync());
    }
}
