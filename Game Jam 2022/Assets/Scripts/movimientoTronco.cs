using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoTronco : MonoBehaviour
{
    public float crom = 0;
    void Update()
    {
        transform.Translate(7f * Time.deltaTime,0,0);
        crom += 1*Time.deltaTime;
        if (crom > 20)
        {
            Destroy(gameObject);
        }

        
    }
}