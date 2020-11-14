using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    private void Awake() {
        instance = this;
    }

    // Enemies Counter 
    public int aliveEnemyCounter = 0;
    public int GetAliveEnemyCounter(){return aliveEnemyCounter;}
    public void AddAliveEnnemyToCounter(){aliveEnemyCounter++;}
    public void RemoveAliveEnnemyToCounter(){aliveEnemyCounter--;}

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
