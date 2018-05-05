using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateScript : MonoBehaviour {

    public static int gateHP = 10;
    public static int damage_flag = 0;

    public Text gateHPLabel;


    // Use this for initialization
    void Start(){
        //gate = this.gameObject;
    }

    void Update(){
        gateHPLabel.text = "GateHP　: " + gateHP;

    }

    public static void GateDamage(int attack){
        
        gateHP -= attack;

        if (gateHP <= 0){
                gateHP = 0;
                //SceneManager.LoadScene("GameOver");
                print("aaaa");
        }

    }


}
