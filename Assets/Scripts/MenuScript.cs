using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Animator settingAnimator;

    public Sprite Audio;
    public Sprite Vibrate;

    public Sprite noAudio;
    public Sprite noVibrate;

    public bool isAudioOn;
    public bool isVibrateOn;

    private GameObject AudioIcon;
    private Image icon;

    [SerializeField] private TextMeshProUGUI highScoreText;
    void Start()
    {
        GameObject popup = transform.Find("Setting Popup/Popup").gameObject;
        settingAnimator = popup.GetComponent<Animator>();

        isAudioOn = true;
        isVibrateOn = true;

        highScoreText = transform.Find("HighScore Text").gameObject.GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.SetText(PlayerPrefs.GetInt("HighScore").ToString());
        }

        AudioIcon = transform.Find("Setting Popup/Popup/Audio Button/Image").gameObject;
        icon = AudioIcon.GetComponent<Image>();

        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("AudioOn") == 1)
        {
            icon.sprite = Audio;
        }
        else icon.sprite = noAudio;
    }

    public void OnPlayButton()
    {
        AudioManager.instance.audioButtonPressed();
        Debug.Log("Let's play");
        SceneManager.LoadScene("PlayScene");
    }



    //SETTING POPUP
    public void OnSettingButton()
    {
        AudioManager.instance.audioButtonPressed();
        Debug.Log("onsettingbutton");
        settingAnimator.SetBool("isOpen", true);

    }
    public void OnSettingCloseButton()
    {
        AudioManager.instance.audioButtonPressed();
        settingAnimator.SetBool("isOpen", false);

    }
    public void OnAudioButton()
    {
        int a = PlayerPrefs.GetInt("AudioOn");
        PlayerPrefs.SetInt("AudioOn", 1 - a);
     
        AudioManager.instance.audioButtonPressed();
        AudioManager.instance.audioOnChange();
    }

    public void OnVibrateButton()
    {
        AudioManager.instance.audioButtonPressed();
        GameObject VibrateIcon = transform.Find("Setting Popup/Popup/Vibrate Button/Image").gameObject;
        Image icon = VibrateIcon.GetComponent<Image>();
        isVibrateOn = !isVibrateOn;
        if (isVibrateOn == true)
        {
            icon.sprite = Vibrate;
        }
        else icon.sprite = noVibrate;

    }

    public void OnOptionButton()
    {
        AudioManager.instance.audioButtonPressed();
        OptionPanel.instance.Open();
    }

  
}
