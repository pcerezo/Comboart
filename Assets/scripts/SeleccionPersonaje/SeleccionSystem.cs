using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SeleccionSystem : MonoBehaviour
{
    //private int personaje1, personaje2;
    private int jugadorEligiendo;
    private bool terminado_j1, terminado_j2, escogidos;
    private int numPersonajeJ1, numPersonajeJ2;
    private String nombrePersonajeJ1, nombrePersonajeJ2;
    private GameObject[] listaPersonajes;
    private int i;
    private bool pulsado;
    public GameObject botonJugar;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        pulsado = false;
        jugadorEligiendo = 0; // Primero escoge el jugador 1
        terminado_j1 = terminado_j2 = escogidos = false;
        //personaje1 = personaje2 = 0;
        listaPersonajes = new GameObject[4];
        print("Length: " + listaPersonajes.Length);
        for (int i = 0; i < listaPersonajes.Length; i++)
        {
            listaPersonajes[i] = GameObject.Find("Personaje" + i);
            listaPersonajes[i].GetComponent<BotonPersonaje>().setNumero(i);
            listaPersonajes[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Detectamos si hemos seleccionado un personaje
        if (Input.GetMouseButtonDown(0))
        {
            i = 0;
            print("Ratón pulsado");

            if (EventSystem.current.currentSelectedGameObject == botonJugar)
            {
                if (escogidos)
                {
                    // Esperamos a que todos los jugadores escojan su personaje
                    print("Los jugadores han escogido");
                    // Cargar escena de combate
                    PlayerPrefs.SetInt("Personaje_J1", numPersonajeJ1);
                    PlayerPrefs.SetInt("Personaje_J2", numPersonajeJ2);
                    SceneManager.LoadScene("EscenaCombate");
                }
            }
            else
            {
                // Se recorre la lista preguntando quién ha sido seleccionado
                while (!pulsado)
                {
                    i++;
                    i %= listaPersonajes.Length;
                    pulsado = listaPersonajes[i].GetComponent<BotonPersonaje>().getPulsado();
                }
                
                print("Pulsado: " + i);
                // Si no ha seleccionado aún el j1, se lo asignamos
                if (!terminado_j1)
                {
                    // Apuntamos el nombre del personaje seleccionado
                    nombrePersonajeJ1 = listaPersonajes[i].transform.GetChild(0).gameObject
                        .GetComponent<TextMeshProUGUI>().text;
                    GameObject.Find("SeleccionJ1").transform.GetChild(0).gameObject
                        .GetComponent<TextMeshProUGUI>().SetText(nombrePersonajeJ1);
                    
                    // Ahora lo ponemos como no pulsado para evitar fallo para el siguiente jugador
                    listaPersonajes[i].GetComponent<BotonPersonaje>().setPulsado(false);
                    
                    numPersonajeJ1 = listaPersonajes[i].GetComponent<BotonPersonaje>().getNumero();
                    terminado_j1 = true;
                    pulsado = false;
                }
                // Falta el jugador 2 por asignar
                else
                {
                    // Igualmente apuntamos número y nombre para el jugador 2
                    nombrePersonajeJ2 = listaPersonajes[i].transform.GetChild(0).gameObject
                        .GetComponent<TextMeshProUGUI>().text;
                    GameObject.Find("SeleccionJ2").transform.GetChild(0).gameObject
                        .GetComponent<TextMeshProUGUI>().SetText(nombrePersonajeJ2);
                    
                    listaPersonajes[i].GetComponent<BotonPersonaje>().setPulsado(false);
                    
                    numPersonajeJ2 = listaPersonajes[i].GetComponent<BotonPersonaje>().getNumero();
                    terminado_j2 = true;
                    pulsado = false;
                }
            }

            if (terminado_j1 && terminado_j2) escogidos = true;
        }
    }
}
