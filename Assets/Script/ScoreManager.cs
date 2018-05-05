﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int enemyCount = 0; //敵を倒した数
	public Text scoreLabel; //UIテキスト
    public GameObject system;
    
	void Awake(){
		if (instance == null) {
			instance = this;
			//DontDestroyOnLoad (this.gameObject);
		} else {
			//Destroy (this.gameObject);
		}
	}

	void Start () {
		if (scoreLabel == null) {
			if (GameObject.Find ("EnemyCount")) {
				// EnemyCountという名前のオブジェクトを探し変数に入れる
				scoreLabel = GameObject.Find ("EnemyCount").GetComponent<Text>();
			}
		}
	}

	void Update () {
		if (scoreLabel) {
			// 倒した数をTextに表示する。
			scoreLabel.text = "倒した数:" + enemyCount.ToString ();
            if(enemyCount == 3) {
                // system.GetComponent<Pausable>().pausing = true;
                SceneManager.LoadScene("Result");
            }
		} else {
			if (GameObject.Find ("EnemyCount")) {
				scoreLabel = GameObject.Find ("EnemyCount").GetComponent<Text>();
			}
		}
	}
}