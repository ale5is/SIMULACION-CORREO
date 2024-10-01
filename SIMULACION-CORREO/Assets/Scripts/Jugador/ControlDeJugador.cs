using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlDeJugador : MonoBehaviour
{
    public CharacterController controller;
    public float velocidad = 10f;
    public float fuerzaDeSalto = 2.0F;
    public float gravedad = 9.8F;
    private Vector3 movimiento=Vector3.zero;
    public Temporizador activar;
    public GameObject TextoIniciar;
    bool quieto=false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        TextoIniciar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (activar.iniciar)
        {
            if (!quieto)
            {
                if (controller.isGrounded)
                {
                    float x = Input.GetAxis("Horizontal");
                    float z = Input.GetAxis("Vertical");

                    movimiento = transform.right * x + transform.forward * z;

                    if (Input.GetButton("Jump"))
                    {
                        movimiento.y = fuerzaDeSalto;
                    }
                }

                movimiento.y -= gravedad * Time.deltaTime;
                controller.Move(movimiento * velocidad * Time.deltaTime);
            }
        }
        

        if(Input.GetKey(KeyCode.X))
        {
            activar.iniciar=true;
            TextoIniciar.SetActive(false);
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
         
    }
    public void Quieto()
    {
        quieto = true; 
    }

    public void NoQuieto()
    {
        quieto = false;
    }
}

