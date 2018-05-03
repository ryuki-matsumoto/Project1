using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockGenerator : MonoBehaviour {
	public static bool isCursorLocked = true;
    public Camera playerCamera;
    public float reachableDistance = 100.0f;
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
  //  Renderer blockGrayRenderer;
    Vector3 hitObjPos;
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
        bool isRayHit = Physics.Raycast(ray, out hitInfo, reachableDistance);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 0.0f, false);
        // Show gray block
        if (isRayHit){
            print("hit");
             for (int i = 0; i < ChildCount; i++){
                 print("call");
                 blockGray.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = true;
             }
            //blockGray.SetActive(true);
            hitObjPos = hitInfo.point;
            blockGray.transform.position = hitObjPos + hitInfo.normal * blockWidth;
        }

        else{
            // blockGrayRenderer.enabled = false;
            
            for (int i = 0; i < ChildCount; i++){
                 blockGray.transform.GetChild(i).gameObject.GetComponent<Renderer>().enabled = false;
            }
           // blockGray.SetActive(false);
        }

		// Put blocks
        if(isRayHit && Input.GetMouseButtonDown(0)){
            hitObjPos = hitInfo.point;
            Instantiate(blockPrefab, hitObjPos/* + hitInfo.normal * blockWidth*/, Quaternion.identity);
            audioSource.clip = putSound;
            audioSource.Play();
             
        }

        

		// Destoroy blocks
        if(isRayHit && Input.GetMouseButtonDown(1)){
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