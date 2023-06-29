using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControllerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public int score;
    void Start()
    {
        score = -1;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void gameOver()
    {
        //truy cap den uicontroller -> canvas -> gameOverText

        GameObject UIText = transform.Find("Canvas/GameOver Text").gameObject;
        UIText.SetActive(true);

        Text textComponent = UIText.GetComponent<Text>();
        textComponent.text = "GameOver - Score: " + score.ToString();

    }

    public void setUIText()
    {
        GameObject UIText = transform.Find("Canvas/GameOver Text").gameObject;
        UIText.SetActive(true);

        Text textComponent = UIText.GetComponent<Text>();
        textComponent.text = score.ToString();
    }

}
