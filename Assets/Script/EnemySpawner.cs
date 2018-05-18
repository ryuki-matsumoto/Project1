using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemy; //敵のオブジェクト
	public float interval = 3; //何秒に一回敵を発生させるか
	float timer = 0; //タイマー
    Vector3 random_pos;
    int count_method; //メソッドを呼び出す回数
    public static float FirstRandom = 0.0f;
    public static float LastRandom = 5.0f;
    int count = 1;
    public GameObject Boss;

    void Update () {
		timer -= Time.deltaTime; //タイマーを減らす

        if (GameoverScript.GameOverFlag || MoveToPM.pm_flag || GameoverScript.ResultFlag) {
            if(count_method > 0) {
                print("destroy");
                DestroyClone();
            }
            
          
        }

        else {

            if (MissionScript.GameStartFlag) {
                if(count > 0) {
                    Instantiate(Boss, new Vector3(100.9f, 1.0f, 59.2f), transform.rotation);
                    count = 0;
                }
            }

            else {
                if (timer < 0){ //タイマーがゼロより小さくなったら
                    Spawn(); // Spawnメソッドを呼ぶ
                    timer = interval; // タイマーをリセットする
                    count_method = 1;
                }
            }
           /* if (timer < 0){ //タイマーがゼロより小さくなったら
                Spawn(); // Spawnメソッドを呼ぶ
                timer = interval; // タイマーをリセットする
                count_method = 1;
            }*/
        }
		
	}
	// 敵を生成するメソッド
	void Spawn(){
        random_pos = new Vector3(Random.Range(70.0f, 110.0f), 1.0f, Random.Range(30.0f, 70.0f));
        Instantiate (enemy[(int)(Random.Range(FirstRandom, LastRandom))], random_pos, transform.rotation);
        random_pos = new Vector3(Random.Range(70.0f, 110.0f), 1.0f, Random.Range(30.0f, 70.0f));
        Instantiate(enemy[(int)(Random.Range(FirstRandom, LastRandom))], random_pos, transform.rotation);
        random_pos = new Vector3(Random.Range(70.0f, 110.0f), 1.0f, Random.Range(30.0f, 70.0f));
        Instantiate(enemy[(int)(Random.Range(FirstRandom, LastRandom))], random_pos, transform.rotation);

    }
    
    //生成した敵を破壊するメソッド
    void DestroyClone() {
        //print("destroy");
        var clones = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var clone in clones){
            Destroy(clone);
        }
        //clones
        count_method = 0;
        count = 1;
    }

}
