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
    private String personajeJ1, personajeJ2;
    private GameObject[] listaPersonajes;

    public GameObject botonJugar;

    // Start is called before the first frame update
    void Start()
    {
        jugadorEligiendo = 0; // Primero escoge el jugador 1
        terminado_j1 = terminado_j2 = escogidos = false;
        //personaje1 = personaje2 = 0;
        listaPersonajes = new GameObject[3];

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
            print("Ratón pulsado");

            if (EventSystem.current.currentSelectedGameObject == botonJugar)
            {
                if (escogidos)
                {
                    // Esperamos a que todos los jugadores escojan su personaje
                    print("Los jugadores han escogido");
                    // Cargar escena de combate
                    PlayerPrefs.SetString("Personaje_J1", personajeJ1);
                    PlayerPrefs.SetString("Personaje_J2", personajeJ2);
                    SceneManager.LoadScene("EscenaCombate");
                }
            }
            else
            {
                // Se recorre la lista preguntando quién ha sido seleccionado
                for (int i = 0; i < listaPersonajes.Length; i++)
                {
                    if (listaPersonajes[i].GetComponent<BotonPersonaje>().getPulsado())
                    {
                        // Si no ha seleccionado aún el j1, se lo asignamos
                        if (!terminado_j1)
                        {
                            personajeJ1 = listaPersonajes[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>()
                                .text;
                            GameObject.Find("SeleccionJ1").transform.GetChild(0).gameObject
                                .GetComponent<TextMeshProUGUI>().SetText(personajeJ1);
                            terminado_j1 = true;
                        }
                        // Falta el jugador 2 por asignar
                        else
                        {
                            personajeJ2 = listaPersonajes[i].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>()
                                .text;
                            GameObject.Find("SeleccionJ2").transform.GetChild(0).gameObject
                                .GetComponent<TextMeshProUGUI>().SetText(personajeJ2);
                            terminado_j2 = true;
                        }
                    }
                }
            }

            if (terminado_j1 && terminado_j2) escogidos = true;
        }
    }
}
