
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{

    // singleton
    public static GameOverPanel instance {  get; private set; }

    public Animator animator;
    [SerializeField] private GameObject uiController;


    private void Awake()
    {
        instance = this;
        
        
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        //Debug.Log("Game over");
        gameObject.SetActive(true);

        //set highscore cho score textmeshpro
        GameObject popup = transform.Find("Pop-up").gameObject;
        animator = popup.transform.GetComponent<Animator>();

        UIControllerScript.instance.SetFinalScore();


        // dung game
        //Time.timeScale = 0f;
        //dung tat ca cac base trong scene

        animator.SetBool("NeedMove", true);

        AudioManager.instance.stopAudio();
        AudioManager.instance.audioGameOver();
    }


    public void OnReplayButton()
    {
        AudioManager.instance.audioButtonPressed();
        Debug.Log("on replay button");
        StartCoroutine(Replay());

        AudioManager.instance.audioBackground();
        
    }

    public IEnumerator Replay()
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("PlayScene");
    }

    public void OnCloseButton()
    {
        AudioManager.instance.audioButtonPressed();
        SceneManager.LoadScene("MenuScene");
        AudioManager.instance.audioBackground();
    }

}
