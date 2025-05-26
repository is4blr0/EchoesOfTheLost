using UnityEngine;

public class FinalZone : MonoBehaviour
{
    public GameObject mensajeFinal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensajeFinal.SetActive(true);
        }
    }
}
