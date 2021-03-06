﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public int enemyHP = 3; // 敵の体力
    public static int enemyHP_global;
    public int enemyAttack = 1;
    public static int enemyAttack_Global;
	public GameObject Bomb; // 爆発のオブジェクト
    Animator anim;
    UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
    GameObject target;
    GameObject player; //プレイヤー
    public static bool downflag = false; //敵が倒れるかどうかのフラグでtrueなら倒れる
    public static bool attackflag = false; //敵が攻撃するかどうかのフラグでtrueなら倒れる
    public static bool damageflag = false; //敵が攻撃を受けたかどうかのフラグでtrueなら受ける
    public static bool stopflag;
    private bool pFollow_flag = false;
    private bool wFollow_flag = false;
    private bool gFollow_flag = false;
    GameObject Obstacle;
    bool my_Downflag = false;

    void Start(){
        enemyHP_global = enemyHP;
        enemyAttack_Global = enemyAttack;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Gate");
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void Damage(int attack){
        enemyHP -= attack; //体力を1減らす。
        target = GameObject.FindGameObjectWithTag("Player");
      // 体力がゼロになったら
        if (enemyHP <= 0){
            if (Bomb){
                // EnemyAnimation.DownAnim_flag = true;
                // downflag = true;
                print("aaaa");
                this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().DownAnim_flag = true;
                agent.isStopped = true;
                Instantiate(Bomb, transform.position, transform.rotation);   // 爆発を起こす 
            }
            // 敵を倒した数を1増やす
        }
    }
    /*
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "WallwithHP") {
            //EnemyAnimation.AttackAnim_flag = true;
            this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().AttackAnim_flag = true;
            agent.isStopped = true;
            target = collision.gameObject;
            Obstacle = collision.gameObject;
            print("AgentStop");


        }
    }*/

    // 物にさわった時に呼ばれる
    void OnTriggerEnter(Collider col){
       
        if(col.gameObject.tag == "Player") {
            //EnemyAnimation.AttackAnim_flag = true;
            this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().AttackAnim_flag = true;
            agent.isStopped = true;
            target = GameObject.FindGameObjectWithTag("Player");
            
        }

        else if (col.gameObject.tag == "WallwithHP"){
            //EnemyAnimation.AttackAnim_flag = true;
           
                this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().AttackAnim_flag = true;
                agent.isStopped = true;
                target = col.gameObject;
                Obstacle = col.gameObject;
                print("AgentStop");
           
            
        }

        else if (col.gameObject.tag == "Gate"){
            //EnemyAnimation.AttackAnim_flag = true;
            this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().AttackAnim_flag = true;
            agent.isStopped = true;
            
          
        }


    }
    // Update is called once per frame
    void Update()
    {
        if (!MoveToPM.pm_flag)
        {
            //目的地をターゲットに設定する
            agent.SetDestination(target.transform.position);
            /*
            if (enemyHP <= 0){
                if (Bomb){
                    print("aaaa");
                    this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().DownAnim_flag = true;
                    agent.isStopped = true;
                    Instantiate(Bomb, transform.position, transform.rotation);   // 爆発を起こす 
                }
                // 敵を倒した数を1増やす
            }*/

            if (this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().DownAnim_flag == false
                && target != GameObject.FindGameObjectWithTag("Gate")){

                if ((Mathf.Abs((target.transform.position.x) - (this.transform.position.x)) > 5
                    || Mathf.Abs((target.transform.position.z) - (this.transform.position.z)) > 5)){

                    agent.isStopped = false;
                    this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().AttackAnim_flag = false;

                }

                if (Mathf.Abs((target.transform.position.x) - (this.transform.position.x)) > 10
                    || Mathf.Abs((target.transform.position.x) - (this.transform.position.x)) > 10){

                    target = GameObject.FindGameObjectWithTag("Gate");
                }
                if (target.GetComponent<ObstacleScript>().obstacleHP <= 0){
                    print("target");
                    agent.isStopped = false;
                    this.transform.GetChild(1).gameObject.GetComponent<EnemyAnimation>().AttackAnim_flag = false;
                    target = GameObject.FindGameObjectWithTag("Gate");
                }
            }
        }
        



    }

   

}
