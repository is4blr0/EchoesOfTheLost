using System.Collections.Generic;
using UnityEngine;

public class GameStateManag : MonoBehaviour
{
    // Acceso global
    public static GameStateManag instance;

    // Diccionario para guardar estados (botones, puertas, zonas, etc.)
    private Dictionary<string, bool> estados = new Dictionary<string, bool>();

    void Awake()
    {
        // Asegurar que solo hay un GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No se destruye al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    // Guarda el estado de algo (por ejemplo, "puerta1" abierta o no)
    public void GuardarEstado(string id, bool valor)
    {
        if (estados.ContainsKey(id))
        {
            estados[id] = valor;
        }
        else
        {
            estados.Add(id, valor);
        }
    }

    // Devuelve el estado actual (si no existe, devuelve false por defecto)
    public bool ObtenerEstado(string id)
    {
        return estados.ContainsKey(id) && estados[id];
    }

    // Reinicia todos los estados (opcional, si quieres usarlo en algún momento)
    public void ReiniciarEstados()
    {
        estados.Clear();
    }
}
