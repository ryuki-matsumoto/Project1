using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {

    public GameObject attack_obj;
    public int interval;
    int time;
	// Use this for initialization
	void Start () {
        time = 0;
	}
	


	// Update is called once per frame
	void Update () {
        time++;
        if(interval < time) {
            Instantiate(attack_obj, gameObject.transform.position, transform.rotation);
            time = 0;
        }
        
	}
}
