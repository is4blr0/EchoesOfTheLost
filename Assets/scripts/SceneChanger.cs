using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Tooltip("Nombre de la escena a la que se cambiará")]
    public string nombreEscenaDestino;

    private bool yaUsado = false;

    void Start()
    {
        // Si esta zona ya fue usada antes, desactívala
        if (PlayerPrefs.GetInt("zona_" + gameObject.name, 0) == 1)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que el jugador sea quien entra
        if (!yaUsado && other.CompareTag("Player"))
        {
            yaUsado = true;

            // Marcar esta zona como usada para futuras cargas
            PlayerPrefs.SetInt("zona_" + gameObject.name, 1);
            PlayerPrefs.Save();

            // Cambiar de escena
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}
