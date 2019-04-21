using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCollision : MonoBehaviour
{
    private EnemyMapMovement enemyMapMovement;
    public GameObject Player;
    public ZoneColor zoneColor;
    public int sceneNumber;
    private GameObject EnemyPlayerRed;
    private GameObject EnemyPlayerGreen;
    public enum ZoneColor
    {
        Blue,
        Green,
        Red,
        Nuetral,
    }
    

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag=="Player")
        {
            SceneManager.LoadScene(1);
            Debug.Log("Trigger Active");
        }

        if (other.gameObject.tag == "MapEnemy")
        {
            other.gameObject.transform.position = new Vector3(-100, -100, -100);
            Debug.Log("EnemyTriggerActive");
        }
       
        
    }
    void Update()
    {
        
      

    }
}