using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnController : MonoBehaviour
{

    public GameObject MainCamera;
    public GameObject[] StartMenuBtn;
    public GameObject BackBtn;
    public GameObject Logo;
    public GameObject Volume;
    public GameObject[] CreditsText;
    public GameObject[] CreditsLinkedin;
    public GameObject Score;
    public GameObject ScoreText;
    public GameObject Rules;
    public GameObject[] TryAgainBtn;


    public void StartGame()
    {
        foreach (GameObject btn in StartMenuBtn)
        {
            btn.SetActive(false);
        }
        MainCamera.GetComponent<GameManager>().startGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsGame()
    {
        Logo.SetActive(false);
        foreach (GameObject btn in StartMenuBtn)
        {
            btn.SetActive(false);
        }
        BackBtn.SetActive(true);
        Volume.SetActive(true);
        Rules.SetActive(true);
    }

    public void CreditsGame()
    {
        Logo.SetActive(false);
        foreach (GameObject btn in StartMenuBtn)
        {
            btn.SetActive(false);
        }
        foreach (GameObject text in CreditsText)
        {
            text.SetActive(true);
        }
        foreach (GameObject btn in CreditsLinkedin)
        {
            btn.SetActive(true);
        }
        BackBtn.SetActive(true);
    }

    public void BacktoStart()
    {
        BackBtn.SetActive(false);
        Rules.SetActive(false);
        Volume.SetActive(false);
        foreach (GameObject text in CreditsText)
        {
            text.SetActive(false);
        }
        foreach (GameObject btn in CreditsLinkedin)
        {
            btn.SetActive(false);
        }
        Logo.SetActive(true);
        Logo.GetComponent<Animator>().SetBool("idle", true);
        for (int i = 0; i < StartMenuBtn.Length; i++)
        {
            StartMenuBtn[i].SetActive(true);
            StartMenuBtn[i].GetComponent<BtnStart>().CallCoroutine();
        }
    }

    public void tryagain()
    {
        Score.SetActive(false);
        ScoreText.SetActive(false);
        foreach (GameObject btn in TryAgainBtn)
        {
            btn.SetActive(false);
        }
        MainCamera.GetComponent<GameManager>().time = 0;
        MainCamera.GetComponent<GameManager>().startGame();
    }

    public void menu()
    {
        Score.SetActive(false);
        ScoreText.SetActive(false);
        foreach (GameObject btn in TryAgainBtn)
        {
            btn.SetActive(false);
        }
        MainCamera.GetComponent<GameManager>().time = 0;
        MainCamera.GetComponent<GameManager>().start = false;
        MainCamera.GetComponent<GameManager>().startMusic = true;
        MainCamera.GetComponent<GameManager>().stopMusic();
        MainCamera.transform.position = new Vector3(0, -50, -10);
        Logo.SetActive(true);
        Logo.GetComponent<Animator>().SetBool("idle", true);
        for (int i = 0; i < StartMenuBtn.Length; i++)
        {
            StartMenuBtn[i].SetActive(true);
            StartMenuBtn[i].GetComponent<BtnStart>().CallCoroutine();
        }
    }

    //Linkedin

    public void DanielRemedioLinkedin()
    {
        string url = "https://www.linkedin.com/in/daniel-remédio-aa0b6728a/";
        Application.OpenURL(url);
    }

    public void GabrielDiasLinkedin()
    {
        string url = "https://www.linkedin.com/in/gabriel-dias-antunes-antonio-631bb4179/";
        Application.OpenURL(url);
    }

    public void HugoNGLinkedin()
    {
        string url = "https://www.linkedin.com/in/hugo-novo-gouvea";
        Application.OpenURL(url);
    }

    public void IagoLinkedin()
    {
        string url = "https://www.linkedin.com/in/iago-mickael-dos-santos-6a7603234/";
        Application.OpenURL(url);
    }

    public void MarcosGBLinkedin()
    {
        string url = "https://www.linkedin.com/in/marcos-gabriel-barreto-13ab2b164";
        Application.OpenURL(url);
    }

}
