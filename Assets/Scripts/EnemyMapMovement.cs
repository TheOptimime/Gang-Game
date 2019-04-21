using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMapMovement : MonoBehaviour

{
    public class EnemyPlayer
    {

    }
    public BattleArenaTrigger bat;
    public float Speed = 1;
    public float Target; 
    public int greenPoints;
    public int redPoints;
    private int target;
    public CharacterController cc;

    void Start()
    {
        bat = FindObjectOfType<BattleArenaTrigger>();
        cc = gameObject.AddComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        //cc.Move(Vector3.MoveTowards(transform.position, bat.triggers[0].transform.position, 2f) * Time.deltaTime * 0.1f * Speed);
        //transform.Translate(Vector3.MoveTowards(transform.position, bat.triggers[1].transform.position, 0.001f) * Time.deltaTime * 0.1f);

        if(Vector3.Distance(transform.position, bat.triggers[0].transform.position) > 0)
        {
            cc.Move(Vector3.MoveTowards(transform.position, bat.triggers[0].transform.position, 2f) * Time.deltaTime * 0.08f * -Speed);
        }
        else if(Vector3.Distance(transform.position, bat.triggers[0].transform.position) < 0)
        {
            cc.Move(Vector3.MoveTowards(transform.position, bat.triggers[0].transform.position, 2f) * Time.deltaTime * 0.1f * Speed);
        }

        Vector3 movePos = new Vector3();


        movePos.x = -(transform.position.x - bat.triggers[target].transform.position.x);
        //movePos.y = transform.position.y - bat.triggers[target].transform.position.y;
        movePos.z = -(transform.position.z - bat.triggers[target].transform.position.z);



        cc.Move(movePos * Speed* Time.deltaTime);

        print(movePos);
    
    }
}
