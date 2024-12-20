using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedirCajas : MonoBehaviour
{
    public GameObject Caja1,Caja2,Caja3;
    public int TamaņoCaja;
    int cantidad;
    void Start()
    {
        TamaņoCaja = 0;
        cantidad = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cantidad == 0)
        {
            if (TamaņoCaja == 1)
            {
                cantidad++;
                Instantiate(Caja1, transform.position + new Vector3(0, 0.1F, 0), transform.rotation);
            }
            if (TamaņoCaja == 2)
            {
                cantidad++;
                Instantiate(Caja2, transform.position + new Vector3(0, 0.1F, 0), transform.rotation);
            }
            if (TamaņoCaja == 3)
            {
                cantidad++;
                Instantiate(Caja3, transform.position + new Vector3(0, 0.1F, 0), transform.rotation);
            }
        }    
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cajas")
        {
            if(TamaņoCaja==0)
            {
                Destroy(other.gameObject);
                cantidad--;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Cajas")
        {
            cantidad--;
            TamaņoCaja = 0;
        }
    }
}
