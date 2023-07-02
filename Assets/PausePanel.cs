using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public static PausePanel instance {  get; private set; }

    public Animator animator;

    public void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        animator.SetInteger("isPaused", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //open pause panel
    public void Open()
    {
        animator.SetInteger("isPaused", 1);
        //Debug.Log("ispaused = " + animator.GetInteger("isPaused"));
    }

    //close pause panel
    public void OnCloseButton()
    {
        Debug.Log("On close buttonnnnn");
        Time.timeScale = 1f;
        animator.SetInteger("isPaused", 2);
    }
    
}
