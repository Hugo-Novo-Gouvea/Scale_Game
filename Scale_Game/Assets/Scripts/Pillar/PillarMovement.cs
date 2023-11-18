using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMovement : MonoBehaviour
{

    private Rigidbody2D rigidbodyPillar;

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
        rigidbodyPillar.velocity = new Vector3(-6f, 0, 0);
    }

}
