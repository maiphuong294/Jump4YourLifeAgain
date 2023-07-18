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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButton()
    {
        Debug.Log("Let's play");
        SceneManager.LoadScene("PlayScene");
    }



    //SETTING POPUP
    public void OnSettingButton()
    {
        Debug.Log("onsettingbutton");
        settingAnimator.SetBool("isOpen", true);

    }
    public void OnSettingCloseButton()
    {
        settingAnimator.SetBool("isOpen", false);

    }
    public void OnAudioButton()
    {
        GameObject AudioIcon = transform.Find("Setting Popup/Popup/Audio Button/Image").gameObject;
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
        OptionPanel.instance.Open();
    }
}
