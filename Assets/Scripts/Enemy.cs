using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    public int health, maxHealth;

    protected bool isDamaged;

    public float bufferTime;
    public float bufferMaxTime;




    void Start()
    {
        health = maxHealth;
        isDamaged = false;

        GameManager.numberOfEnemies++;

    }

    // Update is called once per frame
    void Update()
    {

        if (isDamaged==true)
        {
            StartCoroutine(Buffer());



            //health change
            //set isDamaged to false
            
        }

        if(health <= 0)
        {
            GameManager.numberOfEnemies--;
            Destroy(this.gameObject);
        }
               


    }
    IEnumerator Buffer()
    {
        print("waiting");
        yield return new WaitForSeconds(bufferTime);

        print("done");
        isDamaged = false; 

    }
   
}
