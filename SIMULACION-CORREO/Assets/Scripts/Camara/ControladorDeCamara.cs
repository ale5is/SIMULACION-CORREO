using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeCamara : MonoBehaviour
{
    public float sensibilidadDeRaton=80f;
    public Transform CuerpoDeJugador;
    float RotacionX = 0;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float ratonX = Input.GetAxis("Mouse X") * sensibilidadDeRaton * Time.deltaTime;
        float ratonY = Input.GetAxis("Mouse Y") * sensibilidadDeRaton * Time.deltaTime;

        RotacionX -= ratonY;
        RotacionX=Mathf.Clamp(RotacionX, -90f, 90);

        transform.localRotation = Quaternion.Euler(RotacionX, 0f, 0f);

        CuerpoDeJugador.Rotate(Vector3.up * ratonX);
    }
}
