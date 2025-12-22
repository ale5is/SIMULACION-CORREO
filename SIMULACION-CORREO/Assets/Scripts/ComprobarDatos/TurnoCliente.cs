using UnityEngine;

public class TurnoCliente : MonoBehaviour
{
    public IdCajas[] cajas;
    public CajaCliente cliente;
    public bool atendido;
    public GameObject siguiente, destino, salida;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Turno"))
        {
            

            cliente.caja1 = cajas[0];
            cliente.caja2 = cajas[1];
            cliente.caja3 = cajas[2];
            cliente.cliente = gameObject;
        }
    }
    private void Update()
    {
        if (atendido)
        {
            // Mueve al objeto hacia el destino
            siguiente.transform.position = Vector3.MoveTowards(
                siguiente.transform.position,
                destino.transform.position,
                2f * Time.deltaTime

            );

            
            transform.position = Vector3.MoveTowards(
                gameObject.transform.position,
                salida.transform.position,
                3f * Time.deltaTime

            );

            Debug.Log(Vector3.Distance(siguiente.transform.position, destino.transform.position));
            if (Vector3.Distance(siguiente.transform.position, destino.transform.position) < 0.5f)
            {
     
                siguiente.transform.position = destino.transform.position;
                atendido = false;
                gameObject.SetActive(false);

                // Detenemos el movimiento

            }

            // Si está cerca del destino, se detiene

        }

    }
    void Desaparecer()
    {

        gameObject.SetActive(false);
    }

    // llamá a esto cuando termine de atenderse

}
