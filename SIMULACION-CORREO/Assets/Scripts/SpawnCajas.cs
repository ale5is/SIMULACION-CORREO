using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCajas : MonoBehaviour
{
    public GameObject Caja;
    int cantidad;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cajas")
        {
            cantidad = 1;
        }
        else
        {
            cantidad = 0;
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Cajas" && cantidad == 0)
        {
            cantidad++;
            Instantiate(Caja, transform.position+new Vector3(0,0.1F,0), transform.rotation);
        }
    }
}
