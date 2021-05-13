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
    public GameObject flecha;
    public GameObject barraVida;
    private GameObject jugador_g_o;
    private Slider slider;
    private float danio;
    private bool terminado, ejecutar; // Variable para indicar si terminó de escoger
    private Movimiento ultimoMovimiento; // Variable para guardar el próximo movimiento a ejecutar
    private float timer; // Variable para controlar el tiempo de animación

    public Jugador(int numero)
    {
        this.jugador_g_o = jugador_g_o;
        // Dependiendo de qué número tenga, se le asigna un personaje u otro
        print("Constructor de jugador");
        switch (numero)
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
        slider = barraVida.GetComponent<Slider>();
        barraVida.SetActive(true);
        timer = 0;
        flecha.SetActive(false);
        terminado = false;
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.SetActive(true);
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

    public void mostrarFlecha(bool mostrar)
    {
        flecha.SetActive(mostrar);
    }

    public void mostrarBarraVida()
    {
        
    }

    public void setDanio(float danio)
    {
        this.danio = danio;
    }

    public float getDanio()
    {
        return danio;
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

    public GameObject getGameObject()
    {
        return this.jugador_g_o;
    }
}
    
