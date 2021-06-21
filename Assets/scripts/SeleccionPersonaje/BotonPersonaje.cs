using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPersonaje : MonoBehaviour
{
    private int numero;
    private bool pulsado;

    // Start is called before the first frame update
    void Start()
    {
        pulsado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        pulsado = true;
        switch (numero)
        {
            case 0:
                print("Hero Knight");
                break;
            case 1:
                print("Medieval Warrior");
                break;
            case 2:
                print("Ryu");
                break;
            case 3:
                print("Goku");
                break;
        }
    }

    public int getNumero()
    {
        return numero;
    }

    public void setNumero(int numero)
    {
        this.numero = numero;
    }

    public bool getPulsado()
    {
        return pulsado;
    }

    public void setPulsado(bool pulsado)
    {
        this.pulsado = pulsado;
    }
}
