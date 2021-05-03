using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Combate : MonoBehaviour
{
    private bool turno = true; //true: jugador1, false: jugador2
    private bool animaciones = false; // Controlamos que ocurran las animaciones o no
    public Jugador j1;
    //public GameObject targetJ1;
    public Jugador j2;

    private Jugador jugadorActual;
    //public GameObject targetJ2;
    private GameObject panel;
    private BotonAtaque botonAtaque;
    private Button botonMovimiento;
    public Text texto;
    public TextMeshPro textoVictoria;

    // Start is called before the first frame update
    void Start()
    {
        textoVictoria.text = "";
        j1.mostrarFlecha(true);
        j2.mostrarFlecha(false);
        panel = GameObject.Find("Panel");
        panel.SetActive(true);
        botonMovimiento = GameObject.Find("Movimiento").GetComponent<Button>();
        botonAtaque = GameObject.Find("Ataque").GetComponent<BotonAtaque>();
        StartCoroutine(elegir());
    }

    // Update is called once per frame
    void Update()
    {
        j1.mostrarFlecha(turno);
        j2.mostrarFlecha(!turno);

        if (animaciones) panel.SetActive(false);
        else panel.SetActive(true);
    }

    IEnumerator elegir()
    {
        float danioj1, danioj2 = 0;
        
        // Empieza el jugador 1 a elegir
        turno = true;
        panel.SetActive(true);

        String turnoJugador ;
        do {
            
            do
            {
                // Personalizamos texto según a quién le toque
                if (turno)
                {
                    print("Voy a mostrar la flecha del j1");
                    /*j1.mostrarFlecha(true);
                    j2.mostrarFlecha(false);*/
                    Update();
                    jugadorActual = j1;
                    turnoJugador = "Jugador 1";
                }
                else
                {
                    print("Voy a mostrar la flecha del j2");
                    /*j1.mostrarFlecha(false);
                    j2.mostrarFlecha(true);*/
                    Update();
                    jugadorActual = j2;
                    turnoJugador = "Jugador 2";
                }

                botonAtaque.setJugadorActual(jugadorActual);
                jugadorActual.setTerminado(false);
                texto.text = "Turno del jugador " + turnoJugador;

                // Esperamos a que pulse un botón que pondrá terminado = true
                while (jugadorActual.getTerminado() != true)
                {
                    yield return null;
                }

                print("Ya escogió movimiento");
                // Si es el turno del último jugador
                if (!turno) animaciones = true;

                // Cambiamos el valor de turno para el siguiente jugador
                turno = botonAtaque.getTurno();

                // Salimos del bucle si ya todos han escogido movimientos
                if (animaciones) break;
                
                yield return null;
            } while (true);
        
            // Fase de animaciones de los personajes
            if (animaciones) {
                print("Fase de animaciones");
                // Retardo de 2 segundos
                yield return new WaitForSeconds(2f);

                // Ejecutamos las animaciones
                j1.ejecutarAnimaciones();
                yield return new WaitForSeconds(2f);
                j2.ejecutarAnimaciones();
                yield return new WaitForSeconds(2f);
                
                animaciones = false;
            }
            
            // Fase de daños
            // obtengo el daño que ha ejercido cada personaje
            danioj1 = j1.getDanio();
            danioj2 = j2.getDanio();
            // Obtengo la defensa que tiene cada personaje
            // TODO: hacer cálculos con las defensas de los personajes
            // Hago los cálculos de lo que se resta a cada uno
            // y muestro el resultado final
            j2.recibirDanio(danioj1 * j1.ataqueFisico);
            j1.recibirDanio(danioj2 * j2.ataqueFisico);
            
            // Compruebo si algún personaje ha perdido
            if (j1.getVida() <= 0 || j2.getVida() <= 0)
            {
                // En tal caso salimos del bucle: termina el combate
                break;
            }

        } while (true); // Se sale del bucle cuando la vida de un personaje llegue a cero
        
        // Resultado final: Indicamos quién gana
        if (j1.getVida() > 0)
        {
            textoVictoria.text = "GANADOR: JUGADOR 1";
            print("GANADOR: JUGADOR 1");
        }
        else
        {
            textoVictoria.text = "GANADOR: JUGADOR 2";
            print("GANADOR: JUGADOR 2");
        }
    }
}
