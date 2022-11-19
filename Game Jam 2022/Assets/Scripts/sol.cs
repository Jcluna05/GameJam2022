using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sol : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentTime;
    public float dayLengthMinutes;
    public float rotationSpeed;
    public Material estrellas;
    float midday;
    float translateTime;
    // Update is called once per frame
    public void Start()
    {
        rotationSpeed = 360 / dayLengthMinutes / 60;
        midday = dayLengthMinutes * 60 / 2;
        
    }
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        transform.Rotate(new Vector3(1, 0, 0) * rotationSpeed * Time.deltaTime);

        float t = translateTime * 24f;
        float hours = Mathf.Floor(t);
        string displayHours = hours.ToString();
        if (hours == 0)
        {
            displayHours = "12";
        }
        if (hours > 12)
        {
            displayHours = (hours - 12).ToString();
        }
        if (currentTime >= midday * 2)
        {
            currentTime = 0;
        }
        if (currentTime >= midday/2 && currentTime<= midday *1.5f)
        {
            if (estrellas.GetFloat("_Cutoff") > .2f)
            {
                float alpha = estrellas.GetFloat("_Cutoff") * 100;
                alpha -= 3 * rotationSpeed * Time.deltaTime;
                alpha = alpha * .01f;
                estrellas.SetFloat("_Cutoff", alpha);

            }

        }
        else
        {
            
            if (estrellas.GetFloat("_Cutoff") < 1)
            {
                float alpha = estrellas.GetFloat("_Cutoff") * 100;
                alpha += 3 * rotationSpeed * Time.deltaTime;
                alpha = alpha * .01f;
                estrellas.SetFloat("_Cutoff", alpha);

            }
        }
        
        

    }
}
