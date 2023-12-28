using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    [SerializeField]
    Transform[] wayPoints;
    int currentWayPoint = 0;
    Rigidbody rigidB;
    [SerializeField]
    float moveSpeed = 5;
    public TextMesh value;
    public static int temp_value;
    public static int coin_value;
    // public GameObject[] 
    // Use this for initialization
    void Start()
    {
        temp_value = 0;
        coin_value = 0;
        coin_value = Random.Range(5, 30);
        // value.text = "+"+" "+coin_value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if(isMove)
            Movement();
    }

    void Movement()
    {
        // if(currentWayPoint == wayPoints.Length)
        //     return;
        // if (Vector3.Distance(transform.position, wayPoints[currentWayPoint].position) < .25f)
        // {
        //     currentWayPoint += 1;
        //     // currentWayPoint = currentWayPoint % wayPoints.Length; // Loop
        // }
        // if(currentWayPoint < wayPoints.Length){
        //     Vector3 _dir = (wayPoints[currentWayPoint].position - transform.position).normalized;
        //     rigidB.MovePosition(transform.position + _dir * moveSpeed * Time.deltaTime);
        // }
        transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, wayPoints[currentWayPoint].position.x, moveSpeed * Time.deltaTime), 
                Mathf.Lerp(transform.position.y, wayPoints[currentWayPoint].position.y, moveSpeed * Time.deltaTime),
                Mathf.Lerp(transform.position.z, wayPoints[currentWayPoint].position.z, moveSpeed * Time.deltaTime)
            );
    }
}
