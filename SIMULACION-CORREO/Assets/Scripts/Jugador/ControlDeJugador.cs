using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlDeJugador : MonoBehaviour
{
    public CharacterController controller;
    public float velocidad = 10f;
    public float fuerzaDeSalto = 2.0F;
    public float gravedad = 9.8F;
    private Vector3 movimiento=Vector3.zero;
    bool quieto=false;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
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
    public void Quieto()
    {
        quieto = true; 
    }

    public void NoQuieto()
    {
        quieto = false;
    }
}

