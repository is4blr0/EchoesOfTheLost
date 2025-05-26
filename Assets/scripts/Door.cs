using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door; // Asignamos la puerta correspondiente al boton concreto en el inspector.
    public float moveDistance = 2.0f; // Distancia que se movera la puerta.
    public float moveSpeed = 2.0f; // Velocidad del movimiento de la puerta (hacia arriba).

    private Vector3 initialPosition;
    private bool isActivated = false;

    void Start()
    {
        initialPosition = door.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            StartCoroutine(MoveDoor());
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