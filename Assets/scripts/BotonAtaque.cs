using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class BotonAtaque : MonoBehaviour
{

    public Button ataque;
    private Jugador jugadorActual; // El jugador asociado al turno actual
    private Movimiento movimiento; // Indica el movimiento que realizará el jugador
    private bool turno; // Indica el turno del jugador actual

    // Start is called before the first frame update
    void Start()
    {
        ataque = GameObject.Find("Ataque").GetComponent<Button>();
        ataque.gameObject.SetActive(false);
        turno = true;
        movimiento = new Movimiento("Ataque", 10, "Físico");
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void activar()
    {
        ataque.gameObject.SetActive(true);
    }

    public void desactivar()
    {
        ataque.gameObject.SetActive(false);
    }

    public void setTurnoActual(bool turno)
    {
        this.turno = turno;
    }

    public bool getTurno()
    {
        return turno;
    }

    public void setJugadorActual(Jugador jugador)
    {
        jugadorActual = jugador;
    }

    public Jugador getJugador()
    {
        return jugadorActual;
    }

    public void OnMouseDown()
    {
        // Indico que ya ha terminado de escoger en este turno
        jugadorActual.setTerminado(true);
        jugadorActual.setDanio(movimiento);
        turno = !turno;
        print("Botón pulsado");

        if (ataque.IsActive())
        {
            desactivar();
        }
        else
        {
            activar();
        }
    }

    public void ejecutarAnimacion()
    {
        jugadorActual.animacionAtacar();
    }

    public void setMovimiento(Movimiento mov)
    {
        movimiento = mov;
    }
}

