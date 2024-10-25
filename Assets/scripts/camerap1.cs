using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform playerBody;  // El transform del personaje (a quien sigue la cámara)
    public float mouseSensitivity = 2.0F;  // Sensibilidad del ratón
    private float xRotation = 0f;  // Control de la rotación vertical (pitch)

    private void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Obtener los movimientos del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Controlar la rotación vertical de la cámara (arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación vertical

        // Aplicar la rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // La rotación horizontal del personaje ya se controla en el script de movimiento
        // Pero aquí aseguramos que la cámara siga el movimiento horizontal
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
