using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmsStrengthen : MonoBehaviour {

   
    public Text PlayerMoney;
    public Text ArmsLevel;
    public Text ArmsNeeds;
    public GameObject[] AllArms;
    public Text ArmAttack;
    public Text ArmsName;
    int ArmsNum;
    public static int needAMoney;

    bool Armscount = true;

    public static int aPlusLevel;
    bool strengthenAFlag = false;

    // Use this for initialization
    void Start () {
        ArmsNum = 0;
        aPlusLevel = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (Armscount){
            ArmsLevel.text = (AllArms[ArmsNum].GetComponent<GunScript>().ArmLevel + aPlusLevel).ToString();
            ArmAttack.text = (AllArms[ArmsNum].GetComponent<GunScript>().GunAttack + (aPlusLevel * 2)).ToString();
            needAMoney = (AllArms[ArmsNum].GetComponent<GunScript>().ArmLevel * AllArms[ArmsNum].GetComponent<GunScript>().ArmLevel) * aPlusLevel ;
            ArmsNeeds.text = needAMoney.ToString();
            ArmsName.text = AllArms[ArmsNum].name;
            PlayerMoney.text = PlayerScript.playerMoney.ToString();
            //print(Arm)
            if (needAMoney > PlayerScript.playerMoney){
                PlayerMoney.color = Color.red;
                ArmsLevel.color = Color.red;
                strengthenAFlag = false;
            }

            else{
                PlayerMoney.color = Color.black;
                ArmsLevel.color = Color.black;
                strengthenAFlag = true;
            }
            Armscount = false;
        }

    }

    public void ArmsOnClickRightArrow(){
        ArmsNum++;
        Armscount = true;
        if (ArmsNum >= AllArms.Length){
            ArmsNum = 0;
        }
    }

    public void ArmsOnClickLeftArrow(){
        ArmsNum--;
        Armscount = true;
        if (ArmsNum < 0){
            ArmsNum = AllArms.Length - 1;
        }
    }

    public void ArmsLevelRightClick(){
        Armscount = true;
        aPlusLevel++;
    }

    public void ArmsLevelLeftClick(){
        Armscount = true;
        aPlusLevel--;
        print(aPlusLevel);
        if (aPlusLevel < 0){
            aPlusLevel = 0;
        }
    }

    public void Strengthen(){
        if (strengthenAFlag) {
            AllArms[ArmsNum].GetComponent<GunScript>().ArmLevel += aPlusLevel;
            AllArms[ArmsNum].GetComponent<GunScript>().GunAttack += (aPlusLevel * 2);
            PlayerScript.playerMoney -= needAMoney;
            aPlusLevel = 0;
        }
        
    }



}
