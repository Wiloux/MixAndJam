using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int gameSceneIndex = 1;
    public void LoadGameScene(){SceneManager.LoadScene(gameSceneIndex);}

    public void LoadIndexScene(int index) { SceneManager.LoadScene(index); }
}
