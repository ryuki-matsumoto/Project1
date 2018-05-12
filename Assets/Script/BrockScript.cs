using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrockScript : MonoBehaviour {

    public bool select_flag = false;
    private Color default_color;
    private Color select_color;

    private int count;

    protected Material mat;

 	// Use this for initialization
	void Start () {
        default_color = this.GetComponent<Renderer>().material.color;
        select_color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
        count = this.transform.childCount;
	}
	
	// Update is called once per frame
	void Update () {
        /*for (int i = 0; i < count; i++){
            this.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = default_color;
        }*/
        this.gameObject.GetComponent<Renderer>().material.color = default_color;
        if (select_flag) {
            /*for(int i = 0;i < count; i++) {
                this.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = select_color;
            }*/
            this.gameObject.GetComponent<Renderer>().material.color = select_color;
            if (Input.GetMouseButtonDown(0)) {
                this.transform.Rotate(0.0f, 15.0f, 0.0f);
            }

            select_flag = false;
        }

	}
}
