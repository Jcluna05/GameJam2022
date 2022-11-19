using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Slider barra;
    public int masVida;
    public int menosVida;
    public int golpe;
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
        barra.value += masVida;
    }

    public void reducirVida()
    {
        barra.value -= menosVida;
    }

    public void golpePolicia()
    {
        barra.value -= golpe;
    }

}
