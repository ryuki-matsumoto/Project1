using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStrengthen : MonoBehaviour {

   
    public Text PlayerMoney;
    public Text StageLebel;
    public Text GateHP;
    public Text StageNeeds;

    public static int needSMoney;
    bool scount = true;
  
    public static int sPlusLevel;
       
    bool strengthenSFlag = false;
   



    // Use this for initialization
    void Start () {
        sPlusLevel = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (scount){
            PlayerMoney.text = PlayerScript.playerMoney.ToString();
            StageLebel.text = (GateScript.stageLevel + sPlusLevel).ToString();
            GateHP.text = (GateScript.maxgateHP + (sPlusLevel * 20)).ToString();
            needSMoney = (GateScript.stageLevel + sPlusLevel) * (GateScript.stageLevel) * sPlusLevel;
            StageNeeds.text = needSMoney.ToString();

            if (needSMoney > PlayerScript.playerMoney){
                PlayerMoney.color = Color.red;
                StageLebel.color = Color.red;
                strengthenSFlag = false;
            }

            else{
                PlayerMoney.color = Color.black;
                StageLebel.color = Color.black;
                strengthenSFlag = true;
            }
            scount = false;
        }

    }

    public void StageOnClickRightArrow(){
        scount = true;
        sPlusLevel++;
    }

    public void StageOnClickLeftArrow(){
        scount = true;
        sPlusLevel--;
        if (sPlusLevel < 0){
            sPlusLevel = 0;
        }
    }

    public void Strength() {
        GateScript.stageLevel += sPlusLevel;
        GateScript.plus += (sPlusLevel * 20);
        PlayerScript.playerMoney -= needSMoney;
        sPlusLevel = 0;
        scount = true;
    }

}
