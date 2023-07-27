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

    private GameObject AudioIcon;
    private Image icon;

    public void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        animator.SetInteger("isPaused", 0);
        isAudioOn = true;
        isVibrateOn = true;

        AudioIcon = transform.Find("Pop-up/Audio Button/Audio Icon").gameObject;
        icon = AudioIcon.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //chuyen sprite audio trong update vi co the audio on off tai menu, nhung se khong cap nhat luon
        //-> dung playerprefs de check lien tuc trong update
        if (PlayerPrefs.GetInt("AudioOn") == 1)
        {
            icon.sprite = Audio;
        }
        else icon.sprite = noAudio;
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
        AudioManager.instance.audioButtonPressed();
        Time.timeScale = 1f;
        animator.SetInteger("isPaused", 2);    
    }

    public void OnAudioButton()
    {
        Debug.Log("Audio");
        //change audio sprite
        

        int a = PlayerPrefs.GetInt("AudioOn");
        PlayerPrefs.SetInt("AudioOn", 1 - a);      

        AudioManager.instance.audioButtonPressed();
        AudioManager.instance.audioOnChange();

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
        AudioManager.instance.audioButtonPressed();

    }
    public void OnReplayButton()
    {
        AudioManager.instance.audioButtonPressed();
        Debug.Log("ON REPLAY BUTTON");
        StartCoroutine(Replay());
    }
    public void OnHomeButton()
    {
        AudioManager.instance.audioButtonPressed();
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
        AudioManager.instance.audioBackground();

    }

    public IEnumerator Replay()
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.2f);
        SceneManager.LoadScene("PlayScene");
    }





}
