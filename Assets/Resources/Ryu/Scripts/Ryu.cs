using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Ryu : Personaje
{
    public Ryu()
    {
        Debug.Log("Constructor de Ryu");
        vidaMax = vida = 100;
        ataqueFisico = 15;
        defensaFisica = 1;
        ataqueMagico = 5;
        defensaMagica = 1;
        velocidad = 12;
        
        Movimiento patada = new Movimiento("Patada", 5, "ataque_fisico");
        Movimiento onda = new Movimiento("Onda", 10, "ataque_magico");
        Movimiento rapidez = new Movimiento("Rapidez", 1, "subir_velocidad");
        
        movimientos = new Movimiento[] {patada, onda, rapidez};
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
