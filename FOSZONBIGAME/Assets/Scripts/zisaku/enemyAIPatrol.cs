using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAIPatrol : MonoBehaviour
{
    /// <summary>
    /// 巡回地点のオブジェクトを格納する配列
    /// </summary>
    public Transform[] point;
    /// <summary>
    /// ナビメッシュエージェント
    /// </summary>
    public NavMeshAgent enemy;
    /// <summary>
    /// 巡回地点のオブジェクト数
    /// </summary>
    public int roundPoint = 0;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
