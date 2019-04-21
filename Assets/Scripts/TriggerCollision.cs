using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCollision : MonoBehaviour

{
  public enum ZoneColor
    {
        Blue,
        Green,
        Red,
        Nuetral,
    }
    public ZoneColor zoneColor;
    public int sceneNumber;
  
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)

    {
        if (other.transform.tag == "Player")
        {
            SceneManager.LoadScene(sceneNumber);

        }


    }
}
