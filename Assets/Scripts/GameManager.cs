using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    // Static singleton property.
    public static GameManager Instance { get; private set; }

    public static bool IsGameOver = false;

    public static int currentLevel;

    [SerializeField]
    public static float configWorldSpeed = 0.5f;
    public static float WorldSpeed
    {
        get
        {
            return configWorldSpeed * 0.1f;
        }
    }

    void Awake()
    {
        // Save a reference to the AudioManager component as our //singleton instance.
        Instance = this;
    }

    void Start()
    {
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentLevel = Array.IndexOf(StaticData.Scenes, scene.name);

        IsGameOver = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            LoadNextScene();
    }

    public static void LoadNextScene(bool isReload = false)
    {
        if (currentLevel >= StaticData.Scenes.Length - 1 && !isReload)
        {
            return;
        }
        string nextSceneName = StaticData.Scenes[isReload ? currentLevel : currentLevel + 1];
        SceneManager.LoadSceneAsync(nextSceneName);
    }

}
