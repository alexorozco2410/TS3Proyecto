using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpciones : MonoBehaviour
{

  public GameObject toEditate;
    //public GameObject circulo;
  Renderer m_ObjectRenderer;

  private Rigidbody editateRB;

  private Collider editateCollider;

  private GameObject[] transformaciones;

  private bool objactivado = false;

  public void Start(){
    m_ObjectRenderer = toEditate.GetComponent<Renderer>();
    editateRB = toEditate.GetComponent<Rigidbody>();
    editateCollider = toEditate.GetComponent<Collider>();
    transformaciones = GameObject.FindGameObjectsWithTag("Transformaciones");
  }

  public void ActivarObjeto(){
    if (editateCollider.enabled == false) {
      editateCollider.enabled = true;
      objactivado = true;
    }
  }

  public void DesactivarObjeto(){
    if (objactivado == true) {
      toEditate.GetComponent<Collider>().enabled = false;
      objactivado = false;
    }else{
      toEditate.GetComponent<Collider>().enabled = true;
      objactivado = true;
    }
    setTagNoEdit();
  //  editateRB.constraints = RigidbodyConstraints.None;
  }

  public void setTagMove(){
    toEditate.tag = "MovingObjects";
    ActivarObjeto();
//    rb2d.freezeRotation = true;
    editateRB.constraints = RigidbodyConstraints.FreezeRotationZ
    | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
  }

  public void setTagScale(){
    toEditate.tag = "ScalingObjects";
    ActivarObjeto();
    editateRB.constraints = RigidbodyConstraints.None;
  }

  public void setTagRotate(){
    toEditate.tag = "RotatingObjects";
    ActivarObjeto();
  }

  public void setTagNoEdit(){
    toEditate.tag = "NoEditObjects";
  }

  public void changeColorRed(){
  //  m_ObjectRenderer = toEditate.GetComponent<Renderer>();
    m_ObjectRenderer.material.color = new Color(1.0f, 0.0f, 0.0f);
  }

  public void changeColorBlue(){
  //  m_ObjectRenderer = toEditate.GetComponent<Renderer>();
    m_ObjectRenderer.material.color = new Color(0.0f, 0.0f, 1.0f);
  }

  public void ChangeColorGreen(){
  //  m_ObjectRenderer = toEditate.GetComponent<Renderer>();
    m_ObjectRenderer.material.color = new Color(0.0f, 1.0f, 0.0f);
  }

  public void ChangeColorYellow(){
  //  m_ObjectRenderer = toEditate.GetComponent<Renderer>();
    m_ObjectRenderer.material.color = new Color(1.0f, 1.0f, 0.0f);
  }

  public void ChangeColorWhite(){
  //  m_ObjectRenderer = toEditate.GetComponent<Renderer>();
    m_ObjectRenderer.material.color = new Color(1.0f, 1.0f, 1.0f);
  }

  public void ChangeColorBlack(){
  //  m_ObjectRenderer = toEditate.GetComponent<Renderer>();
    m_ObjectRenderer.material.color = new Color(0.0f, 0.0f, 0.0f);
  }

  public void ActiveOnlyX(){
    if (toEditate.tag == "MovingObjects") {
      transformaciones[0].GetComponent<MoveObjects>().MoveOnlyX();
    }
    if (toEditate.tag == "ScalingObjects") {
      transformaciones[0].GetComponent<ScaleObjects>().ScaleOnlyX();
    }
    if (toEditate.tag == "RotatingObjects") {
      transformaciones[0].GetComponent<RotateObjects>().RotateOnlyX();
    }
  }

  public void ActiveOnlyY(){
    if (toEditate.tag == "MovingObjects") {
      transformaciones[0].GetComponent<MoveObjects>().MoveOnlyY();
    }
    if (toEditate.tag == "ScalingObjects") {
      transformaciones[0].GetComponent<ScaleObjects>().ScaleOnlyY();
    }
    if (toEditate.tag == "RotatingObjects") {
      transformaciones[0].GetComponent<RotateObjects>().RotateOnlyY();
    }
  }

  public void ActiveOnlyZ(){
    if (toEditate.tag == "MovingObjects") {
      transformaciones[0].GetComponent<MoveObjects>().MoveOnlyZ();
    }
    if (toEditate.tag == "ScalingObjects") {
      transformaciones[0].GetComponent<ScaleObjects>().ScaleOnlyZ();
    }
    if (toEditate.tag == "RotatingObjects") {
      transformaciones[0].GetComponent<RotateObjects>().RotateOnlyZ();
    }
  }

  public void ActiveXYZ(){
    if (toEditate.tag == "MovingObjects") {
      transformaciones[0].GetComponent<MoveObjects>().MoveXYZ();
    }
    if (toEditate.tag == "ScalingObjects") {
      transformaciones[0].GetComponent<ScaleObjects>().ScaleInXYZ();
    }
    if (toEditate.tag == "RotatingObjects") {
      transformaciones[0].GetComponent<RotateObjects>().RotateXY();
    }
  }

}
