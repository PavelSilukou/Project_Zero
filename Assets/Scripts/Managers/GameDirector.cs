using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    private Map map;

    public FormattedText wavesText;

    private int waveNumber = 0;
    private GameDirectorStates state = GameDirectorStates.Idle;

    public void StartPauseClick()
    {
        switch (state)
        {
            case GameDirectorStates.Idle:
                StartNewWave();
                break;
            case GameDirectorStates.Paused:
                UnpauseGame();
                break;
            case GameDirectorStates.Unpaused:
                PauseGame();
                break;
        }
    }

    private void SetWavesText()
    {
        wavesText.SetValue(waveNumber);
    }

    private void PauseGame()
    {
        OnPauseSet();
        state = GameDirectorStates.Paused;
    }

    private void UnpauseGame()
    {
        OnUnPauseSet();
        state = GameDirectorStates.Unpaused;
    }

    private void StartNewWave()
    {
        waveNumber++;
        SetWavesText();
        OnNewWaveStarted();
        UnpauseGame();
    }

    private void EndWave()
    {
        OnPauseSet();
        state = GameDirectorStates.Idle;
    }

    private void EndGame()
    {
        OnPauseSet();
        state = GameDirectorStates.EndGame;
        FindObjectOfType<NewGameScene>().LoadGameOverScene();
    }

    // monobehaviour events

    private void Awake()
    {
        CreateInstance();

        map = Instantiate(DataManager.selectedMap);
    }

    private void Start()
    {
        SetWavesText();

        CastlesManager.Instance.HealthEnded += new CastlesManager.HealthEndedHandler(EndGame);
        EnemiesManager.Instance.EnemiesIsOver += new EnemiesManager.EnemiesIsOverHandler(EndWave);
    }

    // events

    public delegate void PauseSetHandler();
    public event PauseSetHandler PauseSet;

    private void OnPauseSet()
    {
        if (PauseSet != null)
        {
            PauseSet();
        }
    }

    public delegate void UnPauseSetHandler();
    public event UnPauseSetHandler UnPauseSet;

    private void OnUnPauseSet()
    {
        if (UnPauseSet != null)
        {
            UnPauseSet();
        }
    }

    public delegate void NewWaveStartedHandler(int waveNumber);
    public event NewWaveStartedHandler NewWaveStarted;

    private void OnNewWaveStarted()
    {
        if (NewWaveStarted != null)
        {
            NewWaveStarted(waveNumber);
        }
    }

    // singleton

    public static GameDirector Instance;

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

    public enum GameDirectorStates
    {
        Idle,
        Paused,
        Unpaused,
        EndGame
    }
}
