using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnController : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject[] StartMenuBtn;

    public void StartGame()
    {
        MainCamera.transform.position = new Vector3(0f,0f,-10f);

        foreach (GameObject btn in StartMenuBtn)
        {
            btn.SetActive(false);
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsGame()
    {
 
    }

    public void CreditsGame()
    {

    }

}
