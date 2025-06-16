using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public string puertaID = "puerta_01"; // ID única para esta puerta
    public float moveDistance = 2.0f;
    public float moveSpeed = 2.0f;

    private Vector3 initialPosition;
    private bool isActivated = false;

    void Start()
    {
        initialPosition = door.transform.position;

        // Revisamos si ya estaba abierta antes
        if (GameStateManag.instance != null && GameStateManag.instance.ObtenerEstado(puertaID))
        {
            door.transform.position = initialPosition + Vector3.up * moveDistance;
            isActivated = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            StartCoroutine(MoveDoor());

            // Guardamos el estado como "abierto"
            if (GameStateManag.instance != null)
            {
                GameStateManag.instance.GuardarEstado(puertaID, true);
            }
        }
    }

    IEnumerator MoveDoor()
    {
        Vector3 targetPosition = initialPosition + Vector3.up * moveDistance;
        while (Vector3.Distance(door.transform.position, targetPosition) > 0.01f)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
