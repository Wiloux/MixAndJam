using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    private void Awake() {
        instance = this;
    }

    public int ennemyCounter = 0;

    public int GetEnnemyCounter(){return ennemyCounter;}
    public void AddEnnemyToCounter(){ennemyCounter++;}
    public void RemoveEnnemyToCounter(){ennemyCounter--;}
}
