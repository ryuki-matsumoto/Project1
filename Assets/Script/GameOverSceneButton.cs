using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneButton : MonoBehaviour {

	
    public void OnRetry() {
        GameoverScript.GameOverFlag = false;
    }

    public void OnNextPhase() {
        print("押された");
        MoveToPM.pm_flag = true;
    }


}
