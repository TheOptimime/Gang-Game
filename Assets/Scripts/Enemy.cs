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

    Animator animator;
    bool init;



    void Start()
    {
        health = maxHealth;
        isDamaged = false;
        


    }

    // Update is called once per frame
    void Update()
    {
        if (!init)
        {
            GameManager.numberOfEnemies++;
            init = true;
        }
        if(health <= 0)
        {
            GameManager.numberOfEnemies--;
            Destroy(this.gameObject);
        }

        if (isDamaged==true)
        {
            StartCoroutine(Buffer());



            //health change
            //set isDamaged to false
            
        }


               


    }
    IEnumerator Buffer()
    {
        print("waiting");
        animator.SetTrigger("hitTaken");
        yield return new WaitForSeconds(bufferTime);

        print("done");
        isDamaged = false; 

    }
   
}
