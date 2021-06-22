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
        defensaFisica = defensaMagica = 1;
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
    }

    public float getVida()
    {
        return vida;
    }
    
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
    
    public void setVidaMax(float vidaMax)
    {
        this.vidaMax = vidaMax;
    }
    
    public void setAtaqueFisico(float ataque)
    {
        ataqueFisico = ataque;
    }

    public void setAtaqueMagico(float ataque)
    {
        ataqueMagico = ataque;
    }

    public void setDefensaFisica(float defensa)
    {
        if (defensa <= 0) defensa = (float)0.5;
        defensaFisica = defensa;
    }

    public void setDefensaMagica(float defensa)
    {
        if (defensa <= 0) defensa = (float)0.5;
        defensaMagica = defensa;
    }

    public void reducirVida(float danio)
    {
        vida -= danio;
    }
    
    public float getAtaqueFisico()
    {
        return ataqueFisico;
    }

    public float getAtaqueMagico()
    {
        return ataqueMagico;
    }

    public float getDefensaFisica()
    {
        return defensaFisica;
    }

    public float getDefensaMagica()
    {
        return defensaMagica;
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
