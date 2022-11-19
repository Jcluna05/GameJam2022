using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculoT : MonoBehaviour
{
    [SerializeField]
    private GameObject tr;
    public float tRep;

    public void Start()
    {   
        
        InvokeRepeating("tronc",30,tRep);
    }

    // Update is called once per frame
    public void tronc()
    {
        Instantiate(tr,this.transform.position, Quaternion.identity);

    }

}
