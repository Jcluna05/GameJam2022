using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public int numero;
    public void cambiarEscena(int num)
    {       
        SceneManager.LoadScene(num);
    }

    private void OnTriggerEnter(Collider other)
    {
        cambiarEscena(numero);
    }
}
