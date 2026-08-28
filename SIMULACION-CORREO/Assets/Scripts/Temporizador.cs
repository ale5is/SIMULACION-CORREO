using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [Header("Tiempo")]
    public float tiempo;
    private float tiempoMedio;
    private float tiempoCritico;

    [Header("UI")]
    public TextMeshProUGUI texto;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI Terrores;
    public GameObject TextoFinal;
    public Image imagen;
    public Slider slider;

    [Header("Estado")]
    public bool iniciar;

    [Header("Puntuación")]
    public int record;
    public int errores;
    public CompararCajas Drecord;


    void Start()
    {
        iniciar = false;

        TextoFinal.SetActive(false);

        slider.maxValue = tiempo;
        slider.value = tiempo;

        tiempoMedio = tiempo / 2f;
        tiempoCritico = tiempo / 4f;
    }


    void Update()
    {
        if (iniciar)
        {
            ActualizarTemporizador();
        }
        else
        {
            ActualizarPuntuacion();
        }
    }


    void ActualizarTemporizador()
    {
        if (tiempo >= 0)
        {
            tiempo -= Time.deltaTime;

            ActualizarUI();
            ActualizarColor();
        }

        if (tiempo < 0)
        {
            FinalizarTemporizador();
        }
    }


    void ActualizarUI()
    {
        texto.text = tiempo.ToString("f0");
        slider.value = tiempo;
    }


    void ActualizarColor()
    {
        if (tiempo <= tiempoCritico)
        {
            imagen.color = Color.red;
        }
        else if (tiempo <= tiempoMedio)
        {
            imagen.color = Color.yellow;
        }
    }


    void FinalizarTemporizador()
    {
        iniciar = false;
        TextoFinal.SetActive(true);
    }


    void ActualizarPuntuacion()
    {
        record = Drecord.puntuacion;
        errores = Drecord.erroresActuales;

        puntuacion.text = "PUNTUACION: " + record;
        Terrores.text = "ERRORES: " + errores;
    }
}