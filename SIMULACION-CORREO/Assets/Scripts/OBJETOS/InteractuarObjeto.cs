using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarObjeto : MonoBehaviour
{
    LayerMask mask;
    public float distancia = 1.5f;
    public GameObject PuntoDeMano;
    public GameObject ObjetoTomado = null;
    public Texture2D Puntero;
    public GameObject Texto;
    GameObject Detectado=null;
    bool Cargando=false;

    void Start()
    {
        mask = LayerMask.GetMask("Detectado");
        Texto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit,distancia,mask))
        {
            ObjetoDeseleccionado();
            ObjetoSeleccionado(hit.transform);
            if (hit.collider.tag == "Cajas" )
            {
               
                if (Input.GetKey("e") && ObjetoTomado == null)
                {

                    ObjetoTomado = hit.collider.gameObject;
                    ObjetoTomado.GetComponent<Rigidbody>().useGravity = false;
                    ObjetoTomado.GetComponent<Rigidbody>().isKinematic = true;

                    ObjetoTomado.transform.position = PuntoDeMano.transform.position;
                    ObjetoTomado.gameObject.transform.SetParent(PuntoDeMano.gameObject.transform);
                    Cargando = true;
                }
            }
        }
        else
        {
            ObjetoDeseleccionado() ;
        }

        if (ObjetoTomado != null)
        {
            if (Input.GetKey("f"))
            {
                ObjetoTomado.GetComponent<Rigidbody>().useGravity = true;
                ObjetoTomado.GetComponent<Rigidbody>().isKinematic = false;

                ObjetoTomado.gameObject.transform.SetParent(null);

                ObjetoTomado = null;
                Cargando=false;
            }
        }
    }
    private void ObjetoSeleccionado(Transform transform)
    {
        if (!Cargando)
        {
            transform.GetComponent<MeshRenderer>().material.color = Color.green;
            Detectado = transform.gameObject;
        }
    }

    private void ObjetoDeseleccionado()
    {
        if (Detectado) 
        {
            Detectado.GetComponent<MeshRenderer>().material.color = Color.white;
            Detectado = null;
        }
    }

    private void OnGUI()
    {
        Rect rect=new Rect(Screen.width/2,Screen.height/2,Puntero.width,Puntero.height);
        GUI.DrawTexture(rect, Puntero);

        if (Detectado&&!Cargando)
        {
            Texto.SetActive(true);
        }
        else
        {
            Texto.SetActive(false);
        }
    }
}