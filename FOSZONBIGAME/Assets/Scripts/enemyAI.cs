using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    //エージェント
  
    public NavMeshAgent enemy;//ナビメッシュｴｰｼﾞｪﾝﾄ
   

    public GameObject player;//目標

    Vector3 playerPos;

    [SerializeField]
    public float distance;//目標との距離

    public Transform other;

    float playerisitance;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.Find("player");
        playerisitance = Vector3.Distance(other.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = transform.position;
        /*if(player!=null)
        {
            enemy.destination = player.transform.position;
        }*/
        //enemy.destination = player.transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(playerisitance);
        
        if (distance < 5)
        {
            enemy.speed = enemy.remainingDistance - enemy.stoppingDistance;
            enemy.destination = player.transform.position;

        }

        else if (distance < 3)
        {
            //enemy.stoppingDistance(3.0f); 
        }
       //NavMeshAgent.stoppin
    }
}
