using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed = 0f;

    Ray playerRay;//playerからだすレイ
    RaycastHit hit;//衝突したオブジェクトの情報を格納する変数
    float distance = 100;//飛ばすRayの長さ

    private Vector3 playerPos;

    private float x;//x方向
    private float z;//z方向

    private Rigidbody rigid;


    [SerializeField] float m_turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GetComponent<Transform>().position;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //x = Input.GetAxisRaw("Horizontal");//x方向の値を取得
        //z = Input.GetAxisRaw("Vertical");
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        //入力方向のベクトルを作成
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        //rigid.velocity = new Vector3(x * speed, 0, z * speed);

        //Vector3 diff = transform.position - playerPos;

        /*if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff);
        }*/
        /*float minangle = 0.0f;
        float maxAngle = 90.0f;
       

        float angle = Mathf.LerpAngle(minangle, maxAngle, Time.time);
        transform.eulerAngles = new Vector3(0, angle, 0);*/
        var mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.Log("カメラないよ");
        }
        else
        {
            Debug.Log("カメラあるよ");
        }
        if (dir == Vector3.zero)
        {
            //方向の入力がneutralの時はy軸方向の速度を維持
            rigid.velocity = new Vector3(0f, rigid.velocity.y, 0f);
        }
        else
        {
            dir = Camera.main.transform.TransformDirection(dir);
            //メインカメラを基準に入力方向ベクトルを変換
            dir.y = 0;//y軸方向はゼロにして水平方向つまり
                      //後ろに変換

            //滑らかに回転
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation
                , targetRotation, Time.deltaTime * m_turnSpeed);

            Vector3 velo = dir.normalized * speed;
            rigid.velocity = velo;
        }










        //レイの生成（レイの原点、レイの飛ぶ方向）
        playerRay = new Ray(transform.position, transform.forward);

        //レイの判定（飛ばすレイ、レイが当たったものの情報、レイの長さ

        if (Physics.Raycast(playerRay, out hit))
        {
            //Rayが当たった時の処理
            //当たったものの情報はhitの中に格納されてる;
            Debug.Log(hit);
            Debug.DrawRay(playerRay.origin, playerRay.direction * distance, Color.red);

        }
    }
}
