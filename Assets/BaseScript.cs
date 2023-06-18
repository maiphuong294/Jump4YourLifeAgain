using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public GameObject UIController;
    public float direction;
    public float velocity;
    private SpriteRenderer spriteRenderer;
    public Sprite brokenBase;
    public int state;
    //0 la ban dau khoi tao
    //1 la khi player da nhay len
    //2 la khi broken
    //3 la gameover do dap vao tuong tiep

    public GameObject GameOverText;
    void Start()
    {
        state = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = 1.0F;
        velocity = 2.5F;
    }

    // Update is called once per frame
    void Update()
    {   
        
        transform.position = transform.position + Vector3.left * velocity * direction * Time.deltaTime;
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
            }else if (state == 2)
            {

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