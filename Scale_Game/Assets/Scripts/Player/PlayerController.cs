using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbodyPlayer;
    private Animator animatorPlayer;

    private float velocity;
    private int CurrentScale;
    private float resize; 
    private float animatorPrintTime,lastPrintTime, printInterval = 0.3f; //TIME CONTROLL VARIABLES

    void Start()
    {
        CurrentScale = 2;
        velocity = 4f;
        lastPrintTime = Time.time;

        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        animatorPrintTime += Time.deltaTime;
        
        //SCALE CONTROLL
        //CONTROLL THE PLAYER'S CURRENT SCALE AND VELOCITY AFTER A INTERVAL OF 0,3 SECONDS
        if(Time.time - lastPrintTime >= printInterval) 
        {
            if ((Input.GetKeyDown(KeyCode.A) && CurrentScale > 1) || (Input.GetKeyDown(KeyCode.D) && CurrentScale < 3))
            {

                if (Input.GetKeyDown(KeyCode.A))
                {
                    CurrentScale--;
                    velocity += 1.5f;
                    resize = -0.1f;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    CurrentScale++;
                    velocity += -1.5f;
                    resize = 0.1f;
                }

                StartCoroutine(changeSize(resize));
                lastPrintTime = Time.time;

            }
        }

        //CONTROLL THE BLINK ANIMATION TIME INTERVAL
        if(animatorPrintTime >= 5)
        {
            animatorPlayer.SetTrigger("blink");
            animatorPrintTime = 0;
        }
    }

    void FixedUpdate()
    {   
        
        //STOP PLAYER IF NO KEY IS PRESSED
        rigidbodyPlayer.velocity = new Vector3(0f, 0f, 0f);

        //MOVEMENT CONTROLL
        //CONTROLL THE PLAYER'S CURRENT POSITION IN WORLD
        if (Input.GetKey(KeyCode.W))
        {
            rigidbodyPlayer.velocity = new Vector3(0f, velocity, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbodyPlayer.velocity = new Vector3(0f, -velocity, 0f);
        }
        
    }

    //CHECK THE PLAYER COLLISION
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GAME OVER IF PALYER COLLIDE'S PILLAR
        if (collision.CompareTag("Pillar"))
        {
            //FAZER O GAME OVER AQUI DENTRO
        }
    }

    //CONTROLL THE RESIZE ANIMATION
    IEnumerator changeSize(float resize)
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x + resize, transform.localScale.x + resize, transform.localScale.x + resize);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
