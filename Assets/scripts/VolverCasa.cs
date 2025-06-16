using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverACasa : MonoBehaviour
{
    public string desdeEscena = "Prueba1"; 

    public void Volver()
    {
        PlayerPrefs.SetString("EscenaAnterior", desdeEscena);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Casa");
    }
}
