using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToScene : MonoBehaviour
{
    public string nombreDeEscenaDestino = "Casa";
    public string nombreDelPuntoDeLlegada = "PuntoDeLlegada";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetString("PuntoDeLlegada", nombreDelPuntoDeLlegada);
            SceneManager.LoadScene(nombreDeEscenaDestino);
        }
    }
}
