using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int enemyHP = 3; // 敵の体力
	public GameObject Bomb; // 爆発のオブジェクト
    Animator anim;
    UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
    GameObject player; //プレイヤー
    public static bool downflag = false;
    public static bool attackflag = false;
    public GameObject colplayer;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Damage()
    {
        enemyHP--; //体力を1減らす。
                   // 体力がゼロになったら
        if (enemyHP == 0)
        {
            if (Bomb)
            {
                downflag = true;
                // 爆発を起こす
                Instantiate(Bomb, transform.position, transform.rotation);
                         
            }
            // 敵を倒した数を1増やす
            ScoreManager.instance.enemyCount++;

        }
    }
    // 物にさわった時に呼ばれる
    void OnTriggerEnter(Collider col)
    {
        

        if(col.gameObject.tag == "Player" || col.gameObject.tag == "WallwithHP") {
            attackflag = true;
            agent.isStopped = true;
        }


        if (col.transform.position.x < 5 || col.transform.position.z < 5)
        {
            print("aaaa");
            attackflag = false;
            agent.isStopped = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        // 目的地をプレイヤーに設定する。
        agent.SetDestination(player.transform.position);
        if(downflag == true){
            agent.isStopped = true;
        }

        

    }

   

}
