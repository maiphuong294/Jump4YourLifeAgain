using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UIControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animatorPerfect;
    public int score;
    void Start()
    {
        score = -1;
        //xu ly perfect
        GameObject perfectPopup = transform.Find("Canvas/Perfect Popup").gameObject;
        animatorPerfect = perfectPopup.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void setUIText()
    {
        GameObject UIText = transform.Find("Canvas/Score Text").gameObject;
        UIText.SetActive(true);

        TextMeshProUGUI textComponent = UIText.GetComponent<TextMeshProUGUI>();
        textComponent.text = ScoreManagerScript.currentScore.ToString();

        
    }

    public void Perfect()
    {
        StartCoroutine("PerfectRun");
    }
    
    private IEnumerator PerfectRun()
    {
        //Debug.Log("Perfect");
        animatorPerfect.SetBool("isPerfect", true);
        yield return new WaitForSeconds(0.25f);
        animatorPerfect.SetBool("isPerfect", false);

    }

    public void SetFinalScore()
    {
        Debug.Log("setFinalscore");
        GameObject score = transform.Find("Canvas/GameOverPanel/Pop-up/Final Score").gameObject;
        TextMeshProUGUI scoreText = score.GetComponent<TextMeshProUGUI>();
        scoreText.text = ScoreManagerScript.currentScore.ToString();

        int h = 0;
        if (PlayerPrefs.HasKey("HighScore")){
            h = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", System.Math.Max(ScoreManagerScript.currentScore, h));   
    }


 



}
