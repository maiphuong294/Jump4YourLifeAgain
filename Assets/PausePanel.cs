using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public static PausePanel instance {  get; private set; }

    public Animator animator;
    public Sprite Audio;
    public Sprite Vibrate;

    public Sprite noAudio;
    public Sprite noVibrate;

    public bool isAudioOn;
    public bool isVibrateOn;

    public void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        animator.SetInteger("isPaused", 0);
        isAudioOn = true;
        isVibrateOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //open pause panel
    public void Open()
    {
        Time.timeScale = 0f;
        animator.SetInteger("isPaused", 1);
    }

    //close pause panel
    public void OnCloseButton()
    {
        Time.timeScale = 1f;
        animator.SetInteger("isPaused", 2);    
    }

    public void OnAudioButton()
    {
        Debug.Log("Audio");
        //change audio sprite
        GameObject AudioIcon= transform.Find("Pop-up/Audio Button/Audio Icon").gameObject;
        Image icon = AudioIcon.GetComponent<Image>();
        isAudioOn = !isAudioOn;
        if (isAudioOn == true)
        {
            icon.sprite = Audio;
        }
        else icon.sprite = noAudio;

        
    }
    public void OnVibrateButton()
    {
        Debug.Log("Vibrate");
        //change vibrate sprite
        GameObject VibrateIcon = transform.Find("Pop-up/Vibrate Button/Vibrate Icon").gameObject;
        Image icon = VibrateIcon.GetComponent<Image>();
        isVibrateOn = !isVibrateOn;
        if (isVibrateOn == true)
        {
            icon.sprite = Vibrate;
        }
        else icon.sprite = noVibrate;
        
    }
    public void OnReplayButton()
    {
        Debug.Log("ON REPLAY BUTTON");
        StartCoroutine(Replay());
    }
    public void OnHomeButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public IEnumerator Replay()
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene("PlayScene");
    }





}
