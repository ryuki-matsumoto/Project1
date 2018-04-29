using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {

    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if(EnemyScript.downflag == true) {
            GetComponent<Animator>().SetTrigger("Down");
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("finish")){
           Destroy(transform.parent.gameObject); //自分をしょうめつさせる
        }

        if(EnemyScript.attackflag == true){
            anim.SetBool("Attack", true);
        }

    }
}
