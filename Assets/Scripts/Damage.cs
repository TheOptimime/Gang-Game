using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public int damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("enemy"))
        {
            other.gameObject.GetComponent<Enemy>().health -= damage;

        }
    
    }
}
