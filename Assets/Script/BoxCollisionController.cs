using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollisionController : MonoBehaviour
{
    public static bool isLanding;
        public GameObject BoxFallParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.gameObject.name);
        this.GetComponent<Animation>().Play();
        isLanding = true;
        BoxFallParticle.SetActive(true);
        Invoke("Fade", 2f);
    }
    void Fade(){
        BoxFallParticle.SetActive(false);
    }
}
