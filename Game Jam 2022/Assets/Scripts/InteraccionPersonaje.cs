using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionPersonaje : MonoBehaviour
{
    Vector3 referencia , posicion;
    public BarraVida barra;
    void Start()
    {
        referencia = gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        posicion = gameObject.GetComponent<Transform>().position;
        controlarVida(posicion);
    }

    private void controlarVida(Vector3 vact)
    {
        if((int)referencia.x != (int)vact.x || (int)referencia.z != (int)vact.z)
        {
            barra.reducirVida();
            referencia = vact;
        } 
    }

    private void OnTriggerEnter(Collider coll) // Colocar etiqueta agua a los game objects que hagan que suba de vida
    {
        if (coll.CompareTag("agua"))
        {
            barra.incrementarVida();
            Destroy(coll.gameObject);
        }
    }
}
