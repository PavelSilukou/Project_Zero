using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : GObject
{
    public List<Route> routes;

    private float refreshTime = 0.0f;

    private void Awake()
    {
        GameDirector.Instance.NewWaveStarted += new GameDirector.NewWaveStartedHandler(StartWave);
    }

    protected override void PausableUpdate()
    {
        if (refreshTime <= 0.0f)
        {
            refreshTime += CreateEnemy();
        }
        else
        {
            refreshTime -= Time.deltaTime;
        }
    }

    private void StartWave(int waveNumber)
    {
        refreshTime = 0.0f;
    }

    private float CreateEnemy()
    {
        var newEnemy = EnemiesManager.Instance.GetEnemy();
        if (newEnemy != null)
        {
            var randomRouteNumber = Random.Range(0, routes.Count);
            var timeCreation = newEnemy.GetTimeCreation();
            newEnemy.transform.parent = transform;
            newEnemy.SetRoute(routes[randomRouteNumber]);
            newEnemy.SetActive(true);
            return timeCreation;
        }
        return 0.0f;
    }
}
