using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionPanel : MonoBehaviour
{

    public static OptionPanel instance { get; private set; }
    public Animator animator;
    public GameObject charScroll;
    public GameObject sceneScroll;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        charScroll.SetActive(true);
        sceneScroll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCloseButton()
    {
        //animation close
        AudioManager.instance.audioButtonPressed();
        animator.SetBool("isOpen", false);
    }
    public void Open()
    {
        animator.SetBool("isOpen", true);
    }

    public void OnCharacterSelectButton()
    {
        AudioManager.instance.audioButtonPressed();
        charScroll.SetActive(true);
        sceneScroll.SetActive(false);
    }
    
    public void OnSceneSelectButton()
    {
        AudioManager.instance.audioButtonPressed();
        charScroll.SetActive(false);
        sceneScroll.SetActive(true);
    }

}
