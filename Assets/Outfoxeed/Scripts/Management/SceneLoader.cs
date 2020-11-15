using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int gameSceneIndex = 1;

    public void LoadGameMenuScene() { GameHandler.instance.SaveHighScore(); SceneManager.LoadScene(0); }
    public void LoadGameScene(){ SceneManager.LoadScene(gameSceneIndex);}
    public void LoadIndexScene(int index) { SceneManager.LoadScene(index); }
    public void Quit() { Application.Quit(); }
}
