using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update


    public int health, maxHealth;

    bool isDamaged;
    

    public float bufferTime;
    public float bufferMaxTime;


    void Start()
    {
        health = maxHealth;

        


    }

    // Update is called once per frame
    void Update()
    {

        if (!isDamaged)
        {

            if (isDamaged)
            {
                isDamaged = false;

                bufferTime = bufferMaxTime;
            }
        }

        
    }
}
