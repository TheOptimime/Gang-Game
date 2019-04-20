using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerBattle : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(1,5)]
    public float speed;
        CharacterController cc;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Horizontal")!=0)
        {
            cc.Move(Vector3.right * Input.GetAxis("Horizontal") * speed);
        }

        if (Input.GetAxis("Vertical")!= 0)
        {
            cc.Move(Vector3.up * Input.GetAxis("Vertical") * speed);
        }
    }
}
