using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeBanda : MonoBehaviour
{
    //velocidad de la banda
    public float velocidad;

    //propiedades de la banda
    Rigidbody rb;
    Material material;
    Vector2 offset;

    //activacion de la banda
    public bool bandaEncendida=false;

    //movimiento de la banda en cada direccion
    public float moverX, moverY,moverZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (bandaEncendida)
        {
            MovimientoBanda();
        }
    }

    private void MovimientoBanda()
    {
        Vector3 pos = rb.position;
        rb.position += new Vector3(moverX, moverY, moverZ) * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }

    public void ActivarBanda()
    {
        bandaEncendida = true;
    }

    public void ApagarBanda()
    {
        bandaEncendida = false;
    }
}
