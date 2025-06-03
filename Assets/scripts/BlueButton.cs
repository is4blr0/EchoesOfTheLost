using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueButton : MonoBehaviour
{
    public GameObject objetoAparecer;

    void Start()
    {
        if (PlayerPrefs.GetInt("HaVueltoDePrueba2", 0) == 1)
        {
            objetoAparecer.SetActive(true);
        }
        else
        {
            objetoAparecer.SetActive(false);
        }
    }
}

