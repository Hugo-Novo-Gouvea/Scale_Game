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

    public GameObject TryAgainBtn;
    public GameObject MenuBtn;

    private AudioSource audioSource;

    public float time;

    public Text ScoreText;

    private int point;
    private float pointTime;
    public bool start = false, startMusic;
    public bool collided = false;

    void Start()
    {
        point = 0;
        startMusic = true;
        audioSource = GetComponent<AudioSource>();
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
            point += currentPlayer.GetComponent<PlayerController>().CurrentScale;
            ScoreText.text = point.ToString();
            pointTime = 0;
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
