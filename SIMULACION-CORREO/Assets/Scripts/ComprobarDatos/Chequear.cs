using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chequear : MonoBehaviour
{
    public Material Bien, Mal;
    public int check;
    MeshRenderer render;
    void Start()
    {
        render = gameObject.GetComponentInChildren<MeshRenderer>();

        render.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (check == 1)
        {
            GetComponent<Renderer>().material = Bien;
            Mostrar();
        }
        else if (check == 2) 
        {
            GetComponent<Renderer>().material = Mal;
            Mostrar();
        }
    }

    void Mostrar()
    {
        render.enabled = true;
        if (check != 0)
        {
            check = 0;
            Invoke("Ocultar",1);
        }

    }

    void Ocultar()
    {
        render.enabled = false;
    }
}
