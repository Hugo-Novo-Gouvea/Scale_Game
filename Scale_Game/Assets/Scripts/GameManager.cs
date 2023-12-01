using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerPosition;
    public GameObject PillarSpawner;
    public GameObject MainCamera;
    public GameObject Score;
    public GameObject ScoreCanvas;
    public GameObject Instructions;

    public GameObject TryAgainBtn;
    public GameObject MenuBtn;

    private AudioSource audioSource;

    public float time, instructionsOffTimer;

    public Text ScoreText;

    private int point, change, currentScale;
    private float pointTime;
    public bool start = false, startMusic, instructionsOff = false;
    public bool collided = false;

    void Start()
    {
        point = 0;
        startMusic = true;
        audioSource = GetComponent<AudioSource>();
        instructionsOffTimer = 0;
    }

    void Update()
    {
        if (start == true)
        {
            time += Time.deltaTime;
        }

        if (start == true && startMusic == true)
        {
            playMusic();
            startMusic = false;
        }

        pointTime += Time.deltaTime;

        if (pointTime >= 1 && start == true && collided == false)
        {
            GameObject currentPlayer = GameObject.FindGameObjectWithTag("Player");
            currentScale = currentPlayer.GetComponent<PlayerController>().CurrentScale;
            if(currentScale == 1)
            {
                change = 1; 
                point += change;
            }
            if (currentScale == 2)
            {
                change = 3;
                point += change;
            }
            if (currentScale == 3)
            {
                change = 5;
                point += change;
            }
            ScoreText.text = point.ToString();
            pointTime = 0;
        }

        if(instructionsOff == true)
        {
            instructionsOffTimer += Time.deltaTime;
            if(instructionsOffTimer >= 6)
            {
                Instructions.SetActive(false);
            }
        }
    }

    public void newVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void startGame()
    {
        start = true;
        collided = false;
        point = 0;
        MainCamera.transform.position = new Vector3(0, 0, -10);
        Instantiate(Player, PlayerPosition.transform.position, PlayerPosition.transform.rotation);
        PillarSpawner.GetComponent<PillarSpawner>().start = true;
        Instructions.SetActive(true);
        instructionsOffTimer = 0;
        instructionsOff = true;
        Score.SetActive(true);
        ScoreCanvas.SetActive(true);
    }

    public void stopGame()
    {
        PillarSpawner.GetComponent<PillarSpawner>().start = false;
    }

    public void afterMenu()
    {
        TryAgainBtn.SetActive(true);
        MenuBtn.SetActive(true);
        Instructions.SetActive(false);
    }

    public void playMusic()
    {
        audioSource.Play();
    }

    public void stopMusic()
    {
        audioSource.Stop();
    }
}
