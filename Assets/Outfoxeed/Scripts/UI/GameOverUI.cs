using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text scoreDisplayer;
    public TMP_Text highscoreDisplayer;

    // Update is called once per frame
    void Update()
    {
        scoreDisplayer.text = GameHandler.instance.score.ToString();
        highscoreDisplayer.text = GameHandler.instance.highScore.ToString();
    }
}
