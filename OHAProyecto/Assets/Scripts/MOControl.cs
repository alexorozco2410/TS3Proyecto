using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MOControl : MonoBehaviour
{
    public GameObject openButton;
    public GameObject closeButton;
    public GameObject cubeObj;
    public GameObject sphereObj;
    public GameObject cylinderObj;
    public Transform refObjs;

    private Vector3 origenInst = new Vector3(0.0f, 0.0f, 0.0f);


    public void DesplegarMO(){
      openButton.SetActive(false);
      closeButton.SetActive(true);
    }

    public void OcultarMO(){
      openButton.SetActive(true);
      closeButton.SetActive(false);
    }

    public void InstantCube(){
        Instantiate(cubeObj, refObjs);
    }

    public void InstantSphere(){
        Instantiate(sphereObj, refObjs);
    }

    public void InstantCylinder(){
        Instantiate(cylinderObj, refObjs);
    }

    public void CloseApp(){
        Application.Quit();
    }
}
