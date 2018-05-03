using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    Image img;
   // public Text scoreLabel;//敵を倒した数を表示
   // public Text HPLabel; //体力表示
   // public Text GateLabel;//門の体力表示
    // Use this for initialization
    void Start () {
        
        img = GetComponent<Image>();
        img.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerScript.damageflag == true){
            print("damage");
            this.img.color = new Color(0.5f, 0.0f, 0.0f, 0.5f);
            PlayerScript.damageflag = false;
        }

        else {
            this.img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime);
        }
	}
}
