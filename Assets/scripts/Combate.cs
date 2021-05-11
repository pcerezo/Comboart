using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
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
    private Jugador jugadorActual, jugadorOponente;
    //public GameObject targetJ2;
    private GameObject panel;
    private BotonAtaque botonAtaque;
    private Button botonMovimiento;
    public Text texto;
    public TextMeshPro textoVictoria;
    private Movimiento ultimoMovimiento;
    
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

        if (animaciones)
        {
            j1.mostrarFlecha(false);
            j2.mostrarFlecha(false);
            panel.SetActive(false);
        }
        else panel.SetActive(true);
    }

    IEnumerator elegir()
    {
        // Empieza el jugador 1 a elegir
        turno = true;
        panel.SetActive(true);

        String turnoJugador ;
        do
        {
            do // Elección
            {
                // Personalizamos texto según a quién le toque
                if (turno)
                {
                    print("Voy a mostrar la flecha del j1");
                    // Hay que mostrar los ataques del personaje en los botones
                    Update();
                    jugadorActual = j1;
                    turnoJugador = "Jugador 1";
                }
                else
                {
                    print("Voy a mostrar la flecha del j2");

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
                turno = !turno;

                // Salimos del bucle si ya todos han escogido movimientos
                if (animaciones) break;

                yield return null;
            } while (true);

            // Fase de animaciones de los personajes
            if (animaciones)
            {
                print("Fase de animaciones");
                // Retardo de 2 segundos
                yield return new WaitForSeconds(2f);

                // Ejecutamos las animaciones
                // el jugador con mayor velocidad ejecuta primero los movimientos y animaciones
                // y después el otro
                if (j1.getVelocidad() > j2.getVelocidad())
                {
                    // TODO: adecuar las animaciones al movimiento seleccionado
                    j1.ejecutarAnimaciones();
                    // Saber qué movimiento ha utilizado
                    ultimoMovimiento = j1.getUltimoMovimiento();

                    // actuar según el tipo de movimiento usado
                    switch (ultimoMovimiento.getTipo())
                    {
                        // En los ataques, obtener el daño que se inflinje
                        // y dárselo al rival
                        case "ataque_fisico":
                            j2.recibirDanioFisico(ultimoMovimiento.getPotencia());
                            break;
                        case "ataque_magico":
                            j2.recibirDanioMagico(ultimoMovimiento.getPotencia());
                            break;
                        // potenciar características
                        case "subir_ataque_fisico":
                            j1.subirAtaqueFisico(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_ataque_magico":
                            j1.subirAtaqueMagico(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_velocidad":
                            j1.subirVelocidad(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_defensa_fisica":
                            j1.subirDefensaFisica(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_defensa_magica":
                            j1.subirDefensaMagica(ultimoMovimiento.getPotencia());
                            break;
                    }
                    
                    yield return new WaitForSeconds(2f);
                    
                    // Después sigue el siguiente
                    j2.ejecutarAnimaciones();
                    // Saber qué movimiento ha utilizado
                    ultimoMovimiento = j2.getUltimoMovimiento();

                    // actuar según el tipo de movimiento usado
                    switch (ultimoMovimiento.getTipo())
                    {
                        // En los ataques, obtener el daño que se inflinje
                        // y dárselo al rival
                        case "ataque_fisico":
                            j1.recibirDanioFisico(ultimoMovimiento.getPotencia());
                            break;
                        case "ataque_magico":
                            j1.recibirDanioMagico(ultimoMovimiento.getPotencia());
                            break;
                        // potenciar características
                        case "subir_ataque_fisico":
                            j2.subirAtaqueFisico(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_ataque_magico":
                            j2.subirAtaqueMagico(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_velocidad":
                            j2.subirVelocidad(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_defensa_fisica":
                            j2.subirDefensaFisica(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_defensa_magica":
                            j2.subirDefensaMagica(ultimoMovimiento.getPotencia());
                            break;
                    }
                }
                else 
                {
                    // j2 empieza primero
                    j2.ejecutarAnimaciones();
                    // Saber qué movimiento ha utilizado
                    ultimoMovimiento = j2.getUltimoMovimiento();

                    // actuar según el tipo de movimiento usado
                    switch (ultimoMovimiento.getTipo())
                    {
                        // En los ataques, obtener el daño que se inflinje
                        // y dárselo al rival
                        case "ataque_fisico":
                            j1.recibirDanioFisico(ultimoMovimiento.getPotencia());
                            break;
                        case "ataque_magico":
                            j1.recibirDanioMagico(ultimoMovimiento.getPotencia());
                            break;
                        // potenciar características
                        case "subir_ataque_fisico":
                            j2.subirAtaqueFisico(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_ataque_magico":
                            j2.subirAtaqueMagico(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_velocidad":
                            j2.subirVelocidad(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_defensa_fisica":
                            j2.subirDefensaFisica(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_defensa_magica":
                            j2.subirDefensaMagica(ultimoMovimiento.getPotencia());
                            break;
                    }
                    
                    yield return new WaitForSeconds(2f);
                    
                    // j1 actúa después
                    j1.ejecutarAnimaciones();
                    // Saber qué movimiento ha utilizado
                    ultimoMovimiento = j1.getUltimoMovimiento();

                    // actuar según el tipo de movimiento usado
                    switch (ultimoMovimiento.getTipo())
                    {
                        // En los ataques, obtener el daño que se inflinje
                        // y dárselo al rival
                        case "ataque_fisico":
                            j2.recibirDanioFisico(ultimoMovimiento.getPotencia());
                            break;
                        case "ataque_magico":
                            j2.recibirDanioMagico(ultimoMovimiento.getPotencia());
                            break;
                        // potenciar características
                        case "subir_ataque_fisico":
                            j1.subirAtaqueFisico(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_ataque_magico":
                            j1.subirAtaqueMagico(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_velocidad":
                            j1.subirVelocidad(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_defensa_fisica":
                            j1.subirDefensaFisica(ultimoMovimiento.getPotencia());
                            break;
                        case "subir_defensa_magica":
                            j1.subirDefensaMagica(ultimoMovimiento.getPotencia());
                            break;
                    } // switch
                } // else

                yield return new WaitForSeconds(2f);
            } // if animaciones

            animaciones = false;
            
            // Si alguien se queda sin vida determinamos quién gana
            if (j1.getVida() <= 0 || j2.getVida() <= 0)
            {
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
                
                // Si alguien pierde salimos del bucle: termina el combate
                break;
            }
        } while (true);
    }
}
