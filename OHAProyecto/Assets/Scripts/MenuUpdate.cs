using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUpdate : MonoBehaviour
{
    public GameObject objRef;
    public GameObject menu;

    // Update is called once per frame
    public void ActualizarMenu()
    {
      //  float escalaX =
        //Debug.Log(objRef.transform.parent.GetChild(1));
        menu.transform.position = new Vector3((objRef.transform.position.x - (Mathf.Abs(objRef.transform.localScale.x)/2) * 0.13f) + (0.5f)*0.1f,
        objRef.transform.position.y, (objRef.transform.position.z - (Mathf.Abs(objRef.transform.localScale.z)/2) * 0.13f) + (0.5f) * 0.1f);
    }
}
