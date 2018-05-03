using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Analytics;

public class SceneMoving : MonoBehaviour {

    public static SceneMoving singleton;

    void Awake(){
        //　スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
        if (singleton == null){
            DontDestroyOnLoad(gameObject);
            singleton = this;
        }
        else {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
