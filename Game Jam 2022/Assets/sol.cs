using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sol : MonoBehaviour
{
    // Start is called before the first frame update
    public int sun = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(sun * Time.deltaTime, 0, 0);
    }
}
