using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour {

    public static bool GameOverFlag = false;
    public GameObject[] cameras = new GameObject[2];
    public GameObject GameOverScreen;
    public GameObject amScreen;
    public GameObject buttonArea;
	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");

    }
	

	// Update is called once per frame
	void Update () {
        if (GameOverFlag) {
            //SceneManager.LoadScene("GameOver");
            PlayerScript.playerHP = PlayerScript.maxplayerHP;
            GateScript.gateHP = GateScript.maxgateHP;
            amScreen.SetActive(false);
            GameOverScreen.SetActive(true);
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            ScoreManager.instance.enemyCount = 0;
            //cameras[2].SetActive(true);
        }

        else {
            buttonArea.SetActive(false);
            amScreen.SetActive(true);
            GameOverScreen.SetActive(false);
            cameras[0].SetActive(true);
            cameras[1].SetActive(true);
           // cameras[2].SetActive(false);
        }

	}

    

}
