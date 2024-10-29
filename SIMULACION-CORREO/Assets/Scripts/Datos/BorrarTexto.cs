using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BorrarTexto : MonoBehaviour
{
    public TMP_InputField NombreIngresado, IdIngresado, DireccionIngresada;
    // Start is called before the first frame update
    public void Borrar()
    {
        NombreIngresado.text = "";
        IdIngresado.text = "";
        DireccionIngresada.text = "";
    }
}
