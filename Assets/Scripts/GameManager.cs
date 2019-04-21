using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour

{
    public static GameManager instance;
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
        
        currentTime -= 1 * Time.deltaTime;
        countdownTimer.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;

        }

        // Update is called once per frame

    }

}