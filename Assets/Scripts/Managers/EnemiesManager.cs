using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class EnemiesManager : MonoBehaviour
{
    private List<EnemyRule> enemiesRules;
    private List<Enemy> waitingEnemies = new List<Enemy>();
    private List<Enemy> enemiesInWave = new List<Enemy>();

    private Vector3 waitingEnemyPosition = new Vector3(-999, -999);

    public void SetEnemiesRules(List<EnemyRule> enemiesRules)
    {
        this.enemiesRules = enemiesRules;
    }

    public void EnemyIsDead(Enemy enemy)
    {
        enemiesInWave.Remove(enemy);
        Destroy(enemy.gameObject);

        if (enemiesInWave.Count == 0 && waitingEnemies.Count == 0)
        {
            OnEnemiesIsOver();
        }
    }

    public Enemy GetEnemy()
    {
        if (waitingEnemies.Count == 0)
        {
            return null;
        }

        // random
        var randomWaitingEnemyIndex = UnityEngine.Random.Range(0, waitingEnemies.Count);
        var randomWaitingEnemy = waitingEnemies[randomWaitingEnemyIndex];
        waitingEnemies.Remove(randomWaitingEnemy);
        enemiesInWave.Add(randomWaitingEnemy);
        return randomWaitingEnemy;
    }

    public List<Enemy> GetEnemiesInWave()
    {
        return enemiesInWave;
    }

    private void StartNewWave(int waveNumber)
    {
        enemiesInWave.Clear();
        waitingEnemies.Clear();
        foreach (var enemyRule in enemiesRules)
        {
            if (enemyRule.startWave <= waveNumber)
            {
                for (var enemyIndex = 0; enemyIndex < enemyRule.countPerWave; enemyIndex++)
                {
                    var enemy = Instantiate(enemyRule.enemy, transform);
                    enemy.SetActive(false);
                    enemy.transform.position += waitingEnemyPosition;
                    waitingEnemies.Add(enemy);
                }
            }
        }
    }

    // monobehaviour events

    private void Update()
    {
        enemiesInWave = enemiesInWave.OrderBy(element => element.GetDistanceToCastle()).ToList();
    }

    private void Awake()
    {
        CreateInstance();
        GameDirector.Instance.NewWaveStarted += new GameDirector.NewWaveStartedHandler(StartNewWave);
    }

    // events

    public delegate void EnemiesIsOverHandler();
    public event EnemiesIsOverHandler EnemiesIsOver;

    private void OnEnemiesIsOver()
    {
        if (EnemiesIsOver != null)
        {
            EnemiesIsOver();
        }
    }

    // singleton

    public static EnemiesManager Instance;

    private void CreateInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (this == Instance)
        {
            Instance = null;
        }
    }
}

[Serializable]
public class EnemyRule
{
    public Enemy enemy;
    public int startWave;
    public int countPerWave;
}