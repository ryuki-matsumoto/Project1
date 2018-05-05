using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ObstacleScript : MonoBehaviour {

    GameObject gate;

    public static int gateHP = 10;
    public int obstacleHP = 5;
    public static int damage_flag = 0;

    public Text gateHPLabel;


    // Use this for initialization
    void Start(){
        gate = this.gameObject;
    }

    void Update(){

        gateHPLabel.text = "GateHP　: " + gateHP;

        if (damage_flag >= 1){
            ObstacleDamage();
        }

    }

    void ObstacleDamage(){
        if (damage_flag == 1){
            gateHP -= EnemyScript.enemyAttack_Global;
            if(gateHP <= 0) {
                gateHP = 0;
                //SceneManager.LoadScene("GameOver");
                print("aaaa");
            }

            damage_flag = 0;
            
        }

        else if(damage_flag == 2){
            obstacleHP--;
            damage_flag = 0;
        }
    }

    
   
}
