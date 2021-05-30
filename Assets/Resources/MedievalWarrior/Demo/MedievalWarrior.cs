using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MedievalWarrior : Personaje
{
    public MedievalWarrior()
    {
        Debug.Log("Constructor de MedievalWarrior");
        vidaMax = vida = 100;
        ataqueFisico = 15;
        defensaFisica = 15;
        ataqueMagico = 5;
        defensaMagica = 5;
        velocidad = 10;
        Movimiento espadazo = new Movimiento("Espadazo 4", 5, "ataque_fisico");
        Movimiento tajo = new Movimiento("Tajo rápido", 2, "ataque_fisico");
        Movimiento espadazo2 = new Movimiento("Espadazo 5", 20, "ataque_fisico");
        Movimiento escudo = new Movimiento("Escudo", 5, "subir_defensa_fisica");
        
        movimientos = new Movimiento[] {espadazo, espadazo2, tajo, escudo};
        
        //m_animator = GetComponent<Animator>();
    }
    void Start()
    {
        /*gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Assets/MedievalWarrior/Sprites/Idle") as Sprite;
        vidaMax = vida = 100;
        ataqueFisico = 15;
        defensaFisica = 15;
        ataqueMagico = 5;
        defensaMagica = 5;
        velocidad = 10;
        
        m_animator = GetComponent<Animator>();*/

    }

    void Update()
    {
    }
}
