using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {  get; private set; }

    [SerializeField] private AudioSource audioSource;
    private int isAudioOn;

    [SerializeField] private AudioClip background;
    [SerializeField] private AudioClip breaksound;
    [SerializeField] private AudioClip gameover;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip perfect;
    [SerializeField] private AudioClip buttonPressed;


    public void Awake()
    {
        //instance = this;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this);
        isAudioOn = PlayerPrefs.GetInt("AudioOn");
        audioOnUpdate();
        audioBackground();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void audioBackground()
    {
            audioSource.clip = background;
            audioSource.Play();
        
    }
    public void audioGameOver()
    {
        audioSource.PlayOneShot(gameover);
    }

    public void audioBreakSound()
    {
        audioSource.PlayOneShot(breaksound);
    }

    public void audioJump()
    {
        audioSource.PlayOneShot(jump);
    }

    public void audioPerfect()
    {
        audioSource.PlayOneShot(perfect);
    }

    public void audioButtonPressed()
    {
        audioSource.PlayOneShot(buttonPressed);
    }
    
    public void stopAudio()
    {
        audioSource.Stop();
    }

    public void audioOnChange()
    {
        isAudioOn = 1 - isAudioOn;
        audioOnUpdate();
    }

    public void audioOnUpdate() { 
        if (isAudioOn == 0)
        {
            audioSource.volume = 0f;
        }
        else audioSource.volume = 1f;
    }

}
