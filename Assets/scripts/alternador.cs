using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alternador : MonoBehaviour
{
    public GameObject firstPersonCamera;  // C�mara de primera persona
    public GameObject thirdPersonCamera;  // C�mara de tercera persona

    void Start()
    {
        // Asegurarse de que se inicia con la c�mara en primera persona activada
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
    }

    void Update()
    {
        // Alternar entre las c�maras cuando se presiona la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            bool isThirdPersonActive = thirdPersonCamera.activeSelf;

            // Cambiar la activaci�n de las c�maras
            firstPersonCamera.SetActive(isThirdPersonActive);
            thirdPersonCamera.SetActive(!isThirdPersonActive);
        }
    }
}
