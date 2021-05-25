using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotonMovimiento : MonoBehaviour
{
    private Button boton;
    private TextMeshProUGUI texto;
    private Jugador jugadorActual; // El jugador asociado al turno actual
    private Movimiento movimiento; // Indica el movimiento que realizará el jugador
    private GameObject g_boton;
    private int numero;
    private bool turno;

    public BotonMovimiento(int numero, Movimiento mov, ref Jugador jugador)
    {
        movimiento = mov;
        jugadorActual = jugador;
        print("Terminado: " + jugadorActual.getTerminado());
        jugadorActual.setTerminado(true);
        print("Terminado: " + jugadorActual.getTerminado());
        this.numero = numero;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //texto.text = movimiento.getNombre();
        //print("El movimiento se llama " + texto.text);
    }

    private void OnMouseDown()
    {
        print("Movimiento: " + movimiento.getNombre());
        jugadorActual.setTerminado(true);
        jugadorActual.setUltimoMovimiento(movimiento);
    }

    public void actualizar(int numero, Movimiento mov, ref Jugador jugador)
    {
        movimiento = mov;
        jugadorActual = jugador;
        this.numero = numero;
    }

    public Movimiento getMovimiento()
    {
        return movimiento;
    }
}
