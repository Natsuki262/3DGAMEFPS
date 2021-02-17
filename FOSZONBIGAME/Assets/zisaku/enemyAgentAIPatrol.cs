using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NaviMeshAgentを使うのに必要
using UnityEngine.AI;


public class enemyAgentAIPatrol : MonoBehaviour
{
    /// <summary>
    /// 巡回地点のオブジェクトを格納する配列
    /// </summary>
    public Transform[] points;
    /// <summary>
    /// ナビメッシュエージェント
    /// </summary>
    public NavMeshAgent enemyAgent;
    /// <summary>
    /// 巡回地点のオブジェクト数
    /// </summary>
    public int roundPoint = 0;


    void Start()
    {
        //変数enemyAgentにNavMesh　Agentコンポーネントを格納
        enemyAgent = GetComponent<NavMeshAgent>();

        //エージェントが目的地点についても減速しない
        enemyAgent.autoBraking = false;
        //次の巡回地点の処理を実行
        GotoNextPoint();
        
    }
    //次の巡回地点のを設定する処理
    void GotoNextPoint()
    {
        Debug.Log(roundPoint);
        //巡回地点が設定されていなければ
        if (points.Length == 0)
        {
            return;//処理を返しますなにもなし
        }
        //現在選択されている配列の座標を巡回地点
        //の座標に代入
        enemyAgent.destination = points[roundPoint].position;

        //配列の中から次の巡回地点を選択(必要に応じて繰り返し）
        roundPoint = (roundPoint + 1) % points.Length;

    }

    // Update is called once per frame
    void Update()
    {

        //エージェントが現在の巡回地点に到達したら
        if (!enemyAgent.pathPending && Vector3.Distance(enemyAgent.destination,this.gameObject.transform.position) < 0.5f)
        {
            //次の巡回地点を設定する処理
            GotoNextPoint();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Debug.Log("接触");
        }
    }

}
