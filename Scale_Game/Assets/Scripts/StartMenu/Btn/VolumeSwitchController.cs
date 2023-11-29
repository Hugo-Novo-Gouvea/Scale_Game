using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSwitchController : MonoBehaviour
{

    public GameObject Audio;

    private Vector3 mousePosition;
    private float switchDistance, newVolume;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 posicaoMousePixels = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(posicaoMousePixels);
        switchDistance = transform.position.x - (-5.16f);
    }

    private void OnMouseDrag()
    {
        if (transform.position.x <= 7.87f && transform.position.x >= -5.16f)
        {
            transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
            if(transform.position.x >= 7.87f)
            {
                transform.position = new Vector3(7.87f, transform.position.y, transform.position.z);
            }
            if(transform.position.x <= -5.16f)
            {
                transform.position = new Vector3(-5.16f, transform.position.y, transform.position.z);
            }

            switchDistance = transform.position.x - (-5.16f);
            newVolume = switchDistance / 13.03f;

            Audio.GetComponent<GameManager>().newVolume(newVolume);
        }




    }
}
