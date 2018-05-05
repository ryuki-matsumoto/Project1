using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarCtrl : MonoBehaviour {

    Slider _slider;
    void Start(){
        // スライダーを取得する
        _slider = this.GetComponent<Slider>();
        _slider.maxValue = PlayerScript.playerHP;
    }

    //float _hp = 0;
    void Update(){
        
        // HPゲージに値を設定
        _slider.value = PlayerScript.playerHP;
    }
}
