using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider barra;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (barra.value <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void incrementarVida()
    {
        barra.value += 200;
    }

    public void reducirVida()
    {
        barra.value -= 3;
    }

}
