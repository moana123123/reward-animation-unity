using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardItemsMovement : MonoBehaviour
{
    public Transform wayPoints;
    public Transform targetPositions;
    public float moveSpeed = 5;
    public TextMesh _score;
    public Text coin_text;
    // Start is called before the first frame update
    GameObject gm;
    int maxScore;
    void Start()
    {
        gm = GameObject.Find(this.gameObject.name);

        if(gm.name == "coin_")
            coin_text = gm.GetComponent<Text>();
        else
        {

            maxScore = Random.Range(3,10);
            MoveTarget.temp_value += maxScore;
            // print("MAX="+maxScore);
            // print("SUM ="+MoveTarget.temp_value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.is_collection)
        {
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, wayPoints.position.x, moveSpeed * Time.deltaTime), 
                Mathf.Lerp(transform.position.y, wayPoints.position.y, moveSpeed * Time.deltaTime),
                Mathf.Lerp(transform.position.z, wayPoints.position.z, moveSpeed * Time.deltaTime)
            );

        }
        else
        {
            if(this.gameObject.name != "coin_")
            {

                transform.position = new Vector3(
                    Mathf.Lerp(transform.position.x, targetPositions.position.x, moveSpeed * Time.deltaTime), 
                    Mathf.Lerp(transform.position.y, targetPositions.position.y, moveSpeed * Time.deltaTime),
                    Mathf.Lerp(transform.position.z, targetPositions.position.z, moveSpeed * Time.deltaTime)
                );
            }
        }
    }

    void OnTriggerEnter(Collider collider){
        // print(collider.name);
        collider.gameObject.GetComponent<ParticleManage>().OnParticle();
        if(this.gameObject.name != "coin_")
        {
        
            if(GameManager.is_collection)
            {
                gm = GameObject.Find("coin_");
                coin_text = gm.GetComponent<Text>();
                // MoveTarget.coin_value += MoveTarget.temp_value;
                coin_text.text = MoveTarget.temp_value.ToString();
                Destroy(gameObject, 0.13f);

            }
            else
            {
                 _score.text = "X"+""+maxScore.ToString();
                // print(maxScore);
            }
        }
        else
        {
            Destroy(gameObject,0.1f);
            coin_text.text = MoveTarget.coin_value.ToString();
            
        }

    }
}
