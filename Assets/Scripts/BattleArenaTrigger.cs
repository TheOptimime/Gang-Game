using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleArenaTrigger : MonoBehaviour{

    public GameObject[] triggers;
    public TriggerCollision[] triggerCollisions;
    /*
    public GameObject Trigger01;
    public GameObject Trigger02;
    public GameObject Trigger03;
    public GameObject Trigger04;
    public GameObject Trigger05;
    public GameObject Trigger06;
    public GameObject Trigger07;
    public GameObject Trigger08;
    public GameObject Trigger09;
    public GameObject Trigger10;
    public GameObject Trigger11;

    public TriggerCollision trigger1;
    public TriggerCollision trigger2;
    public TriggerCollision trigger3;
    public TriggerCollision trigger4;
    public TriggerCollision trigger5;
    public TriggerCollision trigger6;
    public TriggerCollision trigger7;
    public TriggerCollision trigger8;
    public TriggerCollision trigger9;
    public TriggerCollision trigger10;
    public TriggerCollision trigger11;
    */

    public int sceneNumber;
    //These are the individual names of each trigger, in decending order from left to right. 
     void Start()
    {
        /*
        foreach(GameObject GO in triggers)
        {
            
        }

        for(int i = 0; i < 12; i++)
        {
            triggerCollisions[i].sceneNumber = i;
        }*/
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
