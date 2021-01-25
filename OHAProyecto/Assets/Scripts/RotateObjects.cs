using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
  public string rotatingTag;
  public Camera cam;
  public float rotateVel;

  private bool touched3 = false;
  private bool rotating = false;

  private Transform toRotate;
  private Rigidbody toRotateRigidbody;

  private bool rotateInX = false;
  private bool rotateInY = false;
  private bool rotateInZ = false;
  private bool rotateInXY = true;

  private float xToRotate = 0.0f;
  private float yToRotate = 0.0f;

  void FixedUpdate(){
    if (Input.touchCount != 1) { //numero de toques en la pantalla, es decir si no hay uno y un solo dedo
        rotating = false;
        touched3 = false;

        return;
    }

    Touch touch = Input.touches[0];
    Vector3 posTouch = touch.position;

    if (touch.phase == TouchPhase.Began) {
      RaycastHit hitRotate;
      Ray ray = cam.ScreenPointToRay(posTouch);

      if (Physics.Raycast(ray, out hitRotate) && hitRotate.collider.tag == rotatingTag) {
        toRotate = hitRotate.transform;
        toRotateRigidbody = toRotate.GetComponent<Rigidbody>();

        touched3 = true;
      }
    }

    if (touched3 && touch.phase == TouchPhase.Moved) {

      rotating = true;

      Vector2 positionT = Input.GetTouch(0).deltaPosition;
      xToRotate = positionT.x * Mathf.Deg2Rad * rotateVel;
      yToRotate = positionT.y * Mathf.Deg2Rad * rotateVel;

    //  toRotate.transform.RotateAround(toRotate.transform.position, Vector3.up, -x);
    //  toRotate.transform.RotateAround(toRotate.transform.position, Vector3.right, y);

      RotateObject();
    }

    if (rotating && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
        rotating = false;
        touched3 = false;
      //  previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
      //  SetFreeProperties(toDragRigidbody);
    }

  }

  public void RotateOnlyX(){
    rotateInX = true;
    rotateInY = false;
    rotateInZ = false;
    rotateInXY = false;
  }

  public void RotateOnlyY(){
    rotateInX = false;
    rotateInY = true;
    rotateInZ = false;
    rotateInXY = false;
  }

  public void RotateOnlyZ(){
    rotateInX = false;
    rotateInY = false;
    rotateInZ = true;
    rotateInXY = false;
  }

  public void RotateXY(){
    rotateInX = false;
    rotateInY = false;
    rotateInZ = false;
    rotateInXY = true;
  }

  public void RotateObject(){
    if (rotateInX) {
      toRotate.transform.RotateAround(toRotate.transform.position, Vector3.up, -xToRotate);
    }
    if (rotateInY) {
      toRotate.transform.RotateAround(toRotate.transform.position, Vector3.right, yToRotate);
    }
    if (rotateInZ) {
      toRotate.transform.RotateAround(toRotate.transform.position, Vector3.forward, -xToRotate);
    }
    if (rotateInXY) {
      toRotate.transform.RotateAround(toRotate.transform.position, Vector3.up, -xToRotate);
      toRotate.transform.RotateAround(toRotate.transform.position, Vector3.right, yToRotate);
    }
  }

}
