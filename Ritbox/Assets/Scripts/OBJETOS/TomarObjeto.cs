using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarObjeto : MonoBehaviour
{
    public GameObject PuntoDeMano;
    private GameObject ObjetoTomado=null;
    void Update()
    {
        if (ObjetoTomado != null)
        {
            if (Input.GetKey("f"))
            {
                ObjetoTomado.GetComponent<Rigidbody>().useGravity = true;
                ObjetoTomado.GetComponent<Rigidbody>().isKinematic = false;
       
                ObjetoTomado.gameObject.transform.SetParent(null);

                ObjetoTomado = null;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cajas"))
        {
            if (Input.GetKey("e")&&ObjetoTomado==null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position=PuntoDeMano.transform.position;
                other.gameObject.transform.SetParent(PuntoDeMano.gameObject.transform);

                ObjetoTomado = other.gameObject;
            }
        }

    }
}
