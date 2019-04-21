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
    public string overworldScene, loseGameScene, winGameScene, combatSceneGreen, combatSceneRed;

    public int playerHealth;
    static bool init;

    public EnemyMapMovementInfo[] emmis;

    static bool overworldInitialLoad;

    static BattleArenaTrigger bat;

    static EnemyMapMovement[] emms;

    public enum GameState
    {
        InOverworld,
        InBattle,
        EndGame
    }

    public static GameState gameState;

    static GangColor[] ZoneColors;

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

        ZoneColors = new GangColor[11];

        

        currentTime = startingTime;
        if(gameState == GameState.InOverworld)
        {
            bat = FindObjectOfType<BattleArenaTrigger>();

            for (int i = 0; i < bat.triggerCollisions.Length; i++)
            {
                ZoneColors[i] = bat.triggerCollisions[i].zoneColor;
            }

            emms = FindObjectsOfType<EnemyMapMovement>();
        }
        

        emmis = new EnemyMapMovementInfo[2];

        
        
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

        if (gameState == GameState.InOverworld)
        {
            for (int i = 0; i < bat.triggerCollisions.Length; i++)
            {
                bat.triggerCollisions[i].zoneColor = ZoneColors[i];
            }

            if (overworldInitialLoad == true)
            {
                emms = FindObjectsOfType<EnemyMapMovement>();

                for (int i = 0; i < emms.Length; i++)
                {
                    if (emms[i] != null || emms[i] == new EnemyMapMovement())
                    {
                        emms[i].SetEnemyMapMovementData(emmis[i]);
                        print("set");
                    }
                    else
                    {
                        //emmis[i] = emms[i].StoreEnemyMapMovementData();
                    }

                }



                overworldInitialLoad = false;
            }
        }
        else if(gameState == GameState.InBattle)
        {
            overworldInitialLoad = true;

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

    public void SwitchToCombat(GangColor color)
    {
        if(emmis[0] == null)
        {
            emmis[0] = new EnemyMapMovementInfo();
        }
        if(emmis[1] == null)
        {
            emmis[1] = new EnemyMapMovementInfo();
        }
        emmis[0] = emms[0].StoreEnemyMapMovementData();
        emmis[1] = emms[1].StoreEnemyMapMovementData();


        gameState = GameState.InBattle;
        numberOfEnemies++;
        if (color == GangColor.Green)
        {
            SceneManager.LoadScene(combatSceneGreen);
        }
        else if(color == GangColor.Red)
        {
            SceneManager.LoadScene(combatSceneRed);
        }
        else
        {
            SceneManager.LoadScene(combatSceneGreen);
        }

        
        
    }

}