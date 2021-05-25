using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    // Hay que saber qué personaje manejamos
    private Personaje personaje;
    // Variables de combate
    private GameObject jugador_g_o;
    private Animator animator;
    private float danioFisico, danioMagico;
    private bool terminado, ejecutar; // Variable para indicar si terminó de escoger
    private Movimiento ultimoMovimiento; // Variable para guardar el próximo movimiento a ejecutar
    private float timer; // Variable para controlar el tiempo de animación
    private int numero;

    public Jugador(int numero)
    {
        this.numero = numero;
        // Dependiendo de qué número tenga, se le asigna un personaje u otro
        print("Constructor de jugador");
        switch (this.numero)
        {
            case 0:
                personaje = new HeroKnight();
                break;
            case 1:
                personaje = new MedievalWarrior();
                break;
        }

        terminado = false;
        print("Personaje construído");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        terminado = false;
    }

    // Update is called once per frame
    void Update()
    {
        //barraVida.SetActive(true);
        //slider.value = personaje.getVida();

        //Cuando termine de atacar, que vuelva a la animación IDLE
        /*if (Input.GetKeyDown(KeyCode.Space)) // si pulso la tecla de espacio, que ataque
        {
            if (animator.GetBool("atacando") == false)
            {
                // Pasamos al estado de atacar
                animacionAtacar();
            }
        }
        else
        {
            animacionIDLE();
        }*/
    }

    /**
     * Actualizamos la vida y características del jugador
     */
    public void actualizar()
    {

    }

    public void setDanioFisico(float danio)
    {
        danioFisico = danio;
    }

    public float getDanioFisico()
    {
        return danioFisico;
    }
    
    public void setDanioMagico(float danio)
    {
        this.danioMagico = danio;
    }

    public float getDanioMagico()
    {
        return danioMagico;
    }

    /**
     * Recibe daño físico y calcula la vida que se resta
     * según la defensa física
     */
    public void recibirDanioFisico(float danio)
    {
        float danioRecibido = danio; // personaje.getDefensaFisica();

        personaje.reducirVida(danioRecibido);
    }

    public void recibirDanioMagico(float danio)
    {
        float danioRecibido = danio; // personaje.getDefensaMagica();

        personaje.reducirVida(danioRecibido);
    }

    public void setTerminado(bool terminado)
    {
        print("Terminado: " + terminado);
        this.terminado = terminado;
    }

    public bool getTerminado()
    {
        return terminado;
    }
    

    /*public void recibirDanioFisico(float danio)
    {
        // TODO: calcular vida restada según la defensa física
        personaje.setVida(vida - danio);
        slider.value = personaje.getVida();
    }

    public void recibirDanioMagico(float danio)
    {
        // TODO: calcular vida restada según la defensa mágica
        personaje.setVida(vida - danio);
        slider.value = personaje.getVida();
    }*/

    public void setUltimoMovimiento(Movimiento movimiento)
    {
        ultimoMovimiento = movimiento;
    }

    public Movimiento getUltimoMovimiento()
    {
        return ultimoMovimiento;
    }

    public float getVida()
    {
        return personaje.getVida();
    }

    public int getNumeroMovimientos()
    {
        return personaje.getNumeroMovimientos();
    }

    public Movimiento getMovimiento(int index)
    {
        return personaje.getMovimiento(index);
    }

    public void setPersonaje(int numero)
    {
        switch (numero)
        {
            case 0:
                personaje = new HeroKnight();
                break;
            case 1:
                personaje = new MedievalWarrior();
                break;
        }
    }

    public float getVelocidad()
    {
        return personaje.getVelocidad();
    }

    public void subirAtaqueFisico(float subida)
    {
        personaje.subirAtaqueFisico(subida);
    }

    public void subirDefensaFisica(float subida)
    {
        personaje.subirDefensaFisica(subida);
    }

    public void subirVelocidad(float subida)
    {
        personaje.subirVelocidad(subida);
    }

    public GameObject getGameObject()
    {
        return this.jugador_g_o;
    }
}
    
