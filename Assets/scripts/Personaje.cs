using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Personaje
{
    // Características
    protected float vidaMax, vida;
    protected float ataqueFisico;
    protected float defensaFisica;
    protected float ataqueMagico;
    protected float defensaMagica;
    protected float velocidad;
    protected Movimiento[] movimientos;
    private bool ejecutar;
    private float timer;

    public Personaje()
    {
        vidaMax = vida = 100;
        Debug.Log("Vida del personaje: " + vida);
    }

    // Start is called before the first frame update
    void Start()
    {
        vidaMax = vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        // Contamos el tiempo mientras se hacen las animaciones
        /*if (ejecutar)
        {
            timer += Time.deltaTime;
            m_animator.SetBool("atacando", true);
        }
        else // En otro caso ponemos el contador de tiempo a 0
        {
            timer = 0;
        }
        
        // Si hemos llegado a los 2 segundos de animaciones las terminamos
        if (timer > 2)
        {
            m_animator.SetBool("atacando", false);
            ejecutar = false;
            timer = 0;
        }*/
    }

    /*public void animacionAtacar()
    {
        m_animator.SetBool("atacando", true);
    }
    
    public void animacionIDLE()
    {
        m_animator.SetBool("atacando", false);
    }*/
    
    /*public void ejecutarAnimaciones()
    {
        print("Ejecutando animaciones");
        ejecutar = true;
        //animacionAtacar();
        
        // Controlamos que hayan pasado unos 3 segundos de animación
        if (timer > 3)
        {
            print("Termina la animación de ataque");
            ejecutar = false;
            timer = 0;
        }

        // y volvemos a la animación de espera
        animacionIDLE();
    }*/

    public float getVida()
    {
        return vida;
    }

    /*public void setAnimator(Animator animator)
    {
        m_animator = animator;
    }*/
    
    public float getVidaMaxima()
    {
        return vidaMax;
    }

    public void setVida(float vida)
    {
        if (vida > this.vidaMax)
            vida = vidaMax;
        
        this.vida = vida;
    }

    public void reducirVida(float danio)
    {
        vida -= danio;
    }

    public void setVidaMax(float vidaMax)
    {
        this.vidaMax = vidaMax;
    }
    
    public float getAtaqueFisico()
    {
        return ataqueFisico;
    }

    public float getDefensaFisica()
    {
        return defensaFisica;
    }

    public float getDefensaMagica()
    {
        return defensaMagica;
    }

    public void setAtaqueFisico(float ataqueFisico)
    {
        this.ataqueFisico = ataqueFisico;
    }

    public void subirAtaqueFisico(float subida)
    {
        ataqueFisico += subida;
    }

    public void subirAtaqueMagico(float subida)
    {
        ataqueMagico += subida;
    }

    public void subirVelocidad(float subida)
    {
        velocidad += subida;
    }

    public void subirDefensaFisica(float subida)
    {
        defensaFisica += subida;
    }

    public void subirDefensaMagica(float subida)
    {
        defensaMagica += subida;
    }

    public float getVelocidad()
    {
        return velocidad;
    }

    public void setVelocidad(float velocidad)
    {
        this.velocidad = velocidad;
    }
    
    public int getNumeroMovimientos()
    {
        return movimientos.Length;
    }

    public Movimiento getMovimiento(int index)
    {
        return movimientos[index];
    }
}
