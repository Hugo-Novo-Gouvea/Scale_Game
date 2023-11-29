using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMovement : MonoBehaviour
{

    private Rigidbody2D rigidbodyPillar;
    private float time;

    private int pillarChoice;

    void Start()
    {
        pillarChoice = Random.Range(0, 9);
        transform.GetChild(pillarChoice).gameObject.SetActive(true);

        rigidbodyPillar = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }


    void FixedUpdate()
    {
        GameObject currentTime = GameObject.FindGameObjectWithTag("MainCamera");
        time = currentTime.GetComponent<GameManager>().time;
        time = time * 0.1f;
        rigidbodyPillar.velocity = new Vector3(-5f-time, 0, 0);
    }

}
