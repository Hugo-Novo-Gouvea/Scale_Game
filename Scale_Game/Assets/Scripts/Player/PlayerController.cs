using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbodyPlayer;

    public float velocity;
    private int CurrentScale;
    private float resize;
    private float lastPrintTime, printInterval = 0.3f;

    void Start()
    {
        CurrentScale = 2;
        velocity = 4f;
        lastPrintTime = Time.time;

        rigidbodyPlayer = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        //SCALE CONTROL
        //CONTROL THE PLAYER'S CURRENT SCALE AND VELOCITY AFTER A INTERVAL OF 0,3 SECONDS
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
    }

    void FixedUpdate()
    {   
        
        //STOP PLAYER IF NO KEY IS PRESSED
        rigidbodyPlayer.velocity = new Vector3(0f, 0f, 0f);

        //MOVEMENTATION
        //CONTROL THE PLAYER'S CURRENT POSITION IN WORLD
        if (Input.GetKey(KeyCode.W))
        {
            rigidbodyPlayer.velocity = new Vector3(0f, velocity, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbodyPlayer.velocity = new Vector3(0f, -velocity, 0f);
        }
        
    }

    //CONTROL THE RESIZE ANIMATION
    IEnumerator changeSize(float resize)
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localScale = new Vector3(transform.localScale.x + resize, transform.localScale.x + resize, transform.localScale.x + resize);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
