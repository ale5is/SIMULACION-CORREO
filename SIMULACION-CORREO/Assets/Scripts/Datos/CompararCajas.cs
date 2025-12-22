using TMPro;
using UnityEngine;

public class CompararCajas : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text Puntuacion;
    public GameObject Subir;
    public GameObject Bajar;

    [Header("Datos correctos")]
    public string Nombre;
    public string Direccion;
    public string Tamaño;
    public int Id;

    [Header("Checks")]
    public Chequear chequear;
    public Chequear chequear2;
    public Chequear chequear3;
    public Chequear chequear4;
    public DatosEnvio datos;

    [Header("Puntaje")]
    public int puntuacion;
    private int puntuacionActual;
    public int erroresActuales;

    private bool puedePuntuar = true;
    private bool esperando;

    private void Start()
    {
        puntuacion = 0;
        puntuacionActual = 0;
        erroresActuales = 0;

        Subir.SetActive(false);
        Bajar.SetActive(false);

        ActualizarUI();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cajas"))
        {
            IdCajas caja = other.GetComponent<IdCajas>();
            if (caja == null) return;

            Evaluar(caja);
            Debug.Log("Algo entro al trigger: " + other.name);

            Destroy(other.gameObject);
            puedePuntuar = false;

            CancelInvoke(nameof(Activar));
            Invoke(nameof(Activar), 3f);

            if (!esperando)
            {
                esperando = true;
                Invoke(nameof(Cambiar), 1f);
            }
        }
        

       
    }

    void Evaluar(IdCajas caja)
    {
        puntuacionActual = 0;
        erroresActuales = 0;

        Comparar(caja.Nombre == Nombre, chequear);
        Comparar(caja.Id == Id, chequear2);
        Comparar(caja.Direccion == Direccion, chequear3);
        Comparar(caja.Tamaño == Tamaño, chequear4);

        puntuacion += puntuacionActual - erroresActuales;

        if (puntuacion < 0)
            puntuacion = 0;

        if (puntuacionActual - erroresActuales > 0)
            Subir.SetActive(true);
        else
            Bajar.SetActive(true);

        ActualizarUI();
    }

    void Comparar(bool correcto, Chequear check)
    {
        if (correcto)
        {
            puntuacionActual += 2;
            check.check = 1;
        }
        else
        {
            erroresActuales++;
            check.check = 2;
        }
    }

    void Activar()
    {
        puedePuntuar = true;
    }

    void Cambiar()
    {
        esperando = false;
        puntuacionActual = 0;
        erroresActuales = 0;

        Subir.SetActive(false);
        Bajar.SetActive(false);
    }

    void ActualizarUI()
    {
        datos.GenerarDatos();
        Puntuacion.text = "Puntuación: " + puntuacion;
    }
}
