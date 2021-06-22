using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EscenaSeleccion()
    {
        SceneManager.LoadScene("SeleccionPersonaje");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
