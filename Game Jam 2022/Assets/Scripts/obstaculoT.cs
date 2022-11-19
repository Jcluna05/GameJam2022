using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invocarTronco : MonoBehaviour
{
    [SerializeField]
    private GameObject t;
    void Start()
    {
        InvokeRepeating("tronco",2,4);
    }

    // Update is called once per frame
    void tronco()
    {
        Instantiate(t);
    }
}
