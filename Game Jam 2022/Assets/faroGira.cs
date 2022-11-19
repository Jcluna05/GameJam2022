using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faroGira : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 0, 6 * Time.deltaTime);
    }
}
