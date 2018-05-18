using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmsSelect : MonoBehaviour {


    //public int arraySize;
    public GameObject[] Arms; //全ての武器のgameobject格納

    public Sprite[] sprite; //全ての武器の画像を格納

    public GameObject selectedArm; //現在選択している武器のgameobject格納

    Image image; //現在選択している武器の画像を格納

    public GameObject SelectedImage; //シーンに表示している武器の画像のgameobjectを格納

    int i = 0; //武器のgameobjectや武器の画像の配列に使うループカウンタ

    AudioSource audioSource; //音源(スピーカー)
    public AudioClip gunSelect; //武器を変えた時の音


    // Use this for initialization
    void Start () {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = gunSelect;
        image = SelectedImage.GetComponent<Image>(); //imageにシーンに表示するImageのコンポーネントを設定
        selectedArm = Arms[0]; //最初に選択している武器を設定
        i = 0; //ループカウンタを初期値に設定
    }
	
	// Update is called once per frame
	void Update () {
        //右矢印キーを押したとき武器を切り替える
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            audioSource.Play();
            selectedArm.SetActive(false); //現在選択している武器gameobjectを非アクティブにする
            i++;
            if (i >= Arms.Length){ //配列の要素数をループカウンタが越えるとまずいのでここでもう一度最初からスタート
                i = 0;
            }
            //武器や画像を切り替えてアクティブし直す
            selectedArm = Arms[i]; 
            image.sprite = sprite[i]; 
            selectedArm.SetActive(true); 
        }
        //左矢印キーを押したとき武器を逆順に切り替える
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            audioSource.Play();
            selectedArm.SetActive(false); //現在選択している武器gameobjectを非アクティブにする
            i--;
            if (i < 0)
            { //ループカウンタが0より小さくなるとまずいのでここでは最後の要素からスタート
                i = Arms.Length - 1;
            }
            //武器や画像を切り替えてアクティブし直す
            selectedArm = Arms[i]; 
            image.sprite = sprite[i]; 
            selectedArm.SetActive(true); 
        }

    }
  
}
