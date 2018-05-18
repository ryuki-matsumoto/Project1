using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public GameObject grenade;
    public static int grenadeNum = 20;

    void ThrowGrenade(){
        Vector3 pos = transform.position + transform.TransformDirection(Vector3.forward);       // プレイヤー位置　+　プレイヤー正面にむけて１進んだ距離
        GameObject bom = Instantiate(grenade, pos, Quaternion.identity) as GameObject;       // 手榴弾を作成
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(center);
        
        float distance = 5.0f;
        Vector3 bom_speed = transform.TransformDirection(Vector3.forward) * distance;      // 手榴弾の移動速度。『プレイヤー正面に向けての速度ベクトル』を５。
        
        bom_speed += Vector3.up * distance;            // 手榴弾の『高さ方向の速度』を加算
        bom.GetComponent<Rigidbody>().velocity = bom_speed;     // 手榴弾の速度を代入

        bom.GetComponent<Rigidbody>().angularVelocity = Vector3.forward * 7;	// 手榴弾を回転速度を代入.
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetMouseButtonDown(0) && grenadeNum > 0) {
            ThrowGrenade();
        }
	}

    



}
