using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextScoreScript : MonoBehaviour
{

    TextMeshProUGUI textmesh;

    private void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        textmesh.text = "Score: " + GameHandler.instance.score.ToString(); 
    }
}
