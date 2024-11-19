using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CajaCliente : MonoBehaviour
{
    public int erroresActuales;
    public string Tamaño;
    public IdCajas caja1, caja2, caja3;
    public CompararCajas compararCajas;
    bool sostener;
    private void Start()
    {
        Tamaño = "4";
        sostener=false;
    }
    private void Update()
    {
        if (erroresActuales==0&&Tamaño!="4")
        {
            if (Tamaño == caja1.Tamaño)
            {
                caja1.gameObject.SetActive(true);
                caja2.gameObject.SetActive(false);
                caja3.gameObject.SetActive(false);
            }
            else if (Tamaño == caja2.Tamaño)
            {
                caja1.gameObject.SetActive(false);
                caja2.gameObject.SetActive(true);
                caja3.gameObject.SetActive(false);
            }
            else if (Tamaño == caja3.Tamaño)
            {
                caja1.gameObject.SetActive(false);
                caja2.gameObject.SetActive(false);
                caja3.gameObject.SetActive(true);
            }
            if (!sostener)
            {
                sostener = true;
                Invoke("Irse", 2);
            }
            
        }
        else
        {
            caja1.gameObject.SetActive(false);
            caja2.gameObject.SetActive(false);
            caja3.gameObject.SetActive(false);
            Tamaño = "4";
        }
        erroresActuales = compararCajas.erroresActuales;
    }
    void Irse()
    {
        sostener=false;
        Tamaño = "4";
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Cajas"))
        {
            Tamaño = other.GetComponent<IdCajas>().Tamaño;
        }
        
    }
}
