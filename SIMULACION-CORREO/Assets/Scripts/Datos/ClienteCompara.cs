using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClienteCompara : MonoBehaviour
{
    public string Nombre, Direccion, Tamaño;
    public int Id;
    public bool cambiar;
    bool Puntaje;
    int Esperar;

    public Chequear chequear, chequear2, chequear3, chequear4;

    public int puntuacion;
    public int errores;
    private void Start()
    {
        Puntaje = true;
        cambiar = true;
        puntuacion = 0;
        Esperar = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cajas"))
        {
            if (Puntaje)
            {
                if (other.GetComponent<IdCajas>().Nombre == Nombre)
                {
                    puntuacion = puntuacion + 2;
                    chequear.check = 1;

                }
                else
                {
                    puntuacion--;
                    errores++;
                    chequear.check = 2;

                }
                if (other.GetComponent<IdCajas>().Id == Id)
                {
                    puntuacion = puntuacion + 2;
                    chequear2.check = 1;
                }
                else
                {
                    puntuacion--;
                    errores++;
                    chequear2.check = 2;
                }
                if (other.GetComponent<IdCajas>().Direccion == Direccion)
                {
                    puntuacion = puntuacion + 2;
                    chequear3.check = 1;
                }
                else
                {
                    puntuacion--;
                    errores++;
                    chequear3.check = 2;
                }
                if (other.GetComponent<IdCajas>().Tamaño == Tamaño)
                {
                    puntuacion = puntuacion + 2;
                    chequear4.check = 1;
                }
                else
                {
                    puntuacion--;
                    errores++;
                    chequear4.check = 2;
                }
                if (puntuacion <= 0)
                {
                    puntuacion = 0;
                }

                Invoke("activar", 3);
            }

            Puntaje = false;
            Destroy(other.gameObject);
            if (Esperar == 0)
            {
                Esperar++;
                Invoke("Cambiar", 1);
            }

        }
    }
    void activar()
    {
        Puntaje = true;
    }

    void Cambiar()
    {
        cambiar = true;
        Esperar = 0;
    }
}
