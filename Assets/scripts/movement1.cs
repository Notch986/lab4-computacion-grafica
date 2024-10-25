using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement1 : MonoBehaviour
{
    public float speed = 6.0F;         // Velocidad del personaje
    public float jumpSpeed = 8.0F;     // Fuerza del salto
    public float gravity = 20.0F;      // Gravedad que afecta al personaje

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
        // Movimiento del personaje en el eje X (izquierda/derecha) y eje Y (saltar)
        if (controller.isGrounded)
        {
            // Movimiento en el eje X (A/D o flechas izquierda/derecha)
            float moveX = Input.GetAxis("Horizontal");  // Movimiento a la izquierda/derecha (A/D o flechas)

            // Debug para verificar si el input se detecta
            Debug.Log("Movimiento X: " + moveX);

            // Mover al personaje en la dirección horizontal (eje X)
            moveDirection = new Vector3(moveX * speed, moveDirection.y, 0);

            // Salto en el eje Y
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Aplicar gravedad al movimiento en el eje Y
        moveDirection.y -= gravity * Time.deltaTime;

        // Mover al personaje usando el CharacterController en los ejes X (izquierda/derecha) y Y (saltar)
        controller.Move(moveDirection * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionó tiene el tag "salida"
        if (other.CompareTag("salida"))
        {
            // Cambia a la escena que quieras (por índice o nombre)
            SceneManager.LoadScene(0); // Cambia al índice de escena 1 (ajústalo según tu configuración)
        }
    }
}
