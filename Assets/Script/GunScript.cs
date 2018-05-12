using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

    public AudioClip gunSound; //銃を撃つときの音
    public GameObject explosion; //銃から出る爆発
    public GameObject sparks; //火花
    AudioSource audioSource; //音源(スピーカー)
    RaycastHit hit; //銃が当たった時の情報

    public float GunSpeed; //銃を撃つスピード
    public int GunAttack; //銃の攻撃力
    public static int Attack_rate = 0;

    void Awake(){
        GunAttack += Attack_rate;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = gunSound;
    }

    
   

	// ゲームが始まった時に1回呼ばれるメソッド
	void Start () {
        
	}

	// ゲームの1フレームごとに呼ばれるメソッド
	void Update () {
       

        
            if (Input.GetMouseButtonDown(0)){
            print("aaa");
                Shot();
                Instantiate(explosion, transform.position, Quaternion.identity);
  
             }
        
       
	}

    // 銃をうつ時に行いたいことをこの中に書く
    void Shot() {
        audioSource.Play();
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = Camera.main.ScreenPointToRay(center);
        float distance = 100f;
        if (Physics.Raycast(ray, out hit, distance)) {
            Instantiate(sparks, hit.point, Quaternion.identity);
        if (hit.collider.tag == "Enemy") {
                print("撃たれた");
                hit.collider.SendMessage("Damage");
                //hit.collider.gameObject.GetComponent<EnemyScript>().;
            }
        }
    }
}
