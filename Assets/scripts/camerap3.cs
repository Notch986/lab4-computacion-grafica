using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // El personaje al que la cámara sigue
    public Vector3 offset = new Vector3(0, 2, -4);  // Offset para la cámara (ajustado para estar detrás del jugador)
    public float smoothSpeed = 0.125f;  // Suavidad del movimiento de la cámara

    void LateUpdate()
    {
        // Verificar si el target está asignado
        if (target == null)
        {
            Debug.LogWarning("El target no está asignado a la cámara.");
            return;
        }

        // Calcular la posición deseada con el offset relativo a la rotación del jugador
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Movimiento suave hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Hacer que la cámara siempre mire hacia el personaje
        transform.LookAt(target);
    }
}
