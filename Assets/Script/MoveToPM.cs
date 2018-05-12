using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToPM : MonoBehaviour {

    public static bool pm_flag = false;
    public static bool pm_goflag = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    
	void Update () {
        //if (GameoverScript.GameOverFlag) {
            if (pm_goflag){
                GameoverScript.GameOverFlag = false;
                pm_goflag = false;
                SceneManager.LoadScene("pm");
                
            }
    //    }

        
	}
    
}
