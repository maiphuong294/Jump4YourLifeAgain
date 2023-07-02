
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{

    // singleton
    public static GameOverPanel instance {  get; private set; }

    public Animator animator;


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
        // dung game
        Time.timeScale = 0f;
        animator.SetBool("NeedMove", true);
    }


    public void OnReplayButton()
    {
        Debug.Log("on replay button");
        StartCoroutine(Delay());
        
    }

    private IEnumerator Delay()
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("PlayScene");
    }

}
