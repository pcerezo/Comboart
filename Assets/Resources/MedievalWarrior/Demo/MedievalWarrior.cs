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
        
        Movimiento espadazo = new Movimiento("Espadazo 4", 15, "ataque_fisico");
        Movimiento correr = new Movimiento("Correr", 4, "subir_velocidad");
        
        movimientos = new Movimiento[] {espadazo, correr};
        
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
