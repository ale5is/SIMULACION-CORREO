using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeJugador : MonoBehaviour
{
    [Header("Movimiento")]
    public CharacterController controller;
    public float velocidad;
    public float fuerzaDeSalto;
    public float gravedad;

    private Vector3 movimiento = Vector3.zero;

    [Header("Juego")]
    public Temporizador activar;
    public int escena;

    [Header("UI")]
    public GameObject TextoIniciar;
    public GameObject TextoMision;

    private bool desaparecer;
    private bool quieto;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        TextoIniciar.SetActive(true);
        TextoMision.SetActive(true);

        desaparecer = false;
        quieto = false;
    }


    void Update()
    {
        Iniciar();

        if (activar.iniciar)
        {
            if (!quieto)
            {
                MoverJugador();
            }
        }
           
        else
        {
            Final();
        }
    }



    void MoverJugador()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direccion = transform.right * x + transform.forward * z;

        movimiento.x = direccion.x;
        movimiento.z = direccion.z;

        if (controller.isGrounded)
        {
            if (movimiento.y < 0)
            {
                movimiento.y = -2f;
            }

            if (Input.GetButtonDown("Jump"))
            {
                movimiento.y = fuerzaDeSalto;
            }
        }

        movimiento.y -= gravedad * Time.deltaTime;

        controller.Move(movimiento * velocidad * Time.deltaTime);
    }


    void Iniciar()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            activar.iniciar = true;
            TextoIniciar.SetActive(false);
        }

        if (!desaparecer)
        {
            desaparecer = true;
            Invoke(nameof(Desaparecer), 3f);
        }
    }


    void Final()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(escena);
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


    void Desaparecer()
    {
        TextoMision.SetActive(false);
    }
}