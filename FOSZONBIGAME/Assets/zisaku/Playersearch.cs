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
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("プレイヤー");

        if (other.tag == "Player")
        {
            Debug.Log("まいあひー");
            transform.LookAt(targetObject);
            distance = Vector3.Distance(transform.position, goal.transform.position);
            Debug.Log(distance);
            if (distance < 1)
            {
                agent.destination = goal.transform.position;
            }
        }

    }
}
