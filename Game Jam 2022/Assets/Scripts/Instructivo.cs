using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Instructivo : MonoBehaviour
{
    public Sprite[] imagenes = new Sprite[4];
    public GameObject regreso, siguiente;
    public Image imagen;
    private int imagenAactual = 0;
    
    void Start()
    {
        if(imagenAactual == 0)
        {
            regreso.SetActive(false);
        }
        imagen.sprite = imagenes[imagenAactual];
    }

    public void cambiarImagen()
    {
        if(imagenAactual == 3)
        {
            SceneManager.LoadScene(2);
        }else if(imagenAactual == 0)
        {
            regreso.SetActive(true);
        }
        imagen.sprite = imagenes[imagenAactual+1];
        imagenAactual++;
    } 

    public void volverImagen()
    {
        if(imagenAactual == 1)
        {
            regreso.SetActive(false);
        }
        imagen.sprite = imagenes[imagenAactual-1];
        imagenAactual--;
    }

    public void saltarInstructivo()
    {
        SceneManager.LoadScene(2);
    }
}
