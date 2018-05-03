using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.C)){
            SceneManager.LoadScene("main");
        }
	}

    public void OnClick(){
        SceneManager.LoadScene("main");
    }

}
