using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public float tiempo;
    public TextMeshProUGUI texto,puntuacion;
    public bool iniciar;
    public GameObject TextoFinal;
    public int record,errores;
    public CompararCajas Drecord;

    private void Start()
    {
        iniciar = false;
        TextoFinal.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (iniciar)
        {
            if (tiempo >= 0)
            {
                tiempo -= Time.deltaTime;
                texto.text = "" + tiempo.ToString("f0");
                
            }
            else
            {
                iniciar = false;
                TextoFinal.SetActive(true);
            }
        }
        else
        {
            record = Drecord.puntuacion;
            puntuacion.text = "PUNTUACION: "+record;
        }
        
    }
}
