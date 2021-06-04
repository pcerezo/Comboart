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
using Slider = UnityEngine.UI.Slider;

public class Combate : MonoBehaviour
{
    public Jugador j1, j2;
    public TextMeshPro textoRonda;
    public TextMeshPro textoVictoria;
    public TextMeshPro dialogo;
    public GameObject j1_obj, j2_obj;
    public GameObject j1_nombre, j2_nombre;
    // Botón para desplegar los movimientos del personaje y el gameobject que contiene los botones
    public GameObject botonMostrarMovimientos, botonMostrarObjetos, movimientos_obj;
    // script que controla la muestra de la lista de movimientos
    private BotonElegirMovimientos botonMostrarMovimientos_script;
    private BotonElegirObjetos botonMostrarObjetos_script;
    public Slider j1_slider, j2_slider;
    public GameObject tarjetJ1, tarjetJ2;
    public GameObject panel;
    private GameObject[] movimientos_g_o, objetos_g_o;
    private BotonMovimiento[] botonesMovimiento;
    private Jugador jugadorActual;
    private bool turno; //true: jugador1, false: jugador2
    private bool animaciones = false; // Controlamos que ocurran las animaciones o no
    bool mostrarMovimientos, mostrarObjetos; // Controlamos que se muestren los objetos o los movimientos
    private bool clickado = false;
    private String personajeJ1, personajeJ2;

    private Animator anim1, anim2;
    // Start is called before the first frame update
    void Start()
    {
        print("Voy a empezar");
        // Cargamos los Animator
        anim1 = j1_obj.GetComponent<Animator>();
        anim2 = j2_obj.GetComponent<Animator>();

        // Cargar AnimatorController según el personaje escogido antes. Ejemplo:
        anim1.runtimeAnimatorController = Resources.Load("Goku/Animations/GOKU_CONTROLLER") as RuntimeAnimatorController;
        
        
        mostrarMovimientos = mostrarObjetos = false;
        turno = true;
        textoVictoria.gameObject.SetActive(false);
        textoRonda.text = "Ronda 1";
        textoRonda.gameObject.SetActive(true);
        
        // Cargamos los sprites de ambos jugadores según lo que eligieron antes
        cargarSprites();

        jugadorActual = j1;
        print("Jugadores inicializados");

        j1_slider.maxValue = j1.getVida();
        j2_slider.maxValue = j2.getVida();

        j1_nombre.GetComponent<TextMeshPro>().text = "J1";
        j1_nombre.SetActive(true);
        j2_nombre.GetComponent<TextMeshPro>().text = "J2";
        j2_nombre.SetActive(true);
        
        // Cuando se pulse el botón 'Movimientos' se mostrarán u ocultarán
        // los movimientos de cada personaje
        // Máximo de 6 movimientos
        movimientos_g_o = new GameObject[6];
        objetos_g_o = new GameObject[6];
        botonesMovimiento = new BotonMovimiento[6];
        // Asignamos los botones gameobject
        for (int i = 1; i <= movimientos_g_o.Length; i++)
        {
            movimientos_g_o[i-1] = GameObject.Find("mov"+i);
        }
        
        for (int i = 1; i <= objetos_g_o.Length; i++)
        {
            objetos_g_o[i-1] = GameObject.Find("obj"+i);
        }
        
        botonMostrarMovimientos_script = botonMostrarMovimientos.GetComponent<BotonElegirMovimientos>();
        botonMostrarObjetos_script = botonMostrarObjetos.GetComponent<BotonElegirObjetos>();
        print("Empieza la rutina");
        StartCoroutine(elegir());
    }

    // Update is called once per frame
    void Update()
    {
        // Actualizamos la barra de vida de cada personaje
        j1_slider.value = j1.getVida();
        j2_slider.value = j2.getVida();

        if (animaciones)
        {
            tarjetJ1.SetActive(false);
            tarjetJ2.SetActive(false);
        }
        else
        {
            // Animación IDLE
            
            tarjetJ1.SetActive(turno);
            tarjetJ2.SetActive(!turno);
        }

        if (Input.GetMouseButtonDown(0))
        {
            clickado = !clickado;
            // Controlamos que la función no se repita erróneamente
            if (!clickado) {
                print("Ratón pulsado");
                if (EventSystem.current.currentSelectedGameObject == botonMostrarMovimientos)
                {
                    print("MostrarMovimientos antes = " + mostrarMovimientos);
                    if (mostrarMovimientos == false)
                    {
                        mostrarMovimientos = true;
                        mostrarObjetos = false;
                    }

                    else
                    {
                        mostrarMovimientos = !mostrarMovimientos;
                    }
                    print("MostrarMovimientos ahora = " + mostrarMovimientos);
                }
                else if (EventSystem.current.currentSelectedGameObject == botonMostrarObjetos)
                {
                    print("mostrarObjetos antes = " + mostrarObjetos);
                    if (mostrarObjetos == false)
                    {
                        mostrarMovimientos = false;
                        mostrarObjetos = true;
                    }

                    else
                    {
                        mostrarObjetos = false;
                    }
                    print("mostrarObjetos ahora = " + mostrarObjetos);
                }
            }
        }

        for (int i = 0; i < jugadorActual.getNumeroMovimientos(); i++) {
            movimientos_g_o[i].SetActive(mostrarMovimientos);
        }
        
        // TODO: getNumeroObjetos()
        for (int i = 0; i < jugadorActual.getNumeroMovimientos(); i++) {
            objetos_g_o[i].SetActive(mostrarObjetos);
        }
        
    }
    
