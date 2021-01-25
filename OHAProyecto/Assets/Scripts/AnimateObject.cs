using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateObject : MonoBehaviour
{

    public Transform toAnimRot;
    public Transform toRotate;
    public Camera cam;
    // Update is called once per frame

    public GameObject AnimationObject;

    public bool rotAroundOtherX = false;
    public bool rotAroundOtherZ = false;

    public bool activeRotZ = false;
    public bool activeRotX = false;
    public bool activeRotY = false;

    public bool activeRotSelfX = false;
    public bool activeRotSelfY = false;
    public bool activeRotSelfZ = false;

    void Start(){
      cam = Camera.main;
    }

    //void Start(){
    //  transformaciones = GameObject.FindGameObjectsWithTag("Transformaciones");
    //}
  //  void FixedUpdate(){
  //    if (rotAroundOtherX == true) {
  //      toAnimRot.transform.RotateAround(toRotate.transform.position, Vector3.up, -10.0f);
  //    }
  //  }

    public void AnimRot(){
      while(Input.touchCount != 1){
        Debug.Log("selecciona el objeto");
      }
      //  if (Input.touchCount != 1) { //numero de toques en la pantalla, es decir si no hay uno y un solo dedo
      //  }

        if (Input.touchCount == 1) {
          Touch touch = Input.touches[0];
          Vector3 posTouch = touch.position;

          if (touch.phase == TouchPhase.Began) {
            RaycastHit hitRotate;
            Ray ray = cam.ScreenPointToRay(posTouch);

            if (Physics.Raycast(ray, out hitRotate)) {
              toRotate = hitRotate.transform;
          ///
            ///touched3 = true;
            Debug.Log(toRotate);
            //rotAroundOtherX =true;
            return;
            }
          }
        }
    }

    public void probar(){
      StartCoroutine(Delay());
    }
    IEnumerator Delay(){
      yield return new WaitForSeconds(1);
      Debug.Log("touch to continue");
      var selected = false;
      while(selected == false){
        if (Input.touchCount == 1) {
          Touch touch = Input.touches[0];
          Vector3 posTouch = touch.position;

          if (touch.phase == TouchPhase.Began) {
            RaycastHit hitRotate;
            Ray ray = cam.ScreenPointToRay(posTouch);

            if (Physics.Raycast(ray, out hitRotate)) {
              toRotate = hitRotate.transform;
          ///
            ///touched3 = true;
            //Debug.Log(toRotate);

              rotAroundOtherX = true;
              SendParametersRot();
            //  AnimationObject.GetComponent<Animate>().rotAroundY = true;
            //  AnimationObject.GetComponent<Animate>().reference = toRotate;
            //  AnimationObject.GetComponent<Animate>().ActualizaValores();
              selected = true;
            //return;
            }
          }
        }
        //if (Input.touchCount == 1)
        //{
        //    selected = true;
        //    rotAroundOtherX =true;
        //}
        yield return null;
      }
    //  Application.LoadLevel("TheGame2");
        Debug.Log("lo hiciste");
    }

    public void SendParametersRot(){
  //    AnimationObject.GetComponent<Animate>().rotAroundY = rotAroundOtherX;
      AnimationObject.GetComponent<Animate>().reference = toRotate;
    }

    public void SendParameterXRot(){
      if (activeRotX == false) {
        AnimationObject.GetComponent<Animate>().rotAroundX = true;
        activeRotX = true;
      }else{
        AnimationObject.GetComponent<Animate>().rotAroundX = false;
        activeRotX = false;
      }
    }

    public void SendParameterYRot(){
      if (activeRotY == false) {
        AnimationObject.GetComponent<Animate>().rotAroundY = true;
        activeRotY = true;
      }else{
        AnimationObject.GetComponent<Animate>().rotAroundY = false;
        activeRotY = false;
      }
    }

    public void SendParameterZRot(){
      if (activeRotZ == false) {
          AnimationObject.GetComponent<Animate>().rotAroundZ = true;
          activeRotZ = true;
      }else{
          AnimationObject.GetComponent<Animate>().rotAroundZ = false;
          activeRotZ = false;
      }
    }

    public void SendSelfXRot(){
      if (activeRotSelfX == false) {
          AnimationObject.GetComponent<Animate>().rotAroundSelfX = true;
          activeRotSelfX = true;
      }else{
          AnimationObject.GetComponent<Animate>().rotAroundSelfX = false;
          activeRotSelfX = false;
      }
    }

    public void SendSelfYRot(){
      if (activeRotSelfY == false) {
          AnimationObject.GetComponent<Animate>().rotAroundSelfY = true;
          activeRotSelfY = true;
      }else{
          AnimationObject.GetComponent<Animate>().rotAroundSelfY = false;
          activeRotSelfY = false;
      }
    }

    public void SendSelfZRot(){
      if (activeRotSelfZ == false) {
          AnimationObject.GetComponent<Animate>().rotAroundSelfZ = true;
          activeRotSelfZ = true;
      }else{
          AnimationObject.GetComponent<Animate>().rotAroundSelfZ = false;
          activeRotSelfZ = false;
      }
    }

}
