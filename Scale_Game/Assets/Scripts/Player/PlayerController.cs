using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbodyPlayer;
    private Animator animatorPlayer;

    private float velocity;
    public int CurrentScale;
    private float resize; 
    private float animatorPrintTime,lastPrintTime, printInterval = 0.3f; //TIME CONTROL VARIABLES
    private bool canMove = true;

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
            if (((Input.GetKeyDown(KeyCode.A) && CurrentScale > 1) || (Input.GetKeyDown(KeyCode.D) && CurrentScale < 3)) && canMove == true)
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
        if (Input.GetKey(KeyCode.W) && canMove == true)
        {
            rigidbodyPlayer.velocity = new Vector3(0f, velocity, 0f);
        }
        if (Input.GetKey(KeyCode.S) && canMove == true)
        {
            rigidbodyPlayer.velocity = new Vector3(0f, -velocity, 0f);
        }
        if(transform.position.y < -6.318)
        {
            transform.position = new Vector3(transform.position.x, -6.318f, transform.position.z);
        }
        if (transform.position.y > 6.319)
        {
            transform.position = new Vector3(transform.position.x, 6.319f, transform.position.z);
        }
    }

    //CHECK THE PLAYER COLLISION
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GAME OVER IF PALYER COLLIDE'S PILLAR
        if (collision.CompareTag("Pillar"))
        {
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera.GetComponent<GameManager>().stopGame();
            mainCamera.GetComponent<GameManager>().collided = true;
            canMove = false;
            GameObject[] pillar = GameObject.FindGameObjectsWithTag("PillarBase");
            foreach (GameObject pillars in pillar)
            {
                DestroyObject(pillars);
            }
            Destroy(gameObject);
            mainCamera.GetComponent<GameManager>().afterMenu();
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
