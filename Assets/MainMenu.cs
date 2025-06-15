using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject PanelControles;
    public GameObject Volume_on;
    public GameObject Volume_off;

    private bool isMuted = false;

    public void Continue()
    {
        MenuPrincipal.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowControls()
    {
        bool isActive = PanelControles.activeSelf;
        PanelControles.SetActive(!isActive);
    }

    public void ToggleVolume()
    {
        isMuted = !isMuted;
        AudioListener.volume = isMuted ? 0f : 1f;
        if (Volume_on != null)
            Volume_on.SetActive(!isMuted);
        if (Volume_off != null)
            Volume_off.SetActive(isMuted);
    }
    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    //Activar y desactivar menu
    private void ToggleMenu()
    {
        bool isActive = MenuPrincipal.activeSelf;

        MenuPrincipal.SetActive(!isActive);


        Time.timeScale = isActive ? 1f : 0f;
    }
    void Start()
    {
        MenuPrincipal.SetActive(false);
        Time.timeScale = 1f; //Asegura que el juego no arranque pausado
    }
}