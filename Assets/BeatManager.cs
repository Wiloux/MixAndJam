using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public float currentsongBMP;
    public float secPerBeat;
    public float beatsPerLoop;
    public float nextActionTime = 0.0f;
    public float secsBtwActions = 0.1f;
    public int beatTimesSinceStart = 0;
    public int loopTimesSinceStart = 0;
    public int loopsLeftUntilNextBeat = 0;
    public List<LoopBeat> AllDifferentLoops = new List<LoopBeat>();
    int i = 0;

    public SpriteRenderer dancefloor;
    public PlayerMovement player;
    public BeatTest beatTest;
    Animator anim;

    public static BeatManager instance;
    //  public List<RangeEnemy> RangeEnemies = new List<RangeEnemy>();

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        loopsLeftUntilNextBeat = AllDifferentLoops[0].LoopTime;

        anim = GetComponent<Animator>();
        anim.SetTrigger("Beat" + AllDifferentLoops[0].BeatType.ToString());

        beatsPerLoop = AllDifferentLoops[0].numberofBeats;

        secPerBeat = currentsongBMP / 60f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        secsBtwActions = 1 / secPerBeat;
        //     beatNumbersSoFar += secPerBeat * Time.deltaTime;

        if (Time.time > nextActionTime)
        {
            Debug.Log("a");
            beatTimesSinceStart++;
            if (beatTimesSinceStart % beatsPerLoop == 0)
            {
                loopsLeftUntilNextBeat--;
                loopTimesSinceStart++;
            }
            if (loopsLeftUntilNextBeat <= 0)
            {
                i++;
                if (i >= AllDifferentLoops.Count)
                {
                    i = 0;
                }
                loopsLeftUntilNextBeat = AllDifferentLoops[i].LoopTime;
                //  PlaysBeat(1);
                dancefloor.color = new Color(Random.Range(0f, 1f),
                                             Random.Range(0f, 1f),
                                             Random.Range(0f, 1f));
                Debug.Log("New beat!" + AllDifferentLoops[i].BeatType);
                anim.SetTrigger("Beat" + AllDifferentLoops[i].BeatType.ToString());

            }
            nextActionTime += secsBtwActions;
            // execute block of code here
        }
    }

    public void PlaysBeat(int i)
    {
        //foreach (RangeEnemy enai in RangeEnemies)
        //{
        //    enai.GetPlayerInsight();
        //}
        player.ChooseAttackType(i);
        beatTest.BeatChecker(i);
    }

}


[System.Serializable]
public class LoopBeat
{
    public int LoopTime;
    public int BeatType;
    public int numberofBeats;
}
