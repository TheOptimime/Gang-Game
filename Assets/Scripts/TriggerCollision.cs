using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCollision : MonoBehaviour
{
    
    public GangColor zoneColor;
    public int sceneNumber;
    // Start is called before the first frame update
    // ontriggerenter  scenemanager
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        {
            if (other.gameObject.tag == "Player")
            {
                GameManager.instance.SwitchToCombat(zoneColor);
                //SceneManager.LoadScene(1);
                Debug.Log("Trigger Active");
            }

            if (other.gameObject.tag == "MapEnemy")
            {
                zoneColor = other.gameObject.GetComponent<EnemyMapMovement>().gangColor;
                other.gameObject.transform.position = new Vector3(-100, -100, -100);
                Debug.Log("EnemyTriggerActive");
            }


        }

    }
    void Update()
    {
        
      

    }
}