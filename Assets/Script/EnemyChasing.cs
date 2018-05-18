using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyChasing : MonoBehaviour {

    public UnityEngine.AI.NavMeshAgent agent; //NavMeshのエージェント
    public GameObject target;
    public GameObject player; //プレイヤー
    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Gate");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        //print(target);
        agent.SetDestination(player.transform.position);
    }
}
