using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTest : MonoBehaviour
{
    // Start is called before the first frame update

    public void BeatChecker(int i)
    {
        Debug.Log("b");
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
    }
}
