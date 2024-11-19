using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompararCajas : MonoBehaviour
{
    public TMP_Text Puntuacion;
    public string Nombre, Direccion,Tamaño;
    public int Id;
    public bool cambiar;
    bool Puntaje;
    public int Esperar;
    public GameObject Subir, Bajar;

    public Chequear chequear,chequear2,chequear3,chequear4;
   
    public int puntuacion, puntuacionActual;
    public int errores,erroresActuales, suma;
    private void Start()
    {
        Puntaje = true;
        cambiar = true;
        puntuacion = 0;
        Esperar = 0;
        erroresActuales = 0;
        Subir.SetActive(false);
        Bajar.SetActive(false);
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
                    puntuacionActual=puntuacionActual+2;
                    chequear.check = 1;

                }
                else
                {
                    puntuacion--;
                    errores++;
                    chequear.check = 2;
                    erroresActuales++;

                }
                if (other.GetComponent<IdCajas>().Id == Id)
                {
                    puntuacion = puntuacion + 2;
                    puntuacionActual = puntuacionActual + 2;
                    chequear2.check = 1;
                }
                else
                {
                    puntuacion--;
                    errores++;
                    chequear2.check = 2;
                    erroresActuales++;
                }
                if (other.GetComponent<IdCajas>().Direccion == Direccion)
                {
                    puntuacion = puntuacion + 2;
                    puntuacionActual = puntuacionActual + 2;
                    chequear3.check = 1;
                }
                else
                {
                    puntuacion--;
                    errores++;
                    chequear3.check = 2;
                    erroresActuales++;
                }
                if (other.GetComponent<IdCajas>().Tamaño == Tamaño)
                {
                    puntuacion = puntuacion + 2;
                    puntuacionActual = puntuacionActual + 2;
                    chequear4.check = 1;
                }
                else
                {
                    puntuacion--;
                    errores++;
                    chequear4.check = 2;
                    erroresActuales++;
                }
                if(puntuacion<=0)
                {
                    puntuacion = 0;
                }
                
                Invoke("activar", 3);
                suma = puntuacionActual - erroresActuales;
                Puntuacion.text= "Puntuacion:  "+puntuacion.ToString();
                if (suma > 0)
                {
                    Subir.SetActive(true);
                }
                else
                {
                    Bajar.SetActive(true);
                }
            }
            
            Puntaje = false;
            Destroy(other.gameObject);
            if (Esperar==0)
            {
                Esperar++;
                Invoke("Cambiar", 1);
                
            }
        }
    }
    void activar()
    {  
        Puntaje=true;
        
    }

    void Cambiar()
    {
        cambiar = true;
        Esperar = 0;
        erroresActuales = 0;
        puntuacionActual = 0;
        suma = 0;
        Subir.SetActive(false);
        Bajar.SetActive(false);
    }
}
