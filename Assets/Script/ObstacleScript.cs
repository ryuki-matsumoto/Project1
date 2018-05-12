using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ObstacleScript : MonoBehaviour {

    
    
    public int obstacleHP;
    public int maxobstacleHP;
    public int destroy_flag = 0;
    

    // Use this for initialization
    void Start(){
        obstacleHP = maxobstacleHP;
    }

    void Update(){
        
        if (obstacleHP <= 0) {
            obstacleHP = 0;
            this.gameObject.SetActive(false);
        }

    }

   

}
