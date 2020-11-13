using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBassDrumTest : MonoBehaviour
{
    // Start is called before the first frame update
    public uint test;
    void Start()
    {
       test = AkSoundEngine.PostEvent("SimpleBassDrum", gameObject);
    }


}