    // Función para cargar los sprites correspondientes según el personaje elegido
    public void cargarSprites()
    {
        // Apuntamos a los sprites de los jugadores
        SpriteRenderer sp1 = j1_obj.GetComponent<SpriteRenderer>();
        SpriteRenderer sp2 = j2_obj.GetComponent<SpriteRenderer>();
        
        // Cargamos sprite para el jugador 1 según lo que haya escogido
        switch (PlayerPrefs.GetInt("Personaje_J1"))
        {
            case 0:
                print("He escogido Hero Knight");
                sp1.sprite = Resources.Load<Sprite>("HeroKnight/Sprites/HeroKnight_IDLE");
                j1 = new Jugador(0);    // HeroKnight
                break;
            case 1:
                print("He escogido Medieval Warrior");
                sp1.sprite = Resources.Load<Sprite>("MedievalWarrior/Sprites/Idle");
                j1 = new Jugador(1);    // MedievalWarrior
                break;
            case 3:
                print("He escogido a Goku");
                sp1.sprite = Resources.Load<Sprite>("Goku/Sprites/Goku_idle");
                j1 = new Jugador(3);    // MedievalWarrior
                break;
        }
        
        // Cargamos sprite para el jugador 1 según lo que haya escogido
        switch (PlayerPrefs.GetInt("Personaje_J2"))
        {
            case 0:
                print("He escogido Hero Knight");
                sp2.sprite = Resources.Load<Sprite>("HeroKnight/Sprites/HeroKnight_IDLE");
                j2 = new Jugador(0);    // HeroKnight
                break;
            case 1:
                print("He escogido Medieval Warrior");
                sp2.sprite = Resources.Load<Sprite>("MedievalWarrior/Sprites/Idle");
                j2 = new Jugador(1);    // MedievalWarrior
                break;
            case 3:
                print("He escogido a Goku");
                sp2.sprite = Resources.Load<Sprite>("Goku/Sprites/Goku_idle");
                j1 = new Jugador(3);
                break;
        }
    }

    IEnumerator elegirMovimiento()
    {
        print("Entra en elegirMovimiento()");
        GameObject.Find("Panel").SetActive(true);
        
        String turnoJugador;
        int aux, num;
        do
        {
            // Personalizamos texto según a quién le toque
            if (turno)
            {
                print("Voy a mostrar la flecha del j1");
                jugadorActual = j1;
                num = j1.getNumeroMovimientos();
                turnoJugador = "Jugador 1";
            }
            else
            {
                print("Voy a mostrar la flecha del j2");
                jugadorActual = j2;
                num = j2.getNumeroMovimientos();
                turnoJugador = "Jugador 2";
            }

            jugadorActual.setTerminado(false);
            print("Turno de " + turnoJugador);
            dialogo.SetText(turnoJugador + ": selecciona una acción");
            dialogo.gameObject.SetActive(true);
            // Mostramos los botones con sus ataques
            for (int i = 0; i < movimientos_g_o.Length; i++)
            {
                aux = i + 1;
                //print("Número de movimientos: " + jugadorActual.getNumeroMovimientos());
                if (i < num)
                {
                    movimientos_g_o[i].AddComponent<BotonMovimiento>().actualizar(i, jugadorActual.getMovimiento(i), ref jugadorActual);
                    movimientos_g_o[i].SetActive(true);
                    //botonesMovimiento[i] = new BotonMovimiento(i, jugadorActual.getMovimiento(i), ref jugadorActual);
                    GameObject.Find("Texto_mov" + aux).GetComponent<TextMeshProUGUI>()
                        .SetText(jugadorActual.getMovimiento(i).getNombre());
                }
                else
                {
                    // Si el personaje no tiene más movimientos ocultamos los botones
                    movimientos_g_o[i].SetActive(false);
                }
            }
            print("Botones creados");
            // Esperamos a que el jugador actual seleccione un movimiento
            while (jugadorActual.getTerminado() == false)
            {
                Update();
                // Cuando el jugador pulse un botón terminado será true
                // y se saldrá automáticamente de este bucle
                yield return null;
            }
            print("getTerminado = true");
            // Ahora deshabilitamos los botones para que no sean pulsados otra vez
            for (int i = 0; i < movimientos_g_o.Length; i++)
            {
                foreach (var comp in movimientos_g_o[i].GetComponents<BotonMovimiento>())
                {
                    DestroyImmediate(comp);
                }
            }
            //Si ya ha escogido el segundo jugador, indicamos que empezarán las animaciones
            if (!turno) animaciones = true;

            turno = !turno;
        } while (!animaciones);
    }

