using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TamañoCaja : MonoBehaviour
{
    public PedirCajas PedirCaja;
    public void CajaGrande()
    {
        PedirCaja.TamañoCaja = 3;
    }
    public void CajaMediana()
    {
        PedirCaja.TamañoCaja = 2;
    }
    public void CajaPequeña()
    {
        PedirCaja.TamañoCaja = 1;
    }

    public void BorrarCaja()
    {
        PedirCaja.TamañoCaja = 0;
    }
}
