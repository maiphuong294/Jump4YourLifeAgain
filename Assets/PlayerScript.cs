using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject UIController;
    public UIControllerScript sUIControllerScript;

    public Camera MainCamera;
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
    public float desiredDuration;// thoi gian mong muon camera di chuyen
    public float elapsedTime;
    public bool CameraOnPlayer;
    public float PlayerPosY;
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


    }

    // Update is called once per frame
    void Update()
    {
        if (isOnBase == true)
        {

            transform.position = new Vector3(BaseCollide.transform.position.x + toBasePos.x, BaseCollide.transform.position.y + toBasePos.y, 0f);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse clickkkkkk");
                Jump();

            }
        }
        if (CameraOnPlayer == false)
        {
            elapsedTime += Time.deltaTime;
            Vector3 StartCameraPos = MainCamera.transform.position;
            Vector3 EndCameraPos = new Vector3(MainCamera.transform.position.x, PlayerPosY + toCameraPos.y, -10.0f);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, EndCameraPos, elapsedTime / desiredDuration);
            if (elapsedTime / desiredDuration >= 0.9f) CameraOnPlayer = true;
        }
        sBaseScript = BaseCollide.GetComponent<BaseScript>();

        if (sBaseScript.state > 2)
        {
            sUIControllerScript.gameOver();
        }



    }

    void Jump()
    {
        Debug.Log("Jump!");
        rb.AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
        isOnBase = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sUIControllerScript.score++;
        sUIControllerScript.setUIText();
        if (collision.gameObject.CompareTag("Base"))
        {
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
            sBaseScript = BaseCollide.GetComponent<BaseScript>();
            sBaseScript.state++;

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
            sUIControllerScript.gameOver();
        }
    }
}