using System.Collections; using System.Collections.Generic; using UnityEngine;  public class Enemy_movement : MonoBehaviour {      public Transform target;     public float speed;     Animator animation;     int direction;     // Start is called before the first frame update     void Start()     {         direction = 1;         animation = GetComponent<Animator>();          target = FindObjectOfType<Player>().transform;     }     // Update is called once per frame     void Update()     {
            Vector3 distance = transform.position - target.position;
            Vector3 movePos = new Vector3();

            if (distance.x > 0)
            {
                animation.SetBool("Move", true);
                movePos.x = speed * -1; 
            }
            else if (distance.x < 0)
            {
                animation.SetBool("Move", true);
                movePos.x = speed; 
            }
            if (distance.y > 0)
            {
                movePos.y = speed * -1;
                animation.SetBool("Move", true);
            }
            else if (distance.y < 0)
            {
                movePos.y = speed;
                animation.SetBool("Move", true);
            }
        if (distance.x < 0)
        {


            if (direction < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                direction *= -1;
            }
        } 
        if (distance.x > 0)
        {

            if (direction > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                direction *= -1;
            }
        }         if (distance.x < 20)         {             animation.SetBool("isAttacking",true);         }         if (distance.x > -20)         {             animation.SetBool("isAttacking", true);         }         if (distance.x > 20)         {             animation.SetBool("isAttacking", false);         }         if (distance.x < -20)         {             animation.SetBool("isAttacking", false);         }

        transform.Translate(movePos * Time.deltaTime * speed);
    }                
}