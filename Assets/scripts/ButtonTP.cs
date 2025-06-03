using UnityEngine;
using System.Collections;

public class ButtonTP : MonoBehaviour
{
    [Tooltip("Nombre del objeto al que se quiere teletransportar al jugador")]
    public string nombreDestino = "Suelo (19)";
    [Tooltip("Tiempo en segundos antes de hacer el teletransporte")]
    public float retardo = 5f;

    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;
            StartCoroutine(TeletransportarDespuesDeTiempo(other.gameObject));
        }
    }

    private IEnumerator TeletransportarDespuesDeTiempo(GameObject jugador)
    {
        yield return new WaitForSeconds(retardo);

        GameObject destino = GameObject.Find(nombreDestino);

        if (destino != null)
        {
            jugador.transform.position = destino.transform.position;
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto destino con nombre: " + nombreDestino);
        }
    }
}
