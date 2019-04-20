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
    


    void Start()
    {
        cc = GetComponent<CharacterController>();
        _Movement = false;

        anim = GetComponent<Animator>();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 moveposition = new Vector3();

        //moveposition.x = (Input.GetAxis("Horizontal"));

        //moveposition.y = (Input.GetAxis("Vertical"));


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            cc.Move(Vector3.right * Input.GetAxis("Horizontal") * speed);

            anim.SetBool("isMovingRight", true);

            _Movement = true;
        }
        else
        {
            anim.SetBool("isMovingRight", false);
        }





        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            cc.Move(Vector3.right * Input.GetAxis("Horizontal") * speed);

            anim.SetBool("isMovingLeft", true);

            _Movement = true;
        }
        else
        {
            anim.SetBool("isMovingLeft", false);
        }



        if (Input.GetAxisRaw("Vertical")!= 0)
        {
            cc.Move(Vector3.up * Input.GetAxis("Vertical") * speed);
            _Movement = true;
        }
        else
        {
            _Movement = false;
        }



        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("isAttacking");
        }

        Debug.Log(Input.GetAxis("Horizontal"));


        //cc.Move(moveposition * Time.deltaTime * speed);
    }


}
