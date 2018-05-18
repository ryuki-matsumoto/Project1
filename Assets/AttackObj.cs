using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObj : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
    GameObject target;
    public int HP;
    public GameObject Bomb;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        print(target);
        
    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.transform.position);
        if (HP <= 0){
                print("aaaa");
                Destroy(gameObject);
                Instantiate(Bomb, transform.position, transform.rotation);   // 爆発を起こす 
          
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.transform.tag == "Player") {
            PlayerScript.playerHP -= gameObject.transform.GetComponent<EnemyScript>().enemyAttack;
            Destroy(gameObject);
        }
    }

}
