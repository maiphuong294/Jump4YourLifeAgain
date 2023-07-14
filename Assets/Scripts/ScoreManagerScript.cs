using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int currentScore;
    public static int bonus;
    public static int scoreTrigger;
    public static int highestScore;
    //static thi se k hien len inspector?

    //cai nay la singleton
    public static ScoreManagerScript instance { get; private set; }
    void Start()
    {
        instance = this;

        currentScore = -1;
        bonus = 0;
        scoreTrigger = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
