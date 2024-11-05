using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // El personaje al que la c�mara sigue
    public Vector3 offset = new Vector3(0, 2, -4);  // Offset para la c�mara (ajustado para estar detr�s del jugador)
    public float smoothSpeed = 0.125f;  // Suavidad del movimiento de la c�mara

    void LateUpdate()
    {
        // Verificar si el target est� asignado
        if (target == null)
        {
            Debug.LogWarning("El target no est� asignado a la c�mara.");
            return;
        }

        // Calcular la posici�n deseada con el offset relativo a la rotaci�n del jugador
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Movimiento suave hacia la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Hacer que la c�mara siempre mire hacia el personaje
        transform.LookAt(target);
    }
}
