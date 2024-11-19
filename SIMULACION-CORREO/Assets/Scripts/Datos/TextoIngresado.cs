using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoIngresado : MonoBehaviour
{
    string NombreIngresado,IdIngresado,DireccionIngresada;
    public EditarCajas CajaEditable=null;
    public void NombreIngresando(string DNombreIngresado)
    {
        NombreIngresado = DNombreIngresado;
    }
    public void IdIngresando(string DIdIngresado)
    {
        IdIngresado = DIdIngresado;
    }
    public void DireccionIngresando(string DDireccionIngresada)
    {
        DireccionIngresada = DDireccionIngresada;
    }

    void Update()
    {
        CajaEditable.Nombre = NombreIngresado;
        if (IdIngresado == "0"|| IdIngresado == "1"||IdIngresado == "2")
        {
            CajaEditable.Id = Convert.ToInt32(IdIngresado);
        }
        CajaEditable.Direccion = DireccionIngresada;
    }
}
