using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Instance sebagai global access
    public static GameManager instance;
    int playerScore;
    public Text scoreText;

    public float timeremain = 10;
    public bool timeisrun = false;
    public Text timeText;

    int combo;
    public GameObject tiles;

    // singleton
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        timeisrun = true;
        combo = 1;
    }

    void Update()
    {
        if(timeremain > 0)
        {
            timeremain -= Time.deltaTime;
            DisplayTime(timeremain);
        }
        else
        {
            Debug.Log("Time Out!!");
            timeremain = 0;
            timeisrun = false;
        }
    }
    //Update score dan ui
    public void GetScore(int point)
    {
        playerScore += (point * combo);
        scoreText.text = playerScore.ToString();
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void startCombo(int muchCombo)
    {
        combo = muchCombo;
    }

}
