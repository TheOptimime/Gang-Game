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

    public bool beingDamaged;

    int takenDamage;

    public float invulTime;


    void Start()
    {
        cc = GetComponent<CharacterController>();
        _Movement = false;

        anim = GetComponent<Animator>();

        //health = maxHealth;
        health = GameManager.instance.playerHealth;

        direction = 1;

        takenDamage = 1;

        beingDamaged = false;


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


        if (health <= 0)
        {
            GameManager.instance.LoseGame();
        }



        //Debug.Log(Input.GetAxis("Horizontal"));

        //cc.Move(moveposition * Time.deltaTime * speed);
    }

    IEnumerator Invun()
    {
        //print("no change");
        yield return new WaitForSeconds(invulTime);
        beingDamaged = false;
        //print("DONE!!");
    }


    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        //Debug.Log("Should be damaged");
        if (other.gameObject.tag == ("enemy") && beingDamaged == false)
        {
            beingDamaged = true;

            anim.SetTrigger("isHurt");

            //Debug.Log("Should be hurt");

            health -= takenDamage;

            StartCoroutine(Invun());


        }

    }

 



}
