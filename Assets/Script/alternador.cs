using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alternador : MonoBehaviour
{
    public GameObject firstPersonCamera;  // Cámara de primera persona
    public GameObject thirdPersonCamera;  // Cámara de tercera persona

    void Start()
    {
        // Asegurarse de que se inicia con la cámara en primera persona activada
        firstPersonCamera.SetActive(true);
        thirdPersonCamera.SetActive(false);
    }

    void Update()
    {
        // Alternar entre las cámaras cuando se presiona la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            bool isThirdPersonActive = thirdPersonCamera.activeSelf;

            // Cambiar la activación de las cámaras
            firstPersonCamera.SetActive(isThirdPersonActive);
            thirdPersonCamera.SetActive(!isThirdPersonActive);
        }
    }
}
