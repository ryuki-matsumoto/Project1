using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    int count_method = 1; //関数一回のみ呼び出し
    int count_method2 = 1; //関数一回のみ呼び出し
    GameObject[] Obstacles;//子オブジェクト(障害物)の取得
    int childnum ;//子オブジェクトの数
    public GameObject parent;//親オブジェクト

    // Use this for initialization
    void Start () {
        //  int Childnum = this.transform.childCount;
        Obstacles = GameObject.FindGameObjectsWithTag("WallwithHP");
        print(Obstacles.Length);
       
        //childnum = this.transform.childCount;
        for(int i = 0;i < Obstacles.Length; i++) {
            //Obstacles[i] = parent.transform.GetChild(i).gameObject;
            print(Obstacles[i].name);
        }

    }
	
	// Update is called once per frame
	void Update () {
        
        if (GameOverSceneButton.RetryFlag) {
            print("リトライ");
            PlayerScript.playerHP = PlayerScript.maxplayerHP;
            GateScript.gateHP = GateScript.maxgateHP;
            if (count_method > 0){
                print("カウント");
                ReSpawn();
            }
            GameoverScript.GameOverFlag = false;
            
        }

        else{
                count_method = 1;
            }

        

        if (MoveToPM.pm_flag){
            if (count_method2 > 0){
                ObstacleDestroy();
            }

        }

        else{
            count_method2 = 1;
        }

    }

    void ReSpawn(){
        print(Obstacles.Length);
        for (int i = 0;i < Obstacles.Length; i++) {
            Obstacles[i].GetComponent<ObstacleScript>().obstacleHP = Obstacles[i].GetComponent<ObstacleScript>().maxobstacleHP;
            Obstacles[i].SetActive(true);
        }
        print("リスポーン");
        count_method = 0;
    }

    void ObstacleDestroy() {
        
        for (int i = 0; i < Obstacles.Length; i++){
            Obstacles[i].GetComponent<ObstacleScript>().obstacleHP = Obstacles[i].GetComponent<ObstacleScript>().maxobstacleHP;
            if(Obstacles[i].activeSelf == false) {
                Destroy(Obstacles[i]);
            }
           
        }
        print("デストロイ");
        count_method2 = 0;
        MoveToPM.pm_goflag = true;
    }


}
