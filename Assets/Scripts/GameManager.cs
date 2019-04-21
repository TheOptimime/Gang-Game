﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public static GameManager instance;
    public static int numberOfEnemies;

    public string overworldScene;

    public enum GameState
    {
        InOverworld,
        InBattle,
        EndGame
    }

    public static GameState gameState;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    float currentTime = 0f;
    float startingTime = 600f;

    [SerializeField] Text countdownTimer;



    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(this.gameObject);
        }

        currentTime = startingTime;
    }

    void Update()
    {
        print(numberOfEnemies);
        
        currentTime -= 1 * Time.deltaTime;
        countdownTimer.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            gameState = GameState.EndGame;
        }

        if(gameState == GameState.InOverworld)
        {

        }
        else if(gameState == GameState.InBattle)
        {
            if(numberOfEnemies <= 0)
            {
                numberOfEnemies = 0;
                gameState = GameState.InOverworld;
                
                SceneManager.LoadScene(overworldScene);
            }
        }
        

        // Update is called once per frame

    }

}