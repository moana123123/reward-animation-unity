using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject box;
    public GameObject RewardInBox;
    public GameObject golden_light;
    public GameObject box_door;
    public GameObject Particles;
    public GameObject collection;
    public GameObject[] Reward_Spawn;
    public GameObject[] FlightReward_Spawn;

    public int n_reward;
    public Transform spawnPosition;
    public Transform flyrewardItemPos;
    public Text coin_text, zoom_text, tap_text, direction_text, ticket_text, life_text;
    GameObject spwan;
    GameObject fly_spwan;
    private Collider coll;
    int i = 0;
        int a = 1;

    public static bool is_collection;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        is_collection = false;
        box.GetComponent<Rigidbody>().AddForce(0,-3000,0);
    }

    // Update is called once per frame
    void Update()
    {
        // if(is_Score)
        //     AddingScore(i);

        // if(!coll || fly_spwan)
        //     return;

        if(Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);
        if (Input.GetMouseButtonDown(0))
        {
            // print("sf");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Box"))
                {
                    // print(hit.collider.gameObject.name);
                     if(a > 0){
                        if(!BoxCollisionController.isLanding || spwan != null)
                            return;
                        golden_light.SetActive(true);
                        box.GetComponent<Animation>().Stop();
                        box_door.GetComponent<Animator>().SetBool("Box_Open", true);
                        box_door.GetComponent<Animator>().speed = 0.2f;
                        BoxCollisionController.isLanding = false;
                        a=0;
                        Invoke("RewardShowDelay",2.1f);
                    }
                }
            }
        }
    }
    public void OnCollectionClick()
    {
        if(i == 1)
            BonusAppear();
        else
            is_collection = true;

    }
    void BonusAppear(){
        if(spwan != null){
           fly_spwan = Instantiate(FlightReward_Spawn[i], flyrewardItemPos.position, Quaternion.identity)as GameObject;
            Destroy(spwan);
        }
    }
    void RewardShowDelay(){

        i = Random.Range(0, 2);
        spwan = Instantiate(Reward_Spawn[i], spawnPosition.position, spawnPosition.rotation) as GameObject;
        RewardInBox.SetActive(false);
        Particles.SetActive(true);
        golden_light.SetActive(false);
        collection.SetActive(true);
        if(i == 0)
            Invoke("BonusAppear", 3f);
    }
}
