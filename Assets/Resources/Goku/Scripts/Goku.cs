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
        defensaFisica = 15;
        ataqueMagico = 5;
        defensaMagica = 5;
        velocidad = 12;
        
        Movimiento patada = new Movimiento("Patada", 5, "ataque_fisico");
        Movimiento onda = new Movimiento("Kamehameha", 10, "ataque_magico");
        
        movimientos = new Movimiento[] {patada, onda};
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
