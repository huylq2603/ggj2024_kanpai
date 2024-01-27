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

    public static int currentLevel;

    void Awake()
    {
        // Save a reference to the AudioManager component as our //singleton instance.
        Instance = this;
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        GameManager.isInputEnable = true;
        currentLevel = Array.IndexOf(StaticData.Scenes, scene.name);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0))
            LoadNextScene();
    }

    public void LoadNextScene()
    {
        if(currentLevel == StaticData.Scenes.Length) {
            return;
        }
        string nextSceneName = StaticData.Scenes[currentLevel + 1];
        SceneManager.LoadScene(nextSceneName);
    }
}
