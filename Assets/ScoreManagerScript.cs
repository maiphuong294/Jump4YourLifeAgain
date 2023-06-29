using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int currentScore;
    public static int highestScore;

    //cai nay la singleton
    public static ScoreManagerScript instance { get; private set; }
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
