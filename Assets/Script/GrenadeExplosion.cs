using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour {
    public GameObject prefab_HitEffect2;
    public static int GrenadeAttack;
    void Start(){
        StartCoroutine("bom");      // コルーチン開始
        GrenadeAttack = 10;
    }

    IEnumerator bom(){
        yield return new WaitForSeconds(2.5f);      // 2.5秒、処理を待機.

        GameObject effect = Instantiate(prefab_HitEffect2, transform.position, Quaternion.identity) as GameObject;  // ボムエフェクト発生
        Destroy(effect, 1.0f);      // ボムエフェクトを、１秒後に消滅させる

        bomAttack();                // ボムによる攻撃処理

        Destroy(gameObject);        // 自分自身を消滅させる。
    }

    // ■■■ボムによる攻撃処理■■■
    private void bomAttack(){
        Collider[] targets = Physics.OverlapSphere(transform.position, 5.0f);   // 自分自身を中心に、半径0.7以内にいるColliderを探し、配列に格納.
        foreach (Collider obj in targets){       // targets配列を順番に処理 (その時に仮名をobjとする)
            if (obj.tag == "Enemy"){               // タグ名がEnemyなら
                obj.GetComponent<EnemyScript>().enemyHP -= GrenadeAttack;
                //Destroy(obj.gameObject);        // そのゲームオブジェクトを消滅させる。
            }
        }
    }

}
