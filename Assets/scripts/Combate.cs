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
    public Jugador j1;
    //public GameObject targetJ1;
    public Jugador j2;
    public Text texto;
    public TextMeshPro textoVictoria;
    private Movimiento ultimoMovimiento;
    private GameObject j1_obj, j2_obj;
    //public GameObject targetJ2;
    public GameObject panel;
    private GameObject[] botones_g_o;
    private BotonMovimiento[] botonesMovimiento;
    // Botón para desplegar los movimientos del personaje
    //private BotonElegirMovimientos elegirMovimientos;
    private Jugador jugadorActual;
    /*private BotonAtaque botonAtaque;
    private Button botonMovimiento;*/
    //private BotonMovimiento[] botones;
    private bool turno; //true: jugador1, false: jugador2
    private bool animaciones = false; // Controlamos que ocurran las animaciones o no

    
    // Start is called before the first frame update
    void Start()
    {
        print("Voy a empezar");
        turno = true;
        textoVictoria.gameObject.SetActive(false);
        j1 = new Jugador(0);    // HeroKnight
        j2 = new Jugador(1);    // MedievalWarrior
        jugadorActual = j1;
        print("Jugadores inicializados");
        // Máximo de 6 movimientos
        botones_g_o = new GameObject[6];
        botonesMovimiento = new BotonMovimiento[6];
        // Asignamos los botones gameobject
        int aux;
        for (int i = 0; i < botones_g_o.Length; i++)
        {
            aux = i + 1;
            botones_g_o[i] = GameObject.Find("mov"+aux);
        }
        
        print("Empieza la rutina");
        //StartCoroutine(prueba());
        StartCoroutine(elegir());
    }

    // Update is called once per frame
    void Update()
    {
        /*textoVictoria.gameObject.SetActive(false);
        j1.mostrarFlecha(turno);
        j2.mostrarFlecha(!turno);
        
        if (animaciones)
        {
            j1.mostrarFlecha(false);
            j2.mostrarFlecha(false);
            panel.SetActive(false);
        }
        else panel.SetActive(true);*/
    }

    IEnumerator elegirMovimiento()
    {
        print("Entra en elegirMovimiento()");
        String turnoJugador;
        int aux, num;
        do
        {
            // Personalizamos texto según a quién le toque
            if (turno)
            {
                print("Voy a mostrar la flecha del j1");
                Update();
                jugadorActual = j1;
                num = j1.getNumeroMovimientos();
                turnoJugador = "Jugador 1";
            }
            else
            {
                print("Voy a mostrar la flecha del j2");
                Update();
                jugadorActual = j2;
                num = j2.getNumeroMovimientos();
                turnoJugador = "Jugador 2";
            }
            jugadorActual.setTerminado(false);
            print("Turno de " + turnoJugador);
            // Mostramos los botones con sus ataques
            for (int i = 0; i < botones_g_o.Length; i++)
            {
                aux = i + 1;
                //print("Número de movimientos: " + jugadorActual.getNumeroMovimientos());
                if (i < num)
                {
                    botones_g_o[i].AddComponent<BotonMovimiento>().actualizar(i, jugadorActual.getMovimiento(i), ref jugadorActual);
                    
                    //botonesMovimiento[i] = new BotonMovimiento(i, jugadorActual.getMovimiento(i), ref jugadorActual);
                    GameObject.Find("Texto_mov" + aux).GetComponent<TextMeshProUGUI>()
                        .SetText(jugadorActual.getMovimiento(i).getNombre());
                }
                else
                {
                    // Si el personaje no tiene más movimientos ocultamos los botones
                    botones_g_o[i].SetActive(false);
                }
            }
            print("Botones creados");
            // Esperamos a que el jugador actual seleccione un movimiento
            while (jugadorActual.getTerminado() == false)
            {
                // Cuando el jugador pulse un botón terminado será true
                // y se saldrá automáticamente de este bucle
                yield return null;
            }
            print("getTerminado = true");
            //Si ya ha escogido el segundo jugador, indicamos que empezarán las animaciones
            if (!turno) animaciones = true;

            turno = !turno;

            if (animaciones) break;
        } while (true);
    }

    void ejecutarAnimaciones()
    {
        print("Fase de animaciones");
    }

    IEnumerator elegir()
    {
        // Empieza el jugador 1 a elegir
        turno = true;
        panel.SetActive(true);
        print("En elegir()");

        yield return elegirMovimiento();

        yield return null;
    }
    // Fase de animaciones
        //ejecutarAnimaciones();

            /*do
            {
                do // Elección de movimiento
                {
                    elegirMovimiento();
                    
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
                    mostrartextoVictoria();
    
                    break;
                }
            } while (true);*/
    //}

    /*public IEnumerator elegirMovimiento()
    {
        print("Entra en elegirMovimiento()");
        String turnoJugador;
        // Personalizamos texto según a quién le toque
        if (turno)
        {
            print("Voy a mostrar la flecha del j1");
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
        print("Turno de " + turnoJugador);
        // Hay que mostrar los ataques del personaje en los botones
        /*botones = new BotonMovimiento[jugadorActual.getNumeroMovimientos()];
        print("Se van a crear los botones");*/
        /*for (int i = 0; i < botones.Length; i++)
        {
            botones[i] = GameObject.Find("mov" + i).GetComponent<BotonMovimiento>();
            //botones[i].gameObject.SetActive(true);
            botones[i] = new BotonMovimiento(i, jugadorActual.getMovimiento(i), jugadorActual);
        }*/

       /* botones[0] = GameObject.Find("mov1").GetComponent<BotonMovimiento>();
        botones[0].actualizar();
        
        //botonAtaque.setJugadorActual(jugadorActual);
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
        turno = !turno;*/
       //yield return null;
    //}

    public void mostrartextoVictoria()
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
    }
}
