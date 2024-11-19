using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detener : MonoBehaviour
{
    public ControladorDeBanda banda;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cajas"))
        {
            banda.ApagarBanda();
        }   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cajas"))
        {
            banda.ActivarBanda();
        }    
    }
}
