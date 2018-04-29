using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int enemyHP = 3; // 敵の体力
	public GameObject Bomb; // 爆発のオブジェクト
    Animator anim;
    UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
    GameObject player; //プレイヤー
    public bool downflag = false;


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
                // 爆発を起こす
                downflag = true;
                Instantiate(Bomb, transform.position, transform.rotation);
                GetComponent<Animator>().SetTrigger("Down");
               
            }
            // 敵を倒した数を1増やす
            ScoreManager.instance.enemyCount++;
            //Destroy(this.gameObject); //自分をしょうめつさせる

        }
    }
    // 物にさわった時に呼ばれる
    void OnTriggerEnter(Collider col)
    {
        // もしPlayerにさわったら
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("Damage"); //ダメージを与えて
        }
        // 自分は消える
        Destroy(this.gameObject);
    }

  

    // Update is called once per frame
    void Update()
    {
        if (downflag != true){
            // 目的地をプレイヤーに設定する。
            agent.SetDestination(player.transform.position);
           

        }
       
    }

    // Playerにダメージを与えられた時
   
}
