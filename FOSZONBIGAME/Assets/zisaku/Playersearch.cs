using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Playersearch : MonoBehaviour
{
    public Transform targetObject;
    // Start is called before the first frame update
    /// <summary>
    /// 目標到達オブジェクト
    /// </summary>
    public GameObject goal;
    public NavMeshAgent agent;
    /// <summary>
    /// 距離
    /// </summary>
    public float distance;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //agent = GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        goal = GameObject.Find("Player");
        Debug.Log("プレイヤー");

        if (other.tag == "Player")
        {
            Debug.Log("まいあひー");
            Debug.Log(distance);
            if (distance < 1)
            {
                distance = Vector3.Distance(transform.position, goal.transform.position);
                agent.destination = goal.transform.position;
                transform.LookAt(targetObject);
            }
        }

    }
}
