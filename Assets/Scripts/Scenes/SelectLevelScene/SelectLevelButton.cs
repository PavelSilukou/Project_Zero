using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelButton : MonoBehaviour
{
    public Map mapPrefab;

    private SelectLevelScene scene;

    private void Awake()
    {
        scene = GetComponentInParent<SelectLevelScene>();

        gameObject.GetComponent<Button>().onClick.AddListener(SelectLevel);
    }

    private void SelectLevel()
    {
        scene.SelectGameLevel(mapPrefab);
    }
}
