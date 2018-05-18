using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour {

    public static bool GameOverFlag = false;
    public static bool ResultFlag = false;
    public static bool GoHomeFlag = false;
    public static bool TitleFlag = false;
    public GameObject[] cameras = new GameObject[2];
    public GameObject GameOverScreen;
    public GameObject amScreen;
    public GameObject ResultScreen;
    public GameObject buttonArea;
	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");

    }
	

	// Update is called once per frame
	void Update () {
        if (GameOverFlag) {
            //SceneManager.LoadScene("GameOver");
            
            amScreen.SetActive(false);
            GameOverScreen.SetActive(true);
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            ScoreManager.instance.enemyCount = 0;
            //cameras[2].SetActive(true);
        }

        else if (ResultFlag){
            //PlayerScript.playerHP = PlayerScript.maxplayerHP;
            //GateScript.gateHP = GateScript.maxgateHP;
            amScreen.SetActive(false);
            ResultScreen.SetActive(true);
            cameras[0].SetActive(false);
            cameras[1].SetActive(false);
            ScoreManager.instance.enemyCount = 0;
        }

        else {
            buttonArea.SetActive(false);
            amScreen.SetActive(true);
            GameOverScreen.SetActive(false);
            cameras[0].SetActive(true);
            cameras[1].SetActive(true);
            GameOverSceneButton.RetryFlag = false;
            // cameras[2].SetActive(false);
        }

	}

    

}
