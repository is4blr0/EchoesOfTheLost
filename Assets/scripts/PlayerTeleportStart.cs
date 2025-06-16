using UnityEngine;

public class PlayerTeleportStart : MonoBehaviour
{
    void Start()
    {
        string nombrePunto = PlayerPrefs.GetString("PuntoDeLlegada", "");
        if (nombrePunto != "")
        {
            GameObject puntoDeLlegada = GameObject.Find(nombrePunto);
            if (puntoDeLlegada != null)
            {
                transform.position = puntoDeLlegada.transform.position;
                transform.rotation = puntoDeLlegada.transform.rotation;
            }

            PlayerPrefs.DeleteKey("PuntoDeLlegada");
        }
    }
}
