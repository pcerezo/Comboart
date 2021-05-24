using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BotonElegirObjetos : MonoBehaviour
{
    private bool mostrar;
    // Start is called before the first frame update
    void Start()
    {
        mostrar = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        mostrar = !mostrar;
        print("Boton Objetos pulsado");
    }

    public bool getMostrar()
    {
        return mostrar;
    }

    public void setMostrar(bool mostrar)
    {
        this.mostrar = mostrar;
    }
}
