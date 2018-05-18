using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSceneButton : MonoBehaviour {

	public static bool RetryFlag = false;

    public void OnRetry() {
        RetryFlag = true;
        GameoverScript.GameOverFlag = false;
    }

    public void GoHome() {
        GameoverScript.GoHomeFlag = true;
    }

    public void OnNextPhase() {
        print("押された");
        MoveToPM.pm_flag = true;
    }

    public void Title() {
        GameoverScript.TitleFlag = true;
        GameoverScript.ResultFlag = false;
    }

}
