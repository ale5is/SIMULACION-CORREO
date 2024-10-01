using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CompararCajas : MonoBehaviour
{
    public string Nombre, Direccion,Tamaño;
    public int Id;
    public bool cambiar;
    bool Puntaje;
   
    public int puntuacion;
    public int errores;
    private void Start()
    {
        Puntaje = true;
        cambiar = true;
        puntuacion = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cajas"))
        {
            if (Puntaje)
            {
                if (other.GetComponent<IdCajas>().Nombre == Nombre)
                {
                    puntuacion=puntuacion+2;

                }
                else
                {
                    puntuacion--;
                    errores++;

                }
                if (other.GetComponent<IdCajas>().Id == Id)
                {
                    puntuacion = puntuacion + 2;
                }
                else
                {
                    puntuacion--;
                    errores++;
                }
                if (other.GetComponent<IdCajas>().Direccion == Direccion)
                {
                    puntuacion = puntuacion + 2;
                }
                else
                {
                    puntuacion--;
                    errores++;
                }
                if (other.GetComponent<IdCajas>().Tamaño == Tamaño)
                {
                    puntuacion = puntuacion + 2;
                }
                else
                {
                    puntuacion--;
                    errores++;
                }
                if(puntuacion<=0)
                {
                    puntuacion = 0;
                }
                
                Invoke("activar", 3);
            }
            
            Puntaje = false;
            Destroy(other.gameObject);
            cambiar = true;

        }
    }
    void activar()
    {  
        Puntaje=true;
    }
}
