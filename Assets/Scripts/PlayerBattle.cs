using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerBattle : MonoBehaviour


{
    // Start is called before the first frame update
    [Range(1,5)]
    public int speed;
        CharacterController cc;

    Animator anim;

    public bool _Movement;

    public int health, maxHealth;

    int direction;

    bool beingDamaged;

    int takenDamage;

    float invulTime;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        _Movement = false;

        anim = GetComponent<Animator>();

        health = maxHealth;

        direction = 1;

        takenDamage = 1;

        StartCoroutine(Invinsible());
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetAxisRaw("Horizontal")!=0||Input.GetAxisRaw("Vertical") !=0)
        {
            anim.SetBool("isMoving", true);

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                cc.Move(Vector3.right * Input.GetAxis("Horizontal") * speed);
                print("should animate");
             


                if (Input.GetAxisRaw("Horizontal") > 0)
                {


                    if (direction < 0)
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                        direction *= -1;
                    }
                }


                if (Input.GetAxisRaw("Horizontal") < 0)
                {


                    if (direction > 0)
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
                        direction *= -1;
                    }
                }
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                cc.Move(Vector3.up * Input.GetAxis("Vertical") * speed);
                print("should also animate");

            }
        }

        else
        {
            anim.SetBool("isMoving", false);
        }



        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("isAttacking");
        }

        //Debug.Log(Input.GetAxis("Horizontal"));


        IEnumerator Example();
        {
            print ("no change")
            yield return new WaitForSeconds(2);
            invulTime = false;
            print("DONE!!");
        }


        //cc.Move(moveposition * Time.deltaTime * speed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (other.gameObject.tag == ("enemy") && invulTime = false)
        {
            invulTime = true;
            health -= takenDamage;


        }

    }



}
