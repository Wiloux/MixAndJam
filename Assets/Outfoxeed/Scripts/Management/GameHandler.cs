﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    private void Awake() {
        instance = this;
        highScore = PlayerPrefs.GetInt("HighScore",0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ResumeGame();
        if (isGamePaused) { pauseMenu.SetActive(true); Camera.main.GetComponent<AudioSource>().Pause(); }
        else { pauseMenu.SetActive(false); Camera.main.GetComponent<AudioSource>().UnPause(); }
    }

    // UI
        // Pause Menu
    public GameObject pauseMenu;
    public bool isGamePaused = false;
    public bool IsGamePaused() { return isGamePaused; }
    public void ResumeGame() { isGamePaused = !isGamePaused; if (!isGamePaused) Time.timeScale = 1f; else Time.timeScale = 0f; }
        // Game Over Menu
    public GameObject gameOverMenu;
    public void DisplayGameOver() { gameOverMenu.SetActive(true); }

    // Score
    public int score = 0;
    public int GetScore() { return score; }
    public void AddScore(int plus) { score += plus; }
    public void RemoveScore(int minus) { score += minus; }
        // Highscore
    public int highScore;
    public void SaveHighScore() { if (score > highScore) { PlayerPrefs.SetInt("HighScore", score); highScore = score; } }

    // Enemies Counter 
    public int aliveEnemyCounter = 0;
    public int GetAliveEnemyCounter(){return aliveEnemyCounter;}
    public void AddAliveEnemyToCounter(){aliveEnemyCounter++;}
    public void RemoveAliveEnemyToCounter(){aliveEnemyCounter--;}

    // Visible Enemies Counter
    public int screenVisibleEnemyCounter = 0;
    public int GetScreenVisibleEnemyCounter(){return screenVisibleEnemyCounter;}
    public void AddScreenVisibleEnemyToCounter(){screenVisibleEnemyCounter++;}
    public void RemoveScreenVisibleEnemyToCounter(){screenVisibleEnemyCounter--;}

    // private void Update() {
    //     Debug.Log("Alive Enemy Counter = " + aliveEnemyCounter);
    //     Debug.Log("Screen Visible Enemy Counter = " + screenVisibleEnemyCounter);
    // }

}
