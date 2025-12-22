using UnityEngine;

public class DatosEnvio : MonoBehaviour
{
    [Header("Datos generados")]
    public string Nombre;
    public string Direccion;
    public string Tamaño;
    public int Id;

    [Header("Referencias")]
    public CompararCajas comparar;

    public Materiales Nmateriales;
    public Materiales Imateriales;
    public Materiales Dmateriales;
    public Materiales Tmateriales;

    private void Start()
    {
        GenerarDatos();
    }

    // 🔹 Llamar a este método cada vez que cambie la caja
    public void GenerarDatos()
    {
        Nombrar();
        Identificar();
        Destino();
        TipoCaja();
    }

    void Nombrar()
    {
        int r = Random.Range(0, 3);

        string[] nombres = { "Carlos", "Jorge", "Maria" };

        Nombre = nombres[r];
        Nmateriales.seleccionar = r;

        comparar.Nombre = Nombre;
    }

    void Identificar()
    {
        int r = Random.Range(0, 3);

        Id = r;
        Imateriales.seleccionar = r;

        comparar.Id = Id;
    }

    void Destino()
    {
        string[] direcciones = { "Avellaneda", "Sarandi", "Quilmes" };

        int r = Random.Range(0, 3);

        Direccion = direcciones[r];
        Dmateriales.seleccionar = r;

        comparar.Direccion = Direccion;
    }

    void TipoCaja()
    {
        string[] tamaños = { "PEQUEÑO", "MEDIANO", "GRANDE" };

        int r = Random.Range(0, 3);

        Tamaño = tamaños[r];
        Tmateriales.seleccionar = r;

        comparar.Tamaño = Tamaño;
    }
}
