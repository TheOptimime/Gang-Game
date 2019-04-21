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
    // Start is called before the first frame update
    // ontriggerenter  scenemanager
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            SceneManager.LoadScene(1);
            Debug.Log("Trigger Active");
        }
       
        
    }
    void Update()
    {
        
      

    }
}