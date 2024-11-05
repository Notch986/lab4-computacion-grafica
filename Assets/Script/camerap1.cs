using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform playerBody;  // El transform del personaje (a quien sigue la c�mara)
    public float mouseSensitivity = 2.0F;  // Sensibilidad del rat�n
    private float xRotation = 0f;  // Control de la rotaci�n vertical (pitch)

    private void Start()
    {
        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Obtener los movimientos del rat�n
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Controlar la rotaci�n vertical de la c�mara (arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotaci�n vertical

        // Aplicar la rotaci�n vertical a la c�mara
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // La rotaci�n horizontal del personaje ya se controla en el script de movimiento
        // Pero aqu� aseguramos que la c�mara siga el movimiento horizontal
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
