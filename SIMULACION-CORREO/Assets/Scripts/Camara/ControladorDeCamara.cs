using UnityEngine;

public class ControladorDeCamara : MonoBehaviour
{
    [Header("Configuración")]
    public float sensibilidadDeRaton = 80f;
    public Transform CuerpoDeJugador;

    [Header("Estado del juego")]
    public Temporizador activar;

    private float rotacionX = 0f;
    private bool escribiendo = false;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (!activar.iniciar || escribiendo)
            return;

        MoverCamara();
    }


    void MoverCamara()
    {
        float ratonX = Input.GetAxis("Mouse X") * sensibilidadDeRaton * Time.deltaTime;
        float ratonY = Input.GetAxis("Mouse Y") * sensibilidadDeRaton * Time.deltaTime;

        rotacionX -= ratonY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);

        CuerpoDeJugador.Rotate(Vector3.up * ratonX);
    }


    public void Escribiendo()
    {
        escribiendo = true;
        Cursor.lockState = CursorLockMode.Confined;
    }


    public void NoEscribiendo()
    {
        escribiendo = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}