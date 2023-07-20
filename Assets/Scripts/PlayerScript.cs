﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class PlayerScript : MonoBehaviour
{
    public GameObject UIController;
    public UIControllerScript sUIControllerScript;


    [SerializeField] private Camera MainCamera;
    private Rigidbody2D rb;
    public float jumpSpeed;
    private Collider2D colliderBase;
    public GameObject BaseCollide; //tra ve base ma dang collide voi
    private Vector2 toBasePos;
    private Vector2 toCameraPos;//cai nay se la constant
    public BaseScript sBaseScript;

    public bool isOnBase;
    //de check xem player co dang tren base khong
    //neu tren base thi se di chuyen theo base

    //CameraFollowPlayer
    [SerializeField] private float desiredDuration;// thoi gian mong muon camera di chuyen
    [SerializeField] private float elapsedTime;
    [SerializeField] private bool CameraOnPlayer;
    [SerializeField] private float PlayerPosY;

    [SerializeField] private Animator playerAnimator;

    [SerializeField] private Character Pig;
    [SerializeField] private Character Puppy;
    [SerializeField] private Character Penguin;
    [SerializeField] private Character Kitten;

    private Dictionary<string, Character> CharacterDictionary = new Dictionary<string, Character>();

    [SerializeField] private Scene City;
    [SerializeField] private Scene Forest;
    [SerializeField] private Scene IceMountain;
    [SerializeField] private Scene Meadow;
    [SerializeField] private Scene SkyandClouds;

    private Dictionary<string, Scene> SceneDictionary = new Dictionary<string, Scene>();

    void Start()
    {

        Debug.Log("Start");
        transform.Translate(Vector2.right * jumpSpeed);
        jumpSpeed = 15.0f;
        isOnBase = true;
        rb = GetComponent<Rigidbody2D>();
        sUIControllerScript = UIController.GetComponent<UIControllerScript>();

        //lay khoang cach dau tien tu player den camera
        toCameraPos = new Vector2(MainCamera.transform.position.x - transform.position.x, MainCamera.transform.position.y - transform.position.y);

        //CameraFollowPlayer
        desiredDuration = 1.0f;
        CameraOnPlayer = true;

        sBaseScript = null;
        BaseCollide = null;

        playerAnimator = gameObject.GetComponent<Animator>();

        //doi skin cho player
        
        CharacterDictionary.Add("Pig", Pig);
        CharacterDictionary.Add("Puppy", Puppy);
        CharacterDictionary.Add("Penguin", Penguin);
        CharacterDictionary.Add("Kitten", Kitten);

        string s = PlayerPrefs.GetString("Character");
        if (s != null)
        {
            if (CharacterDictionary.TryGetValue(s, out Character a))
            {
                SpriteRenderer headSprite = transform.Find("Head").gameObject.GetComponent<SpriteRenderer>();   
                headSprite.sprite = a.head;

                SpriteRenderer bodySprite = transform.Find("Body").gameObject.GetComponent<SpriteRenderer>();
                bodySprite.sprite = a.body;

                SpriteRenderer leftHand = transform.Find("Hand/LeftHand").gameObject.GetComponent<SpriteRenderer>();
                leftHand.sprite = a.leftHand;

                SpriteRenderer rightHand = transform.Find("Hand/RightHand").gameObject.GetComponent<SpriteRenderer>();
                rightHand.sprite = a.rightHand;

                SpriteRenderer leftFoot = transform.Find("Feet/LeftFoot").gameObject.GetComponent<SpriteRenderer>();
                leftFoot.sprite = a.leftFoot;

                SpriteRenderer rightFoot = transform.Find("Feet/RightFoot").gameObject.GetComponent<SpriteRenderer>();
                rightFoot.sprite = a.rightFoot;

                SpriteRenderer tail = transform.Find("Tail").gameObject.GetComponent<SpriteRenderer>();
                tail.sprite = a.tail;

            }
            else
            {
                Debug.LogWarning("Object with name '" + s + "' not found.");
            }
        }

        //doi scene cho background
        SceneDictionary.Add("City", City);
        SceneDictionary.Add("Forest", Forest);
        SceneDictionary.Add("Ice Mountain", IceMountain);
        SceneDictionary.Add("Meadow", Meadow);
        SceneDictionary.Add("Sky and Clouds", SkyandClouds);

        string s2 = PlayerPrefs.GetString("Scene");
        if(s2 != null)
        {
            if(SceneDictionary.TryGetValue(s2, out Scene a))
            {
                SpriteRenderer background = MainCamera.transform.Find("Background").gameObject.GetComponent<SpriteRenderer>();
                background.sprite = a.scene;
            }
            else
            {
                Debug.Log("Scene not found");
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isOnBase == true && BaseCollide != null)
        {
            //player dinh theo base
            transform.position = new Vector3(BaseCollide.transform.position.x + toBasePos.x, BaseCollide.transform.position.y + toBasePos.y, 0f);
        }
        
  
        if (isOnBase == true && Input.GetMouseButtonDown(0) && !IsOverUI())
        {
            //khi o tren base thi co the nhay
            Debug.Log("Mouse clickkkkkk " + Time.time);
            Jump();         

        }
        
        //lam muot chuyen dong camera
        if (CameraOnPlayer == false)
        {
            elapsedTime += Time.deltaTime;
            Vector3 StartCameraPos = MainCamera.transform.position;
            Vector3 EndCameraPos = new Vector3(MainCamera.transform.position.x, PlayerPosY + toCameraPos.y, -10.0f);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, EndCameraPos, elapsedTime / desiredDuration);
            if (elapsedTime / desiredDuration >= 0.9f) CameraOnPlayer = true;
        }
        


        //neu broken roi ma tiep tuc dap vao tuong
        if (sBaseScript != null)
        {
            sBaseScript = BaseCollide.GetComponent<BaseScript>();
            if (sBaseScript.state > 2)
            {
                gameOver();
                BaseCollide.SetActive(false);
            }
        }

    }

    void Jump()
    {
        Debug.Log("Jump! " + Time.time);
        rb.AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
        isOnBase = false;
        playerAnimator.SetBool("isJump", true);

        AudioManager.instance.audioJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManagerScript.currentScore++;
        ScoreManagerScript.currentScore += ScoreManagerScript.scoreTrigger;
        ScoreManagerScript.scoreTrigger = 0;

        if (collision.gameObject.CompareTag("Base"))
        {
            playerAnimator.SetBool("isJump", false);
            Debug.Log("EnterBase");
            //xuly player vs base
            isOnBase = true;
            BaseCollide = collision.gameObject;
            toBasePos = new Vector2(transform.position.x - BaseCollide.transform.position.x, transform.position.y - BaseCollide.transform.position.y);

            //xuly camera
            elapsedTime = 0f;
            CameraOnPlayer = false;
            PlayerPosY = transform.position.y;

            //xu ly state cua base
            if (collision.gameObject.name != "FirstBase")
            {
                sBaseScript = BaseCollide.GetComponent<BaseScript>();
                sBaseScript.state++;
            }

            //check Perfect
            if (isPerfect() && collision.gameObject.name != "FirstBase")
            {
                Debug.Log("PERFECT");
                ScoreManagerScript.bonus++;
                ScoreManagerScript.currentScore += ScoreManagerScript.bonus;
                sUIControllerScript.Perfect();
            }
            else ScoreManagerScript.bonus = 0;
            sUIControllerScript.setUIText();

            //sau khi jump len base do thi khong tinh trigger cho base do nua
            if(BaseCollide != null)
            {
                  
                GameObject scoreTrigger = BaseCollide.transform.Find("ScoreTrigger").gameObject;
                if(scoreTrigger != null){
                    scoreTrigger.SetActive(false);
                }
            }
            
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            colliderBase = collision.gameObject.GetComponent<Collider2D>();
            colliderBase.isTrigger = true;//sau khi jump thi khong collide voi base nay nua
            isOnBase = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bound"))
        {
            gameOver();
        }
        if (collision.gameObject.CompareTag("ScoreTrigger"))
        {
            Debug.Log("Trigger Score");
            ScoreManagerScript.scoreTrigger++;
        }
    }


    public bool isPerfect()
    {
        
        if(Mathf.Abs(transform.position.x - BaseCollide.transform.position.x) < 0.1f)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// kiểm tra xem chuột có đang nằm trên UI hay không?
    /// UI có tick chọn RaycastTarget
    /// </summary>
    public static bool IsOverUI()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void gameOver()
    {
        //dung tat ca va de cho player roi xuong

        Collider2D player = gameObject.GetComponent<Collider2D>();
        if (player != null)
        {
            player.isTrigger = true;
        }
        // tim tat ca object dang active voi tag la base
        //Debug.Log("gameover");
        GameObject[] objectsWithTagBase = GameObject.FindGameObjectsWithTag("Base"); 
        foreach (GameObject obj in objectsWithTagBase)
        {
            //lan luot cho stop
            BaseScript a = obj.GetComponent<BaseScript>();
            if (a != null)
            {
                a.velocity_x = 0f;
                a.velocity_y = 0f;
            }
        }
        GameOverPanel.instance.Show();
    }
}