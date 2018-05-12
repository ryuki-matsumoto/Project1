using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript: MonoBehaviour {
    public static int maxplayerHP = 10;
    public static int playerHP = maxplayerHP; //Playerの体力
    public Text HPLabel; //体力表示
    public static bool damageflag;

    private Vector3 default_pos = new Vector3(72.47f, 1.0f, 29.06f);

	// ゲームの1フレームごとに呼ばれるメソッド
	void Update () {
        HPLabel.text = "PlayerHP　: " + playerHP;
        
	}

	// ダメージを与えられた時に行いたい命令を書く
	public static void PlayerDamage(int attack){
        playerHP -= attack;
        if(playerHP <= 0){
            playerHP = 0;
            GameoverScript.GameOverFlag = true;
            print("aaaa");
        }
        
	}
}

