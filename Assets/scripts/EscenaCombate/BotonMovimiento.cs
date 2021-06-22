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
    private String tecla;
    private String nombreOriginal;

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
        
    }

    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(tecla)))
        {
            jugadorActual.setTerminado(true);
            jugadorActual.setUltimoMovimiento(movimiento);
            
            limpiar();
        }

        if (jugadorActual.getTerminado())
        {
            limpiar();
        }
    }

    private void OnMouseDown()
    {
        print("OnMouseDown: tecla asignada -> " + tecla);
        print("Movimiento: " + movimiento.getNombre());
        jugadorActual.setTerminado(true);
        jugadorActual.setUltimoMovimiento(movimiento);
    }

    public String asignarTecla(int i, bool turno)
    {
        print("Entro en asignar tecla");
        // Asignamos tecla para el jugador 1
        if (turno)
        {
            switch (i)
            {
                case 0:
                    tecla = "q";
                    break;
                case 1:
                    tecla = "w";
                    break;
                case 2:
                    tecla = "e";
                    break;
                case 3:
                    tecla = "a";
                    break;
                case 4:
                    tecla = "s";
                    break;
                case 5:
                    tecla = "d";
                    break;
            }
        }
        else //Asignamos otras teclas para el jugador 2
        {
            switch (i)
            {
                case 0:
                    tecla = "0";
                    break;
                case 1:
                    tecla = "1";
                    break;
                case 2:
                    tecla = "2";
                    break;
                case 3:
                    tecla = "3";
                    break;
                case 4:
                    tecla = "4";
                    break;
                case 5:
                    tecla = "5";
                    break;
            }
        }

        return tecla;
    }

    public void actualizar(int numero, bool turno, Movimiento mov, ref Jugador jugador)
    {
        movimiento = mov;
        jugadorActual = jugador;
        this.numero = numero;
        this.turno = turno;
        
        // Vamos a añadir la tecla a pulsar, así que guardamos el nombre sin modificar
        nombreOriginal = movimiento.getNombre();
        
        // Añadimos al nombre original la tecla
        movimiento.setNombre(nombreOriginal + "[" + asignarTecla(numero, turno) + "]");
    }

    /**
     * Restauramos el nombre original para que no vuelvan a repetirse las teclas
     */
    public void limpiar()
    {
        movimiento.setNombre(nombreOriginal);
    }
    
    public Movimiento getMovimiento()
    {
        return movimiento;
    }
}
