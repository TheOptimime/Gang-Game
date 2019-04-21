using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public static GameManager instance;
    public static int numberOfEnemies;
    public static int score, redScore, greenScore;
    public string overworldScene, loseGameScene, winGameScene;

    public int playerHealth;

    public EnemyMapMovementInfo[] emmis;

    bool overworldInitialLoad;

    BattleArenaTrigger bat;

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
        bat = FindObjectOfType<BattleArenaTrigger>();

        for(int i = 0; i < bat.triggerCollisions.Length; i++)
        {
            //bat.triggerCollisions[i].zoneColor;
        }

    }

    void Update()
    {
       // print(numberOfEnemies);
        
        currentTime -= 1 * Time.deltaTime;
        countdownTimer.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            gameState = GameState.EndGame;
        }

        if(gameState == GameState.InOverworld)
        {
            if (overworldInitialLoad != true)
            {
                EnemyMapMovement[] emms = FindObjectsOfType<EnemyMapMovement>();
                
                for (int i = 0; i < emms.Length; i++)
                {
                    if(emms[i] != null)
                    {
                        emms[i].SetEnemyMapMovementData(emmis[i]);
                    }
                    else
                    {
                        emmis[i] = emms[i].StoreEnemyMapMovementData();
                    }
                    
                }



                overworldInitialLoad = true;
            }
            
        }
        else if(gameState == GameState.InBattle)
        {
            overworldInitialLoad = false;

            if(numberOfEnemies <= 0)
            {
                numberOfEnemies = 0;
                gameState = GameState.InOverworld;
                
                SceneManager.LoadScene(overworldScene);
            }
        }
        else if(gameState == GameState.EndGame)
        {
            if(currentTime <= 0)
            {
                // First Pass of Win Condition
                if(score > redScore && score > greenScore)
                {
                    SceneManager.LoadScene(winGameScene);
                }
            }

            SceneManager.LoadScene(loseGameScene);
        }
        

        // Update is called once per frame

    }

    public void LoseGame()
    {
        gameState = GameState.EndGame;
    }

}