using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour
{
    // Le pasamos el animator del personaje
    public Animator animator;
    
    // Indicamos si es el momento de la animación o no
    private bool animar;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (animar)
        {
            animator.SetBool("atacando", true);

            esperar();

            animar = false;
        }
    }

    public IEnumerator esperar()
    {
        yield return new WaitForSeconds(2);
    }
}
