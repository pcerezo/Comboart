using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Goku : Personaje
{
    public Goku()
    {
        Debug.Log("Constructor de Goku");
        vidaMax = vida = 100;
        ataqueFisico = 15;
        defensaFisica = 1;
        ataqueMagico = 5;
        defensaMagica = 1;
        velocidad = 14;
        
        Movimiento patada = new Movimiento("Patada", 5, "ataque_fisico");
        Movimiento onda = new Movimiento("Kamehameha", 10, "ataque_magico");
        Movimiento fortaleza = new Movimiento("Fortaleza", 1, "subir_defensa_fisica");
        Movimiento sprint = new Movimiento("Sprint", 2, "subir_velocidad");
        
        movimientos = new Movimiento[] {patada, onda, fortaleza, sprint};
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
