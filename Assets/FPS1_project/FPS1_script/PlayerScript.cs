using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript: MonoBehaviour {
    private static int playerHP = 10; //Playerの体力
    public Text HPLabel; //体力表示
    public static bool damageflag;

	// ゲームの1フレームごとに呼ばれるメソッド
	void Update () {
        HPLabel.text = "PlayerHP" + playerHP.ToString();
        if(damageflag == true){
            PlayerDamage();
        }

	}

	// ダメージを与えられた時に行いたい命令を書く
	void PlayerDamage(){
        playerHP--;
        if(playerHP <= 0){
            //SceneManager.LoadScene("GameOver");
            print("aaaa");
        }
        
	}
}

