using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faroGira : MonoBehaviour
{
    public Material noche;
    void Update()
    {
        if (noche.GetFloat("_Cutoff") < .7f)
        {
            transform.Rotate(0, 0, 6 * Time.deltaTime);
        }
        
    }
}
