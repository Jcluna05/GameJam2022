using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luzNoche : MonoBehaviour
{
    // Start is called before the first frame update
    public Material noche;
    public GameObject luz;
    void Update()
    {
        if (noche.GetFloat("_Cutoff") < .7f)
        {
            luz.SetActive(true);
        }
        else
        {
            luz.SetActive(false);
        }

    }
}
