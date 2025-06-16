using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMove : MonoBehaviour
{
    public float velocidadDeMovimiento = 5f;
    public float velocidadDeGiro = 100f;

    public float fuerzaDeSalto = 8f;
    public float gravedad = 20f;
    private float velocidadVertical = 0f;

    private CharacterController controlPersonaje;

    public Transform camaraJugador;
    private float rotacionVertical = 0f;

    void Start()
    {
        controlPersonaje = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 direccionDeMovimiento =
            (transform.forward * inputVertical) + (transform.right * inputHorizontal);

        direccionDeMovimiento = direccionDeMovimiento.normalized * velocidadDeMovimiento;

        if (controlPersonaje.isGrounded)
        {
            velocidadVertical = 0;

            if (Input.GetButtonDown("Jump"))
            {
                velocidadVertical = fuerzaDeSalto;
            }
        }

        velocidadVertical -= gravedad * Time.deltaTime;

        direccionDeMovimiento.y = velocidadVertical;

        controlPersonaje.Move(direccionDeMovimiento * Time.deltaTime);

        float giroHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(0, giroHorizontal * velocidadDeGiro * Time.deltaTime, 0);

        float giroVertical = Input.GetAxis("Mouse Y") * velocidadDeGiro * Time.deltaTime;
        rotacionVertical -= giroVertical;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -60f, 60f);
        camaraJugador.localRotation = Quaternion.Euler(rotacionVertical, 0f, 0f);
    }
}
