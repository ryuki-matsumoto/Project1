using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall_Block : MonoBehaviour {
    private int i = 1;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(i == 1)
            transform.Translate(0.0f, -0.01f, 0.0f);
       
                
	}
    void OnTriggerEnter(Collider other){
        i = 0;
        Vector3 pos = transform.position;
        pos.y = (int)pos.y;
        if(other.tag == "Player"){
            
           // SceneManager.LoadScene("GameOver");

        }
        transform.position = pos;

    }
}
