using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMapMovement : MonoBehaviour

{
    
    public BattleArenaTrigger bat;
    public float speed = 1;
    public int greenPoints;
    public int redPoints;
    public int target;
    public CharacterController cc;
    public bool hidden;
    public GangColor gangColor;

    public GameObject SpawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        bat = FindObjectOfType<BattleArenaTrigger>();
        cc = gameObject.AddComponent<CharacterController>();

        if(SpawnPoints == null)
        {
            SpawnPoints = GameObject.Find("SpawnPoints");
        }

        Transform[] spawnPoints = GetComponentsInChildren<Transform>();

        transform.position = spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position;

    }

    // Update is called once per frame
    void Update()
    {
        //cc.Move(Vector3.MoveTowards(transform.position, bat.triggers[0].transform.position, 2f) * Time.deltaTime * 0.1f * Speed);
        //transform.Translate(Vector3.MoveTowards(transform.position, bat.triggers[1].transform.position, 0.001f) * Time.deltaTime * 0.1f);


        Vector3 movePos = new Vector3();
      //  print(target + " : " + bat.triggers[target].name);

        if(transform.position.x - bat.triggers[target].transform.position.x < 0)
        {
           // print("x before");
            movePos.x = speed;
        }
        else if(transform.position.x - bat.triggers[target].transform.position.x > 0)
        {
            //print("x over");
            movePos.x = speed * -1;
        }

        if(transform.position.z - bat.triggers[target].transform.position.z < 0)
        {
           // print("z before");
            movePos.z = speed;
        }
        else if(transform.position.z - bat.triggers[target].transform.position.z > 0)
        {
           // print("z over");
            movePos.z = speed * -1;
        }

        


        cc.Move(movePos * Time.deltaTime);

       // print(bat.triggers[target].transform.position);


    }

    public void SetEnemyMapMovementData(EnemyMapMovementInfo emmi)
    {
        //emmi = new EnemyMapMovementInfo();
        target = emmi.target;
        speed = emmi.speed;
        transform.position = emmi.position;
        gangColor = emmi.gangColor;
    }

    public EnemyMapMovementInfo StoreEnemyMapMovementData()
    {
        EnemyMapMovementInfo emmi = new EnemyMapMovementInfo();
        emmi.target = target;
        emmi.speed = speed;
        emmi.position = transform.position;
        emmi.gangColor = gangColor;

        return (emmi);
    }

}

public class EnemyMapMovementInfo
{
    public Vector3 position;
    public int target;
    public float speed;
    public GangColor gangColor;
}