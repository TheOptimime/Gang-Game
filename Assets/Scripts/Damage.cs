using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Enemy
{

    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("enemy") && isDamaged == false);
        {
            isDamaged = true;
            other.gameObject.GetComponent<Enemy>().health -= damage;

        }
    
    }
}
