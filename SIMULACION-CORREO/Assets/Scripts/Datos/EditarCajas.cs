using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditarCajas : MonoBehaviour
{
    public string Nombre,Direccion;
    public int Id;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cajas"))
        {
            other.GetComponent<IdCajas>().Nombre=Nombre;
            other.GetComponent<IdCajas>().Id = Id;
            other.GetComponent<IdCajas>().Direccion = Direccion;
        }
    }
}
