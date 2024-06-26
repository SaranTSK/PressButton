using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public const int MAX_LEVEL = 100;

    public SpawnManager SpawnManager => spawnManager;
    [SerializeField] private SpawnManager spawnManager;
    public GameplayManager GameplayManager => gameplayManager;
    [SerializeField] private GameplayManager gameplayManager;
    public CameraManager CameraManager => cameraManager;
    [SerializeField] private CameraManager cameraManager;
    public LevelManager LevelManager => levelManager;
    [SerializeField] private LevelManager levelManager;
    public UIManager UIManager => uiManager;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Initialize();
    }

    private void OnApplicationQuit()
    {
        Terminate();        
    }

    private void Initialize()
    {
        SaveManager.RemoveSaveGame();
        SaveManager.CreateSaveGame();

        spawnManager?.Initialize();
        gameplayManager?.Initialize();
        levelManager?.Initialize();
        uiManager?.Initialize();
    }

    private void Terminate()
    {
        spawnManager?.Termiante();
        gameplayManager?.Terminate();
        levelManager?.Terminate();
        uiManager?.Terminate();
    }

    public int GetMaxGameLevel()
    {
        return MAX_LEVEL;
    }
}
