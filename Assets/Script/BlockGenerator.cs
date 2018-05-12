using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockGenerator : MonoBehaviour {

    /* Ray ray2;
    RaycastHit hitInfo2;
    Vector3 hitObjPos2;
    */
    //public GameObject[] block;
    // float blockWidth;
    //GameObject parentobj = GameObject.Find("Obstacle").gameObject;
    //public GameObject AutoBlock;
    //int i = 0;
    //private float count = 0;
    //private float y = 10;
    /*
    void Awake(){
        //子オブジェクトの数を取得
       // ChildCount = blockGray.transform.childCount;
      /*  for (int i = 0;i < block.Length; i++){
            sprite[i] = Resources.Load<Sprite>(block[i].name);
        }

    }*/

    public static bool isCursorLocked = true;
    public Camera playerCamera;
    public float reachableDistance = 10.0f;
    GameObject blockPrefab; //現在選択している障害物
    GameObject blockGray; //現在選択している障害物(仮想)

    public GameObject[] Obstacle; //全ての障害物のgameobject
    public GameObject[] Obstacle_gray; //全ての障害物のgameobject(仮想)
    public GameObject selectedImage; //現在選択している障害物の画像
    Image image; 
    public Sprite[] sprite; //全ての障害物の画像
    int block_counter = 0; //障害物のgameobjectや障害物の画像の配列に使うループカウンタ

    public AudioClip putSound;
    public AudioClip destroySound;
    private AudioSource audioSource;
    
    
    public GameObject parentobj; //障害物の親オブジェクト(ここの子オブジェクトとして生成する)
    GameObject childobj; //parentobjの子オブジェクト

    Ray ray;
    RaycastHit hitInfo;
    Vector3 hitObjPos;
   

    // Use this for initialization
    void Start () {  
		if (isCursorLocked) {
			Cursor.visible = false;
		}

       // blockWidth = blockPrefab.transform.localScale.x;
     //   blockGrayRenderer = blockGray.GetComponent<Renderer>();

        audioSource = gameObject.GetComponent<AudioSource>();
        image = selectedImage.GetComponent<Image>();

        blockPrefab = Obstacle[0]; //選択中の障害物に最初の障害物を格納
        blockGray = Obstacle_gray[0]; //選択中の障害物に最初の障害物を格納(仮想のgameobejct)
    }

	// Update is called once per frame
	void Update () {
        
        if (isCursorLocked){
			Cursor.lockState = CursorLockMode.Locked;
		}

        ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
       
        bool isRayHit = Physics.Raycast(ray, out hitInfo, reachableDistance);
        

        Debug.DrawRay(ray.origin, ray.direction * reachableDistance, Color.red, 0.0f, false);

        // Show gray block
        //rayがgameobjectに当たったとき
        if (isRayHit){
            print("hit");
            //もしrayが当たったgameobjectがTerrain(Tagはステージ)なら
            if (hitInfo.collider.tag == "Stage") {
                blockGray.SetActive(true); //仮想のgameobjectをアクティブ化
                blockGray.gameObject.GetComponent<Renderer>().material.color = new Color(0.4f, 0.4f, 0.4f, 1.0f); //仮想とわかるよう色を黒めに
                hitObjPos = hitInfo.point;
                blockGray.transform.position = hitObjPos + hitInfo.normal * 0.001f; //rayが当たったその場に仮想のgameObjectを生成(おそらくここが原因)
            }
            //もし障害物にrayが当たれば
            else if (hitInfo.collider.tag == "WallwithHP") { 
                hitInfo.collider.gameObject.GetComponent<BrockScript>().select_flag = true; //その障害物を選択状態にする
                blockGray.SetActive(false); //仮想のgameobjectは生成しない

            }
            //それ以外のところにrayが当たれば
            else {
                blockGray.SetActive(false); //仮想のgameobjectは生成しない
            }
        }
        //rayが当たらなければ
        else{
            blockGray.SetActive(false); //仮想のgameobjectは生成しない
        }
        

        // Put blocks
        //rayがTerrain上に当たれば障害物を置くことが可能
        if (isRayHit && Input.GetMouseButtonDown(0) && hitInfo.collider.tag == "Stage"){
            hitObjPos = hitInfo.point;
            childobj = Instantiate(blockPrefab, hitObjPos, Quaternion.identity); //あらかじめ用意していた変数に生成したgameobjectを格納
            childobj.transform.parent = parentobj.transform; //生成したgameobjectを設定した親オブジェクトの子として設定
            audioSource.clip = putSound;
            audioSource.Play();
             
        }

        

		// Destoroy blocks
        //rayが障害物に当たれば
        if(isRayHit && Input.GetMouseButtonDown(1) && hitInfo.collider.tag == "WallwithHP"){
            Destroy(hitInfo.transform.gameObject);
            audioSource.clip = destroySound;
            audioSource.Play();
        }
        
        // Select blocks
       //右矢印キーを押したとき
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                blockGray.SetActive(false); //選択中のgameobject(仮想)を非アクティブ化
                block_counter++; 
                if(block_counter >= Obstacle.Length) { //カウンタが配列の要素数を超えないよう最初に戻す
                    block_counter = 0;
                }
                blockGray = Obstacle_gray[block_counter]; //選択中のgameobject(仮想)を変える
                blockPrefab = Obstacle[block_counter]; //選択中のgameobjectを変える
                image.sprite = sprite[block_counter]; //選択中のgameobjectの画像を変える
                blockGray.SetActive(true); //アクティブ化
            }

        

	}

    
}