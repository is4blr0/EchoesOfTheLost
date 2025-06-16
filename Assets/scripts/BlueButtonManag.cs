using UnityEngine;

public class BotonRegresoManager : MonoBehaviour
{
    public GameObject botonDesdePrueba1;
    public string estadoID1 = "botonPrueba1Activado";

    public GameObject botonDesdePrueba2;
    public string estadoID2 = "botonPrueba2Activado";

    void Start()
    {
        string escenaAnterior = PlayerPrefs.GetString("EscenaAnterior", "");

        if (escenaAnterior == "Prueba1" && !GameStateManag.instance.ObtenerEstado(estadoID1))
        {
            botonDesdePrueba1.SetActive(true);
        }

        if (escenaAnterior == "Prueba2" && !GameStateManag.instance.ObtenerEstado(estadoID2))
        {
            botonDesdePrueba2.SetActive(true);
        }

        PlayerPrefs.DeleteKey("EscenaAnterior");
    }
}
