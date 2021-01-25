using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjustarMO : MonoBehaviour
{
    //public Text UIResolucion;
    public RectTransform botonmover;


    // Update is called once per frame
    void Update()
    {
        //UIResolucion.text = ("Alto : " + Screen.height + "\n" + "ancho : " + Screen.width + "\n" + Screen.currentResolution);
        posicion();
    }

    public void posicion(){
      //Debug.Log("se ejecuto");
      botonmover.anchoredPosition = new Vector2(Screen.width - 100, Screen.height - 100);
    }
}
