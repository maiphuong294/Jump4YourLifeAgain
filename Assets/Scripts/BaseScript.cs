using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    
    [SerializeField] private float direction;
    public float velocity_x;
    public float velocity_y;

    private SpriteRenderer spriteRenderer;
    private Color color;
    private int colorUp;
    [SerializeField] private Sprite brokenBase;
    public int state = 0;
    //0 la ban dau khoi tao
    //1 la khi player da nhay len
    //2 la khi broken
    //3 la gameover do dap vao tuong tiep

    public GameObject GameOverText;
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        direction = 1.0F;
        velocity_x = 2F;
        velocity_y = 0f;

        colorUp = 2;//khong phai la base tang hinh

        if (Random.Range(1,100) % 5 == 0)
        {
            velocity_y = 0.3f;
        }
        else
        {
            if (Random.Range(1,100) % 2 == 0)
            {
                colorUp = 0;
  
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {   
        //chuyen huong
        transform.position += Vector3.left * velocity_x * direction * Time.deltaTime;
        transform.position += Vector3.down * velocity_y * direction * Time.deltaTime;


        ////chuyen blur
        //if (colorUp == 0)
        //{
        //    color.a -= 0.005f;
        //    spriteRenderer.color = color;
        //}else if (colorUp == 1)
        //{
        //    color.a += 0.005f;
        //    spriteRenderer.color = color;
        //}

        //if (color.a == 0f || color.a == 1f)
        //{
        //    colorUp = 1 - colorUp;
        //}

    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("Collision with Wall");
            direction = -direction;
            if (state == 1)
            {
                state++;
                spriteRenderer.sprite = brokenBase;
                AudioManager.instance.audioBreakSound();
            }else if (state == 2)
            {
                state++;
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Debug.Log("Collision with Wall");
            direction = -direction;

        }
    }
}