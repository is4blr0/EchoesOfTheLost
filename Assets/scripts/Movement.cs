using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Velocidad de movimiento y giro.
    public float velocidadDeMovimiento = 5f;
    public float velocidadDeGiro = 100f;

    // Parametros del salto.
    public float fuerzaDeSalto = 8f;
    public float gravedad = 20f;
    private float velocidadVertical = 0f;

    private CharacterController controlPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        controlPersonaje = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento.
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        // Calculamos la direccion local del movimiento.
        Vector3 direccionDeMovimiento =
            (transform.forward * inputVertical) + (transform.right * inputHorizontal);

        direccionDeMovimiento = direccionDeMovimiento.normalized * velocidadDeMovimiento;

        // Verificamos si el personaje del jugador esta en el suelo.
        if (controlPersonaje.isGrounded)
        {
            // Reseteamos la velocidad vertical si esta tocando el suelo.
            velocidadVertical = 0;

            // Salto, presionando la tecla espacio.
            if (Input.GetButtonDown("Jump"))
            {
                velocidadVertical = fuerzaDeSalto;
            }
        }

        // Aplicamos gravedad.
        velocidadVertical -= gravedad * Time.deltaTime;

        // Anadimos el movimiento vertical para hacer el salto.
        direccionDeMovimiento.y = velocidadVertical;

        // Aplicamos el movimiento al personaje del jugador.
        controlPersonaje.Move(direccionDeMovimiento * Time.deltaTime);

        // Giro del personaje con el raton.
        float giro = Input.GetAxis("Mouse X");
        transform.Rotate(0, giro * velocidadDeGiro * Time.deltaTime, 0);
    }
}