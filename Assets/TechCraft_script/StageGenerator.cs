using UnityEngine;
using System.Collections;

public class StageGenerator : MonoBehaviour {
    public GameObject blockPrefab;
    public int stageXNum = 10;
    public int stageZNum = 10;
    public int stageYNum = 10;

    float blockWidth;
	// Use this for initialization
	void Start () {
        
        blockWidth = blockPrefab.transform.localScale.x;
        
        for (int i = 0; i < stageXNum; ++i){
            for (int j = 0; j < stageZNum; ++j){
                for (int k = 0; k < stageYNum; ++k) {
                    Vector3 displacement = new Vector3(blockWidth * i,
                                                      -blockWidth * k + blockWidth * Mathf.Floor(Mathf.PerlinNoise(i * 0.1f, j * 0.1f) * 10.0f),
                                                       blockWidth * j);
                    Instantiate(blockPrefab, transform.position + displacement, Quaternion.identity);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}