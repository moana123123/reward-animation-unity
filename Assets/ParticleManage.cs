using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManage : MonoBehaviour
{
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnParticle(){
        particle.SetActive(true);
    }
}
