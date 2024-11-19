using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TemporizadorNivel2 : MonoBehaviour
{
    public float tiempo, Mtiempo, Ctiempo;
    public TextMeshProUGUI texto, puntuacion, Terrores;
    public bool iniciar;
    public GameObject TextoFinal;
    public Image imagen;
    public int record, errores;
    public ClienteCompara Drecord;
    public Slider slider;

    private void Start()
    {
        iniciar = false;
        TextoFinal.SetActive(false);
        slider.maxValue = tiempo;
        slider.value = tiempo;
        Mtiempo = tiempo / 2;
        Ctiempo = tiempo / 4;

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
                slider.value = tiempo;
                if (tiempo <= Mtiempo && tiempo > Ctiempo)
                {
                    imagen.color = Color.yellow;
                }
                if (tiempo <= Ctiempo)
                {
                    imagen.color = Color.red;
                }
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
            errores = Drecord.errores;
            puntuacion.text = "PUNTUACION: " + record;
            Terrores.text = "ERRORES: " + errores;
        }
    }
}
