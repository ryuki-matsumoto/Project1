using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockGenerator : MonoBehaviour {
	public static bool isCursorLocked = true;
    public Camera playerCamera;
    public float reachableDistance = 10.0f;
    public GameObject blockPrefab;
    public GameObject blockGray;
    private static int ChildCount;
    float blockWidth;
    public AudioClip putSound;
    public AudioClip destroySound;
    private AudioSource audioSource;
    public GameObject[] block;
    public GameObject selectedImage;

    //public GameObject AutoBlock;
    int i = 0;

    Ray ray;
    RaycastHit hitInfo;
    Vector3 hitObjPos;
    Ray ray2;
    RaycastHit hitInfo2;
    Vector3 hitObjPos2;
    Image image;
    Sprite[] sprite = new Sprite[5];

    

    private float count = 0;
    private float y = 10;

    void Awake(){
        //子オブジェクトの数を取得
        ChildCount = blockGray.transform.childCount;
        for (int i = 0;i < block.Length; i++){
            sprite[i] = Resources.Load<Sprite>(block[i].name);
        }

    }

    // Use this for initialization
	void Start () {
       
               
		if (isCursorLocked) {
			Cursor.visible = false;
		}

        blockWidth = blockPrefab.transform.localScale.x;
     //   blockGrayRenderer = blockGray.GetComponent<Renderer>();

        audioSource = gameObject.GetComponent<AudioSource>();
        image = selectedImage.GetComponent<Image>();
	}

	// Update is called once per frame
	void Update () {
        
        if (isCursorLocked){
			Cursor.lockState = CursorLockMode.Locked;
		}

        ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        ray2 = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        bool isRayHit = Physics.Raycast(ray, out hitInfo, reachableDistance);
        bool isRayHit2 = Physics.Raycast(ray2, out hitInfo2, reachableDistance);

        Debug.DrawRay(ray.origin, ray.direction * reachableDistance, Color.red, 0.0f, false);

        // Show gray block
        if (isRayHit){
            print("hit");
            if (hitInfo.collider.tag == "Stage") {
                for (int i = 0; i < ChildCount; i++){
                    
                        blockGray.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = true;
                        blockGray.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = new Color(0.4f, 0.4f, 0.4f, 1.0f);
                                     
                }
                hitObjPos = hitInfo.point;
                blockGray.transform.position = hitObjPos + hitInfo.normal * 0.001f;
            }
            else if(hitInfo.collider.tag == "WallwithHP") {
                hitInfo.collider.gameObject.GetComponent<BrockScript>().select_flag = true;
                for (int i = 0; i < ChildCount; i++){
                    blockGray.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = false;
                }

            }
            else {
                for (int i = 0; i < ChildCount; i++){
                    blockGray.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = false;
                }
            }
        }

        

        else{
                for (int i = 0; i < ChildCount; i++){
                 blockGray.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = false;
                }
        }
        

        // Put blocks
        if (isRayHit && Input.GetMouseButtonDown(0) && hitInfo.collider.tag == "Stage"){
            hitObjPos = hitInfo.point;
            Instantiate(blockPrefab, hitObjPos, Quaternion.identity);
            audioSource.clip = putSound;
            audioSource.Play();
             
        }

        

		// Destoroy blocks
        if(isRayHit && Input.GetMouseButtonDown(1) && hitInfo.collider.tag == "WallwithHP"){
            Destroy(hitInfo.transform.gameObject);
            audioSource.clip = destroySound;
            audioSource.Play();
        }
        
        // Select blocks
        for (int i = 1; i <= block.Length; ++i){
            if (Input.GetKeyDown(i.ToString())) {
                blockPrefab = block[i - 1];
                image.sprite = sprite[i - 1];
            }

        }

	}

    
}