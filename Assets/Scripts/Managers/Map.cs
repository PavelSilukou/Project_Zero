using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Map : MonoBehaviour
{
    public List<EnemyRule> enemiesRules;

    private void Awake()
    {
        GameDirector.Instance.PauseSet += new GameDirector.PauseSetHandler(Pause);
        GameDirector.Instance.UnPauseSet += new GameDirector.UnPauseSetHandler(Unpause);
    }

    private void Start()
    {
        EnemiesManager.Instance.SetEnemiesRules(enemiesRules);
    }

    private void Unpause()
    {
        var children = GetComponentsInChildren<GObject>(true);
        foreach (var child in children)
        {
            child.SetPauseState(false);
        }
    }

    private void Pause()
    {
        var children = GetComponentsInChildren<GObject>(true);
        foreach (var child in children)
        {
            child.SetPauseState(true);
        }
    }
}
