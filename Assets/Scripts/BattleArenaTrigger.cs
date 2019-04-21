using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BattleArenaTrigger : MonoBehaviour
{

    public GameObject[] triggers;
    public TriggerCollision[] triggerCollisions;
    /*
    public GameObject Trigger01;
    public GameObject Trigger02;
    public GameObject Trigger03;
@ -32,22 +28,12 @@ public class BattleArenaTrigger : MonoBehaviour{
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
}
