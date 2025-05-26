using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Respawn()
    {
        // Desactivar temporalmente el objeto para "resetear"
        gameObject.SetActive(false);

        // Posici�n al checkpoint guardado
        transform.position = CheckpointManager.Instance.GetCurrentCheckpoint();

        // Reiniciar la velocidad para que no siga cayendo
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Reactivar el objeto
        gameObject.SetActive(true);
    }
}
