using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthenScript : MonoBehaviour {

    public Text PlayerHP;
    public Text PlayerLevel;
    public Text PlayerMoney;
    public Text PlayerNeeds;

   
    public static int needPMoney;


    bool count = true;
 
    public static int pPlusLevel = 0;


    bool strengthenPFlag = false;
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (count){
            PlayerHP.text = (PlayerScript.maxplayerHP + (pPlusLevel * 20)).ToString();
            PlayerLevel.text = (PlayerScript.playerLevel + pPlusLevel).ToString();
            PlayerMoney.text = PlayerScript.playerMoney.ToString();
            needPMoney = (PlayerScript.playerLevel + pPlusLevel) * (PlayerScript.playerLevel + pPlusLevel) * 2;
            PlayerNeeds.text = needPMoney.ToString();

            if(needPMoney > PlayerScript.playerMoney) {
                PlayerLevel.color = Color.red;
                PlayerMoney.color = Color.red;
                strengthenPFlag = false;

            }

            else{
                PlayerLevel.color = Color.black;
                PlayerMoney.color = Color.black;
                strengthenPFlag = true;
            }

            count = false;
        }
        

    }

    public void PlayerOnClickRightArrow() {
        count = true;
        pPlusLevel++;
    }

    public void PlayerOnClickLeftArrow(){
        count = true;
        pPlusLevel--;
        if(pPlusLevel < 0) {
            pPlusLevel = 0;
        }
    }


    public void Strength(){
        PlayerScript.playerLevel += pPlusLevel;
        PlayerScript.plus += (pPlusLevel * 20);
        print(PlayerScript.maxplayerHP);
        PlayerScript.playerMoney -= needPMoney;
        pPlusLevel = 0;
        count = true;
    }




}
