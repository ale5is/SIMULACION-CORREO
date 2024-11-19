using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class CajaCliente : MonoBehaviour
{
    public int erroresActuales;
    public string Tama�o;
    public IdCajas caja1, caja2, caja3;
    public CompararCajas compararCajas;
    bool sostener;
    private void Start()
    {
        Tama�o = "4";
        sostener=false;
    }
    private void Update()
    {
        if (erroresActuales==0&&Tama�o!="4")
        {
            if (Tama�o == caja1.Tama�o)
            {
                caja1.gameObject.SetActive(true);
                caja2.gameObject.SetActive(false);
                caja3.gameObject.SetActive(false);
            }
            else if (Tama�o == caja2.Tama�o)
            {
                caja1.gameObject.SetActive(false);
                caja2.gameObject.SetActive(true);
                caja3.gameObject.SetActive(false);
            }
            else if (Tama�o == caja3.Tama�o)
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
            Tama�o = "4";
        }
        erroresActuales = compararCajas.erroresActuales;
    }
    void Irse()
    {
        sostener=false;
        Tama�o = "4";
    }
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.CompareTag("Cajas"))
        {
            Tama�o = other.GetComponent<IdCajas>().Tama�o;
        }
        
    }
}
