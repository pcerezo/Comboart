using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonElegirMovimientos : MonoBehaviour
{
    private bool mostrar;
    private GameObject botonesMovimiento;
    // Start is called before the first frame update
    void Start()
    {
        botonesMovimiento = GameObject.Find("BotonesMovimiento");
        mostrar = false;
    }

    // Update is called once per frame
    void Update()
    {
        botonesMovimiento.SetActive(mostrar);
    }

    public void OnMouseDown()
    {
        mostrar = !mostrar;
        print("Mostrar: " + mostrar);
    }
}
