using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    // Start is called before the first frame update

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
            cc.Move(Vector3.right * Input.GetAxis("Horizontal"));
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            cc.Move(Vector3.forward * Input.GetAxis("Vertical"));
        }

    }
}