    /**
     * orden == 0: j1 atacante y j2 receptor
     * en otro caso: j2 atacante y j1 receptor
     */
    public bool gestionarMovimiento(int orden, Movimiento movimiento)
    {
        Jugador atacante, defensor;
        if (orden == 0)
        {
            atacante = j1;
            defensor = j2;
        }
        else
        {
            atacante = j2;
            defensor = j1;
        }
        
        switch (movimiento.getTipo())
        {
            // Subo características
            case "subir_ataque_fisico":
                atacante.subirAtaqueFisico(movimiento.getPotencia());
                break;
            case "subir_defensa_fisica":
                atacante.subirDefensaFisica(movimiento.getPotencia());
                break;
            case "subir_velocidad":
                atacante.subirVelocidad(movimiento.getPotencia());
                break;
            // Ataco al adversario
            case "ataque_fisico":
                atacante.setDanioFisico(movimiento.getPotencia());
                defensor.recibirDanioFisico(atacante.getDanioFisico());
                print("Vida del que recibe: " + defensor.getVida());
                break;
            case "ataque_magico":
                atacante.setDanioMagico(movimiento.getPotencia());
                defensor.recibirDanioMagico(atacante.getDanioMagico());
                break;
        }
        
        // Si el jugador atacado se queda sin vida, termina la ronda
        return defensor.getVida() <= 0;
    }
    
    
    IEnumerator ejecutarAnimaciones()
    {
        bool final = false;
        tarjetJ1.SetActive(false);
        tarjetJ2.SetActive(false);
        
        Movimiento ultimoMovimiento;
        print("Fase de animaciones");
        // Hacemos que el panel y los botones no sean visibles
        GameObject.Find("Panel").SetActive(false);
        // Comparamos las velocidades para determinar quién ejecuta primero la animación
        if (j1.getVelocidad() > j2.getVelocidad()) //Primero j1 y después j2
        {
            // Primero ataca el j1
            j1_obj.GetComponent<Animator>().SetBool("atacando", true);
            // Se actualizan vidas y características:
            ultimoMovimiento = j1.getUltimoMovimiento();
            final = gestionarMovimiento(0, ultimoMovimiento);
            // Animación durante 2 segundos
            yield return new WaitForSeconds(2);
            j1_obj.GetComponent<Animator>().SetBool("atacando", false);
            
            // Si algún jugador se ha quedado sin vida, salimos
            if (!final)
            {
                // Después ataca el j2
                j2_obj.GetComponent<Animator>().SetBool("atacando", true);
                // Se actualizan vidas y características
                ultimoMovimiento = j2.getUltimoMovimiento();
                gestionarMovimiento(1, ultimoMovimiento);
                yield return new WaitForSeconds(2);
                j2_obj.GetComponent<Animator>().SetBool("atacando", false);
            }
        }
        else // Primero j2, después j1
        {
            // Primero ataca el j2
            j2_obj.GetComponent<Animator>().SetBool("atacando", true);
            // Se actualizan vidas y características
            ultimoMovimiento = j2.getUltimoMovimiento();
            final = gestionarMovimiento(1, ultimoMovimiento);
            yield return new WaitForSeconds(2);
            j2_obj.GetComponent<Animator>().SetBool("atacando", false);

            if (!final)
            {
                // Después ataca el j1
                j1_obj.GetComponent<Animator>().SetBool("atacando", true);
                // Se actualizan vidas y características:
                ultimoMovimiento = j1.getUltimoMovimiento();
                gestionarMovimiento(0, ultimoMovimiento);
                // Animación durante 2 segundos
                yield return new WaitForSeconds(2);
                j1_obj.GetComponent<Animator>().SetBool("atacando", false);
            }
        }

        animaciones = false;
        yield return null;
    }

    IEnumerator elegir()
    {
        // Mientras que ningún jugador se quede sin vida
        while (j1.getVida() > 0 && j2.getVida() > 0)
        {
            // Empieza el jugador 1 a elegir
            turno = true;
            panel.SetActive(true);
            print("En elegir()");

            // Cada jugador escoje su movimiento
            yield return elegirMovimiento();
            // Fase de animaciones y actualizar vidas y características
            yield return ejecutarAnimaciones();
        }
        
        // Si salimos del bucle entonces un jugador se ha quedado sin vida
        // Mostramos el mensaje final indicando quién ha ganado
        mostrartextoVictoria();
    }
    
    public void mostrartextoVictoria()
    {
        if (j1.getVida() > 0)
        {
            textoVictoria.SetText("GANADOR: JUGADOR 1");
            print("GANADOR: JUGADOR 1");
        }
        else
        {
            textoVictoria.SetText("GANADOR: JUGADOR 2");
            print("GANADOR: JUGADOR 2");
        }
        textoVictoria.gameObject.SetActive(true);
    }
}
