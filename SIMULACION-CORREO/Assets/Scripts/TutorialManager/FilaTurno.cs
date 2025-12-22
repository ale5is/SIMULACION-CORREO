using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class FilaTurno : MonoBehaviour
{
    public Transform puntoAtencion;   // donde se atiende
    public Transform[] puntosEspera;  // posiciones de espera

    private Queue<TurnoCliente> fila = new Queue<TurnoCliente>();
    public float velocidad = 2f;

    private void Update()
    {
        int i = 0;

        foreach (TurnoCliente cliente in fila)
        {
            if (cliente == null) continue;

            Transform destino = (i == 0) ? puntoAtencion : puntosEspera[i - 1];

            cliente.transform.position = Vector3.MoveTowards(
                cliente.transform.position,
                destino.position,
                velocidad * Time.deltaTime
            );

            i++;
        }
    }

    public void AgregarCliente(TurnoCliente cliente)
    {
        if (!fila.Contains(cliente))
            fila.Enqueue(cliente);
    }

    public void ClienteAtendido()
    {
        if (fila.Count == 0) return;

        TurnoCliente atendido = fila.Dequeue();
        atendido.atendido = true;
    }
   
}
