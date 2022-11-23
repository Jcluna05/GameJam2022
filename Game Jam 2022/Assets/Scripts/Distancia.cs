using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Distancia : MonoBehaviour
{

    public GameObject checkpoint , personaje;
    public TextMeshProUGUI aviso;
    float distancia;
    float diagonalhorizontal;
    
    void Start()
    {
        aviso.text = "Distancia Restante: Calculando...";
    }

    
    void Update()
    {       
        diagonalhorizontal = Mathf.Sqrt(Mathf.Pow((checkpoint.transform.position.z - personaje.transform.position.z),2f)
            + Mathf.Pow((checkpoint.transform.position.x - personaje.transform.position.x),2));

        distancia = Mathf.Sqrt(Mathf.Pow((checkpoint.transform.position.y - personaje.transform.position.y),2)
            + Mathf.Pow(diagonalhorizontal,2));

        aviso.text = "Distancia Restante: " + distancia.ToString("F2") + " mtrs";
    }
}
