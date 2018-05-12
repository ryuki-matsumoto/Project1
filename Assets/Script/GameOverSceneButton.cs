using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneButton : MonoBehaviour {

	public static bool RetryFlag = false;

    public void OnRetry() {
        RetryFlag = true;
        GameoverScript.GameOverFlag = false;
    }

    public void OnNextPhase() {
        print("押された");
        MoveToPM.pm_flag = true;
    }


}
