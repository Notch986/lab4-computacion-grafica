using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerapl : MonoBehaviour
{
    public Transform target;  // El personaje al que la cámara sigue
    public float smoothSpeed = 0.125f;  // Suavidad del movimiento de la cámara
    public Vector3 offset;  // Offset para ajustar la posición de la cámara respecto al personaje

    private void LateUpdate()
    {
        // Verificar si el target (personaje) está asignado
        if (target == null)
        {
            Debug.LogWarning("El target no está asignado a la cámara.");
            return;
        }

        // Mantener la cámara en el plano X e Y (dejando fijo el eje Z)
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        // Movimiento suave hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
