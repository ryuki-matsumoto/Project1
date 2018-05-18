using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {

    private Animator anim;
    public bool AttackAnim_flag = false;
    public bool DownAnim_flag = false;
    
    //public static bool thisObject;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
       // thisObject = this.gameObject.GetComponent<EnemyAnimation>();
	}

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            PlayerScript.damageflag = true;
            PlayerScript.PlayerDamage(this.transform.parent.GetComponent<EnemyScript>().enemyAttack);
            //other.gameObject.GetComponent<PlayerScript>().playerHP -= this.transform.parent.GetComponent<EnemyScript>().enemyAttack;
        }

        else if (other.gameObject.tag == "Gate"){
            GateScript.GateDamage(this.transform.parent.GetComponent<EnemyScript>().enemyAttack);
        }

        else if(other.gameObject.tag == "WallwithHP") {
            //ObstacleScript.damage_flag = 2;
            other.gameObject.GetComponent<ObstacleScript>().obstacleHP -= this.transform.parent.GetComponent<EnemyScript>().enemyAttack;
        }  

    }

    // Update is called once per frame
    void Update () {
        if(DownAnim_flag == true) {
            print("Down");
            this.GetComponent<Animator>().SetTrigger("Down");
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Finish")){
           Destroy(this.transform.parent.gameObject); //自分をしょうめつさせる
            ScoreManager.instance.enemyCount++;
        }

        if(AttackAnim_flag == true){
            anim.SetBool("Attack", true);
        }
        else if(AttackAnim_flag == false){
            anim.SetBool("Attack", false);
        }

    }
}
