using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class movement : MonoBehaviour
{
    public float speed = 6.0F;         // Velocidad del personaje
    public float jumpSpeed = 8.0F;     // Fuerza del salto
    public float gravity = 20.0F;      // Gravedad que afecta al personaje
    public float mouseSensitivity = 2.0F; // Sensibilidad del ratón para rotar al personaje

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Rotación horizontal del personaje controlada por el ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, mouseX, 0); // Rotar el personaje en el eje Y (horizontal)

        // Movimiento del personaje
        if (controller.isGrounded)
        {
            // Movimiento en todas direcciones (WASD o flechas)
            float moveX = Input.GetAxis("Horizontal");  // Movimiento lateral (A/D o flechas)
            float moveZ = Input.GetAxis("Vertical");    // Movimiento hacia adelante/atrás (W/S o flechas)

            // Mover al personaje en la dirección en la que está mirando
            moveDirection = (transform.forward * moveZ) + (transform.right * moveX);
            moveDirection *= speed;

            // Salto
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Aplicar gravedad
        moveDirection.y -= gravity * Time.deltaTime;

        // Mover al personaje usando el CharacterController
        controller.Move(moveDirection * Time.deltaTime);
    }

    // Este método se llama cuando el personaje colisiona con un trigger
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionó tiene el tag "salida"
        if (other.CompareTag("salida"))
        {
            // Cambia a la escena que quieras (por índice o nombre)
            SceneManager.LoadScene(1); // Cambia al índice de escena 1 (ajústalo según tu configuración)
        }
    }
}
