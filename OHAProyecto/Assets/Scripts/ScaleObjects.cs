using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjects : MonoBehaviour
{
    public string scalingTag;
    public Camera cam;

    private Vector3 initialScale;
    private float initialFingerDistance;

    private bool touched2 = false;
    private bool scaling = false;

    private Transform toScale;
    private Rigidbody toScaleRigidbody;
  //  private bool nothing = false;

    private bool scaleInX = false;
    private bool scaleInY = false;
    private bool scaleInZ = false;
    private bool scaleXYZ = true;

    private float scaleFactor = 1.0f;

    private float scaleFactorX = 1.0f;
    private float scaleFactorY = 1.0f;
    private float scaleFactorZ = 1.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
      if (Input.touchCount == 0) { //numero de toques en la pantalla, es decir si no hay uno y un solo dedo
          scaling = false;
          touched2 = false;
//
          return;
      }

      Touch touch1 = Input.touches[0];
      Touch touch2 = Input.touches[1];
      Vector3 pos1 = touch1.position;   //se obtienen las posiciones de los dedos en pantalla
      Vector3 pos2 = touch2.position;

      if (touch1.phase == TouchPhase.Began) {
        RaycastHit hit1;
      //  RaycastHit hit2;
        //se dispara un rayo desde la posicion en pantalla donde tocamos
        Ray ray1 = cam.ScreenPointToRay(pos1);
      //  Ray ray2 = cam.ScreenPointToRay(pos2);

        if ((Physics.Raycast(ray1, out hit1) && hit1.collider.tag == scalingTag) ) {
            toScale = hit1.transform;
            toScaleRigidbody = toScale.GetComponent<Rigidbody>();

            if (Input.touchCount == 2) {
              initialFingerDistance = Vector3.Distance(Input.touches[0].position, Input.touches[1].position);
              initialScale = toScale.transform.localScale;

              touched2 = true;
            }
        //    touched2 = true;
        }
      }

      if (touched2 && (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) ) {
        scaling = true;

        float currentDistance = Vector3.Distance(Input.touches[0].position, Input.touches[1].position);
        scaleFactor = currentDistance / initialFingerDistance;

        ActiveScaleAxis();

        toScale.transform.localScale = new Vector3(initialScale.x * scaleFactorX, initialScale.y * scaleFactorY, initialScale.z * scaleFactorZ);

        toScale.transform.parent.GetChild(1).GetComponent<MenuUpdate>().ActualizarMenu();

      }

      if (scaling && ( (touch1.phase == TouchPhase.Ended || touch1.phase == TouchPhase.Canceled) && (touch2.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Canceled) ) ) {
          scaling = false;
          touched2 = false;
    //      toScale = null;
        //  return;
      }

    }

    public void ScaleOnlyX(){
        scaleInX = true;
        scaleInY = false;
        scaleInZ = false;
        scaleXYZ = false;
    }

    public void ScaleOnlyY(){
        scaleInX = false;
        scaleInY = true;
        scaleInZ = false;
        scaleXYZ = false;
    }

    public void ScaleOnlyZ(){
        scaleInX = false;
        scaleInY = false;
        scaleInZ = true;
        scaleXYZ = false;
    }

    public void ScaleInXYZ(){
        scaleInX = false;
        scaleInY = false;
        scaleInZ = false;
        scaleXYZ = true;
    }

    public void ActiveScaleAxis(){
      if (scaleInX) {
        scaleFactorX = scaleFactor;
        scaleFactorY = 1.0f;
        scaleFactorZ = 1.0f;
      }
      if (scaleInY) {
        scaleFactorX = 1.0f;
        scaleFactorY = scaleFactor;
        scaleFactorZ = 1.0f;
      }
      if (scaleInZ){
        scaleFactorX = 1.0f;
        scaleFactorY = 1.0f;
        scaleFactorZ = scaleFactor;
      }
      if (scaleXYZ){
        scaleFactorX = scaleFactor;
        scaleFactorY = scaleFactor;
        scaleFactorZ = scaleFactor;
      }
    }

}
