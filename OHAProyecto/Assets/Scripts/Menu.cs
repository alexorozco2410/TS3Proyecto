using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
  //  public GameObject radialMenu;
    public GameObject mostrarBoton;
    public GameObject ocultarBoton;
    public GameObject subMenu;
    public GameObject opcionesSubMenu;
    public GameObject menuColor;
    public GameObject menuTextura;
    public GameObject menuTranformaciones;
    public GameObject menuAnimacion;
  //  public GameObject toEditate;
    //public GameObject circulo;

//    private bool activeMenu = false;

    public void mostrar(){
      //if (activeMenu == false) {
        //radialMenu.SetActive(false);
        mostrarBoton.SetActive(false);
        ocultarBoton.SetActive(true);
      //  circulo.SetActive(true);
        //activeMenu = true;
      //}
    }

    public void ocultar(){
      //if (activeMenu) {
  //      radialMenu.SetActive(true);
        ocultarBoton.SetActive(false);
        mostrarBoton.SetActive(true);
        //circulo.SetActive(false);
        //activeMenu = false;
      //}
    }

    public void activarSubMenu(){
        ocultarBoton.SetActive(false);
        subMenu.SetActive(true);
    }

    public void desactivarSubMenu(){
        ocultarBoton.SetActive(true);
        subMenu.SetActive(false);
    }

    public void ingresarOpcionesColor(){
        menuColor.SetActive(true);
        opcionesSubMenu.SetActive(false);
    }

    public void salirOpcionesColor(){
        menuColor.SetActive(false);
        opcionesSubMenu.SetActive(true);
    }


    public void ingresarOpcionesTextura(){
        menuTextura.SetActive(true);
        opcionesSubMenu.SetActive(false);
    }

    public void salirOpcionesTextura(){
      menuTextura.SetActive(false);
      opcionesSubMenu.SetActive(true);
    }

    public void IngresarOpcionesT(){
      menuTranformaciones.SetActive(true);
      ocultarBoton.SetActive(false);
    }

    public void SalirOpcionesT(){
      menuTranformaciones.SetActive(false);
      ocultarBoton.SetActive(true);
    }

    public void ActivarMenuAnimacion(){
      ocultarBoton.SetActive(false);
      menuAnimacion.SetActive(true);
    }

    public void DesactivarMenuAnimacion(){
      ocultarBoton.SetActive(true);
      menuAnimacion.SetActive(false);
    }

}
