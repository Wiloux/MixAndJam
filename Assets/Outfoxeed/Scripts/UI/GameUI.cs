using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TMP_Text waveDisplayer;
    public TMP_Text aliveEnemiesCounterDisplayer;

    public TMP_Text scoreDisplayer;
    public TMP_Text highscoreDisplayer;
    // Start is called before the first frame update
    void Start()
    {
        highscoreDisplayer.text = StringToDisplay("Highscore", GameHandler.instance.highScore);
    }

    // Update is called once per frame
    void Update()
    {
        waveDisplayer.text = StringToDisplay("Wave", WaveSpawner.instance.wave - 1);
        aliveEnemiesCounterDisplayer.text = StringToDisplay("Ennemies alive", GameHandler.instance.aliveEnemyCounter);
        scoreDisplayer.text = StringToDisplay("Score", GameHandler.instance.score);

    }

    private string StringToDisplay(string text, int var) { return text + " : " + var.ToString() + " "; }
}
