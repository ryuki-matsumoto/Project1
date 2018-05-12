using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GateScript : MonoBehaviour {

    public static int maxgateHP = 10;
    public static int gateHP = maxgateHP;
    public static int damage_flag = 0;

    public Text gateHPLabel;


    // Use this for initialization
    void Start(){
        //gate = this.gameObject;
    }

    void Update(){
        if (MoveToPM.pm_flag) {

        }

        else {
            //gateHPLabel.text = "GateHP　: " + gateHP;
        }
        

    }

    public static void GateDamage(int attack){
        
        gateHP -= attack;

        if (gateHP <= 0){
                gateHP = 0;
                GameoverScript.GameOverFlag = true;
                print("aaaa");
        }

        if (GameoverScript.GameOverFlag) {
            gateHP = maxgateHP;
        }

    }


}
