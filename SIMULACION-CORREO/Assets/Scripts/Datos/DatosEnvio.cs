using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatosEnvio : MonoBehaviour
{
    public string Nombre, Direccion,Tama�o;
    public CompararCajas comparar;
    public int Id;
    int Enombre, Eid, Edireccion,Etama�o;
    public Materiales Nmateriales,Imateriales,Dmateriales,Tmateriales;

    void Start()
    {
       
    }
    private void Update()
    {
        if (comparar.cambiar)
        {
            Nombrar();
            Identificar();
            Destino();
            TipoCaja();
            comparar.cambiar = false;
        }
    }

    public void Nombrar()
    {
        Enombre=Random.Range(0, 3);
        if (Enombre == 0)
        {
            Nombre = "Carlos";
            Nmateriales.seleccionar = 0;
        }
        if(Enombre==1)
        {
            Nombre = "Jorge";
            Nmateriales.seleccionar = 1;
        }

        if (Enombre == 2)
        {
            Nombre = "Maria";
            Nmateriales.seleccionar = 2;
        }
        comparar.Nombre = Nombre;
    }

    public void Identificar()
    {
        Eid = Random.Range(0, 3);
        if (Eid == 0)
        {
            Id = 0;
            Imateriales.seleccionar = 0;
        }
        if (Eid == 1)
        {
            Id = 1;
            Imateriales.seleccionar = 1;
        }

        if (Eid == 2)
        {
            Id = 2;
            Imateriales.seleccionar = 2;
        }
        comparar.Id = Id;
    }

    public void Destino()
    {
        Edireccion = Random.Range(0, 3);
        if (Edireccion == 0)
        {
            Direccion = "Avellaneda";
            Dmateriales.seleccionar = 0;
        }
        if (Edireccion == 1)
        {
            Direccion = "Sarandi";
            Dmateriales.seleccionar = 1;
        }

        if (Edireccion == 2)
        {
            Direccion = "Quilmes";
            Dmateriales.seleccionar = 2;
        }
        comparar.Direccion = Direccion;
    }

    public void TipoCaja()
    {
        Etama�o = Random.Range(0, 3);
        if (Etama�o == 0)
        {
            Tama�o = "PEQUE�O";
            Tmateriales.seleccionar = 0;
        }
        if (Etama�o == 1)
        {
            Tama�o = "MEDIANO";
            Tmateriales.seleccionar = 1;
        }

        if (Etama�o == 2)
        {
            Tama�o = "GRANDE";
            Tmateriales.seleccionar = 2;
        }
        comparar.Tama�o = Tama�o;
    }
}

