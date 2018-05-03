using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {

    private Animator anim;
    public static bool AttackAnim_flag = false;
    public static bool DownAnim_flag = false;

    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        
	}

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            PlayerScript.damageflag = true;
        }

        else if (other.gameObject.tag == "Gate"){
            ObstacleScript.damage_flag = 1;
        }

        else if(other.gameObject.tag == "WallwithHP") {
            ObstacleScript.damage_flag = 2;
        }  

    }

    // Update is called once per frame
    void Update () {
        if(DownAnim_flag == true) {
            GetComponent<Animator>().SetTrigger("Down");
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("finish")){
           Destroy(transform.parent.gameObject); //自分をしょうめつさせる
        }

        if(AttackAnim_flag == true){
            anim.SetBool("Attack", true);
        }
        else if(AttackAnim_flag == false){
            anim.SetBool("Attack", false);
        }

    }
}
