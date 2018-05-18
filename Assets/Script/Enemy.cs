using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int enemyHP = 3; // 敵の体力
    //public static int enemyHP_global;
    public int enemyAttack = 1;
    public static int enemyAttack_Global;
    public GameObject Bomb; // 爆発のオブジェクト
    Animator anim;
    
    public static bool damageflag = false; //敵が攻撃を受けたかどうかのフラグでtrueなら受ける
    public static bool stopflag;
    GameObject Obstacle;
    //bool my_Downflag = false;
    
    bool downflag = false; //敵が倒れるかどうかのフラグでtrueなら倒れる
    bool AttackStart = true;
    float distance;
    int DownAnimSpeed;
    public float AttackSpeed;
    //Collider nowCol;
    int AttackFlag = 0;
    int DownFlag = 0;
    float timer;
    int A_Interval;
    Vector3 EnemyPos;
    UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
    GameObject target;
    //GameObject player; //プレイヤー
    Vector3 TargetPos;
    /*ScoreManager.instance.enemyCount++;
    Destroy(gameObject); //自分をしょうめつさせる*/
    void Start(){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyAttack_Global = enemyAttack;
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Gate");
    }

    void Damage(){
        enemyHP--; //体力を1減らす。
        target = GameObject.FindGameObjectWithTag("Player"); 
        // 体力がゼロになったら
        if (enemyHP <= 0){
            if (Bomb){
                print("Down");
                downflag = true;
                //this.GetComponent<Animator>().SetTrigger("Down");
                agent.isStopped = true;
                Instantiate(Bomb, transform.position, transform.rotation);   // 爆発を起こす
            }
        }
    }
   

    // 物にさわった時に呼ばれる
    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Player"){
            agent.isStopped = true;
            target = GameObject.FindGameObjectWithTag("Player");
            PlayerScript.damageflag = true;
            PlayerScript.PlayerDamage(enemyAttack);
            print("触れた");
            if (AttackStart) {
                AttackFlag = 1;
                //EnemyPos = gameObject.transform.position;
                AttackStart = false;
            }
            
        }
        
        else if (col.gameObject.tag == "WallwithHP"){
            agent.isStopped = true;
            target = col.gameObject;
            Obstacle = col.gameObject;
            if (AttackStart) { 
                AttackFlag = 1;
               // EnemyPos = gameObject.transform.position;
                AttackStart = false;
            }
        }
        
        else if (col.gameObject.tag == "Gate"){
            agent.isStopped = true;
            if (AttackStart){
                AttackFlag = 1;
               // EnemyPos = gameObject.transform.position;
                AttackStart = false;
            }
        }


    }
    // Update is called once per frame
    void Update(){
        print(target);
        timer = Time.deltaTime;
        if (!MoveToPM.pm_flag){
            agent.SetDestination(target.transform.position);//目的地設定(ナビゲーション)
            if(AttackFlag > 0) {
                Attack();
            }
            //倒れていない且つ門がターゲットでない時
            if (downflag == false && target != GameObject.FindGameObjectWithTag("Gate")){
                //ターゲットの距離と敵の距離が5を超えれば
                if ((Mathf.Abs((target.transform.position.x) - (this.transform.position.x)) > 5
                    || Mathf.Abs((target.transform.position.z) - (this.transform.position.z)) > 5)){
                    AttackFlag = 0; //攻撃をやめる
                    AttackStart = true;
                    agent.isStopped = false; //追跡を開始
                    
                   
                }
                //ターゲットの距離と敵の距離が10を超えれば
                if (Mathf.Abs((target.transform.position.x) - (this.transform.position.x)) > 10
                    || Mathf.Abs((target.transform.position.x) - (this.transform.position.x)) > 10){
                    target = GameObject.FindGameObjectWithTag("Gate"); //ターゲットを再び門に
                }
                //ターゲットが障害物であれば
                if (target == GameObject.FindGameObjectWithTag("WallwithHP")){
                    //ターゲットのHPが0の時
                    if (target.GetComponent<ObstacleScript>().obstacleHP <= 0){
                        print("target");
                        AttackFlag = 0; //攻撃をやめる
                        target = GameObject.FindGameObjectWithTag("Gate"); //ターゲットを門に切り替え
                        agent.isStopped = false; //追跡を開始
                        
                    }
                }
            }
          }


    }

    void Attack() {
        if (AttackFlag == 1){
            if (distance >= 0.0f && distance < 3.0f){
                gameObject.transform.Translate(0.0f, 0.0f, -AttackSpeed * timer);
                distance += AttackSpeed * timer;
                print("1段階目");
            }
            else if (distance >= 3.0f && distance < 6.0f){
                print("2段階目");
                gameObject.transform.Translate(0.0f, 0.0f, AttackSpeed * timer);
                distance += AttackSpeed * timer;
            }
            else{
                print("3段階目");
                A_Interval++;
                if (A_Interval > 60){
                    A_Interval = 0;
                    distance = 0.0f;
                }
                
            }
           
         }
    }
}

/*
if (AttackFlag == 2){

    gameObject.transform.Translate(0.0f, 0.0f, AttackSpeed * timer);
    distance += AttackSpeed * timer;
    if (distance < 2.0f){
        distance = 0.0f;
        AttackFlag = 3;
    }
}

if (AttackFlag == 3){

    if (distance > 3.0f){
        //gameObject.transform.position.z = EnemyPos.z;
        A_Interval++;
        if (A_Interval > 40){
            AttackFlag = 1;
            A_Interval = 0;
            distance = 0.0f;
        }

    }
    else {
        gameObject.transform.Translate(0.0f, 0.0f, -AttackSpeed * timer);
        distance += AttackSpeed * timer;
    }
}*/
