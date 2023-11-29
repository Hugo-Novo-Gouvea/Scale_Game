using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnStart : MonoBehaviour
{
    private RectTransform recttransformBtn;
    private AudioSource audiosourceBtn;

    public AudioClip[] Audio;

    void Awake()
    {
        recttransformBtn = GetComponent<RectTransform>();
        audiosourceBtn = GetComponent<AudioSource>();
    }

    public void CallCoroutine()
    {
        StartCoroutine(instantiateBtn());
    }

    private IEnumerator instantiateBtn()
    {
        recttransformBtn.sizeDelta = new Vector2(0, 0);
        for (int i = 0; i < 99; i++)
        {
            recttransformBtn.sizeDelta = new Vector2(recttransformBtn.sizeDelta.x + 1.28f, recttransformBtn.sizeDelta.y + 0.6f);
            yield return new WaitForSeconds(0.001f);
        }
    }


    public void mouseEnter()
    {
        audiosourceBtn.PlayOneShot(Audio[0]);
    }

    public void mouseClick()
    {
        audiosourceBtn.PlayOneShot(Audio[1]);
    }

}
