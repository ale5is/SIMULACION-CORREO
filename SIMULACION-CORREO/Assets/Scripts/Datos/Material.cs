using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materiales : MonoBehaviour
{
    public Material material1,material2,material3;
    public int seleccionar;
    
    void Update()
    {
        if(seleccionar == 0)
        {
            GetComponent<Renderer>().material= material1;
        }
        if (seleccionar == 1)
        {
            GetComponent<Renderer>().material = material2;
        }
        if (seleccionar == 2)
        {
            GetComponent<Renderer>().material = material3;
        }
    }
}
