using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerapl : MonoBehaviour
{
    public Transform target;  // El personaje al que la c�mara sigue
    public float smoothSpeed = 0.125f;  // Suavidad del movimiento de la c�mara
    public Vector3 offset;  // Offset para ajustar la posici�n de la c�mara respecto al personaje

    private void LateUpdate()
    {
        // Verificar si el target (personaje) est� asignado
        if (target == null)
        {
            Debug.LogWarning("El target no est� asignado a la c�mara.");
            return;
        }

        // Mantener la c�mara en el plano X e Y (dejando fijo el eje Z)
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        // Movimiento suave hacia la posici�n deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
