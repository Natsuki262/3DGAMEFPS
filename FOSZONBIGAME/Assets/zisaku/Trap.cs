using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyZonbi;
    [SerializeField]
    Transform Player;
    [SerializeField] float SpawnPos = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("トラップ起動");
            //Instantiate(enemyZonbi, new Vector3(Player.position.x, 0, Player.position.z + SpawnPos), Quaternion.identity);
            Instantiate(enemyZonbi,this.transform.position,Quaternion.identity);
            
        }
    }
}
