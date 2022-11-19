using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivirRio : MonoBehaviour
{
    public GameObject personaje, referencia;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Entro al agua");
        personaje.transform.position = referencia.transform.position;


    }
}
