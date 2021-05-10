using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    // Características
    protected float vidaMax;
    protected float ataqueFisico;
    protected float defensaFisica;
    protected float ataqueMagico;
    protected float defensaMagica;
    protected float velocidad;
    protected float danio;
    protected float defensa;
    // Variables de combate
    protected Animator m_animator;
    public float vida;
    public GameObject flecha;
    public GameObject barraVida;
    public Slider slider;
    private bool terminado, ejecutar; // Variable para indicar si terminó de escoger
    //private Movimiento movimientoSiguiente; // Variable para guardar el próximo movimiento a ejecutar
    private float timer; // Variable para controlar el tiempo de animación

    // Start is called before the first frame update
    void Start()
    {
        barraVida.SetActive(true);
        slider.maxValue = vidaMax;
        slider.value = vidaMax;
        timer = 0;
        m_animator.GetComponent<Animator>();
        flecha.SetActive(false);
        terminado = false;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.SetActive(true);
        
        // Contamos el tiempo mientras se hacen las animaciones
        if (ejecutar)
        {
            timer += Time.deltaTime;
            m_animator.SetBool("atacando", true);
        }
        /*else // En otro caso ponemos el contador de tiempo a 0
        {
            timer = 0;
        }*/
        
        // Si hemos llegado a los 2 segundos de animaciones las terminamos
        if (timer > 2)
        {
            m_animator.SetBool("atacando", false);
            ejecutar = false;
            timer = 0;
        }

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

    public void mostrarFlecha(bool mostrar)
    {
        flecha.SetActive(mostrar);
    }

    public void mostrarBarraVida()
    {
        
    }

    public IEnumerator animacionAtacar()
    {
        m_animator.SetBool("atacando", true);
        print("animator: atacando = " + m_animator.GetBool("atacando"));
        
        Update();
        //Esperamos unos 2 segundos a que se ejecute la animación
        yield return new WaitForSeconds(2);
    }

    public void animacionIDLE()
    {
        m_animator.SetBool("atacando", false);
        Update();
    }

    public void actualizar(float vida, float ataqueFisico, float defensaFisica, float ataqueMagico, float defensaMagica, float velocidad)
    {
        this.vida = vida;
        this.ataqueFisico = ataqueFisico;
        this.defensaFisica = defensaFisica;
        this.ataqueMagico = ataqueMagico;
        this.defensaMagica = defensaMagica;
        this.velocidad = velocidad;
    }

    public void setDanio(Movimiento mov)
    {
        danio = mov.getPotencia();
    }

    public float getDanio()
    {
        return danio;
    }

    public void setTerminado(bool terminado)
    {
        this.terminado = terminado;
    }

    public bool getTerminado()
    {
        return terminado;
    }

    public void ejecutarAnimaciones()
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
    }

    public void recibirDanio(float danio)
    {
        vida -= danio;
        slider.value = vida;
    }

    public float getVida()
    {
        return vida;
    }
    
    public float getVidaMaxima()
    {
        return vidaMax;
    }

    public float getAtaqueFisico()
    {
        return ataqueFisico;
    }

    public void setAtaqueFisico(float ataqueFisico)
    {
        this.ataqueFisico = ataqueFisico;
    }

}
    
