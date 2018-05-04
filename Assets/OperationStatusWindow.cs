using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OperationStatusWindow : MonoBehaviour {

    [SerializeField]
    private GameObject propertyWindow;
    //　ステータスウインドウの全部の画面
    [SerializeField]
    private GameObject[] windowLists;
    private bool open_flag = false;
   
	// Update is called once per frame
	void Update () {
        //　ステータスウインドウのオン・オフ
        if (Input.GetKeyDown(KeyCode.E)){
             propertyWindow.SetActive(!propertyWindow.activeSelf);
             open_flag = true;
            //　MainWindowをセット
             ChangeWindow(windowLists[0]);
        }



    }

    //　ステータス画面のウインドウのオン・オフメソッド
    public void ChangeWindow(GameObject window){
        foreach (var item in windowLists){
            if (item == window){
                item.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                //EventSystem.current.SetSelectedGameObject(window.transform.GetChild(0).gameObject);
                window.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
            }
            else{
                item.SetActive(false);
                EventSystem.current.SetSelectedGameObject(null);
            }
            //　それぞれのウインドウのMenuAreaの最初の子要素をアクティブな状態にする
            EventSystem.current.SetSelectedGameObject(window.transform.GetChild(0).gameObject);
        }
    }

}
