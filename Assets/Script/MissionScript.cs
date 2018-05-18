using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MissionScript : MonoBehaviour {

    public Text MissionTitle; //ミッションの名前
    public Text MissionTip; //ミッションの概要
    public Text MissionInfo; //ミッションの情報
    public static int MissionNum = 1; //ミッション番号
    public static bool MissionStartFlag = false; //戦いを始めるか否か
    public static bool GameStartFlag;
    //public static int MissionQ = 5;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //ミッション番号によって内容を変えていく
        switch (MissionNum) {
            case 1:
                MissionTitle.text = "練習1";
                MissionTip.text = "敵を7体倒せ！";
                MissionInfo.text = "練習するんやで。";
                if (MissionStartFlag){
                    ScoreManager.TargetCount = 7;
                    GameoverScript.GameOverFlag = false;
                    MoveToPM.pm_flag = false;
                    GameoverScript.ResultFlag = false;
                    ObstacleManager.GameStartFlag = true;
                    MissionStartFlag = false;
                    
                    SceneManager.LoadScene("am");
                }
                
                break;
            case 2:
                MissionTitle.text = "練習2";
                MissionTip.text = "敵を15体倒せ！";
                MissionInfo.text = "練習、するんやで。";
                if (MissionStartFlag){
                    ScoreManager.TargetCount = 15;
                    GameoverScript.GameOverFlag = false;
                    MoveToPM.pm_flag = false;
                    GameoverScript.ResultFlag = false;
                    ObstacleManager.GameStartFlag = true;
                    MissionStartFlag = false;
                    
                    SceneManager.LoadScene("am");
                }
                
                break;
            case 3:
                MissionTitle.text = "Chicken!";
                MissionTip.text = "敵を15体倒せ！";
                MissionInfo.text = "クッソワロタwwww。鶏が無茶苦茶やっとるわww。何とかして止めてくれww。";
                if (MissionStartFlag){
                    ScoreManager.TargetCount = 15;
                    GameoverScript.GameOverFlag = false;
                    MoveToPM.pm_flag = false;
                    GameoverScript.ResultFlag = false;
                    EnemySpawner.FirstRandom = 1.0f;
                    EnemySpawner.LastRandom = 2.0f;
                    ObstacleManager.GameStartFlag = true;
                    MissionStartFlag = false;
                   
                    SceneManager.LoadScene("am");
                }
               
                break;
            case 4:
                MissionTitle.text = "牛の野望";
                MissionTip.text = "敵を15体倒せ！";
                MissionInfo.text = "どうやら牛が何かを企んでいるようだ。これを阻止しないと牛による逆襲が始まってしまう。何とかしてくれ。";
                if (MissionStartFlag){
                    ScoreManager.TargetCount = 15;
                    GameoverScript.GameOverFlag = false;
                    MoveToPM.pm_flag = false;
                    GameoverScript.ResultFlag = false;
                    EnemySpawner.FirstRandom = 2.0f;
                    EnemySpawner.LastRandom = 3.0f;
                    ObstacleManager.GameStartFlag = true;
                    MissionStartFlag = false;
                   
                    SceneManager.LoadScene("am");
                }
                break;
            /*case 5:
                MissionTitle.text = "王の余裕";
                MissionTip.text = "敵を1体倒せ！";
                MissionInfo.text = "何だ、アイツは！？ただの牛にしてはやけに雰囲気が違うぞ！気を付けてくれ！";
                if (MissionStartFlag){
                    ScoreManager.TargetCount = 1;
                    GameoverScript.GameOverFlag = false;
                    MoveToPM.pm_flag = false;
                    GameoverScript.ResultFlag = false;
                    ObstacleManager.GameStartFlag = true;
                    MissionStartFlag = false;
                    GameStartFlag = true;
                    SceneManager.LoadScene("am");
                }
                break;*/
            default: break;
        }
	}

}
