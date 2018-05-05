using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour {

    //　自身の親のCanvasGroup
    private CanvasGroup canvasGroup;
    //　前の画面に戻るボタン
    //private GameObject returnButton;

    // Use this for initialization
    void Start () {
        canvasGroup = GetComponentInParent<CanvasGroup>();
       // returnButton = transform.parent.Find("Exit").gameObject;
    }

    void OnEnable(){
        /*　装備アイテム選択中にステータス画面を抜けた時に
         *　ボタンが無効化したままの場合もあるので立ち上げ時に有効化する*/
        GetComponent<Button>().interactable = true;
    }

    public void OnSelected(){
        if (canvasGroup == null || canvasGroup.interactable){
            //　イベントシステムのフォーカスが他のゲームオブジェクトにある時このゲームオブジェクトにフォーカス
            if (EventSystem.current.currentSelectedGameObject != gameObject){
                EventSystem.current.SetSelectedGameObject(gameObject);
                gameObject.GetComponent<Image>().color = Color.white;
                
            }
        }
    }

    

    public void DisableWindow(){
        if (canvasGroup == null || canvasGroup.interactable){
            //　ウインドウを非アクティブにする
            transform.root.gameObject.SetActive(false);
        }
    }

    //　他の画面を表示する
    public void WindowOnOff(GameObject window){
        if (canvasGroup == null || canvasGroup.interactable){
            Camera.main.GetComponent<OperationStatusWindow>().ChangeWindow(window);
        }
    }

    public void OnClick()
    {
        print("aaaa");
    }

  /*  //　前の画面に戻るボタンを選択状態にする
    public void SelectReturnButton(){
        EventSystem.current.SetSelectedGameObject(returnButton);
    }
    */
    // Update is called once per frame
   
}
