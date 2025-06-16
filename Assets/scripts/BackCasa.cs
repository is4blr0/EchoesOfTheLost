using UnityEngine;
using UnityEngine.SceneManagement;

public class BackCasa : MonoBehaviour
{
    public string nombreEscena = "Casa"; 
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Guardamos que el botón azul debe aparecer
            GameStateManag.instance.GuardarEstado("botonAzulAparecido", true);

            // Cambiamos a la escena "Casa"
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
