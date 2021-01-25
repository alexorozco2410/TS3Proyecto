using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public bool rotAroundX = false;
    public bool rotAroundY = false;
    public bool rotAroundZ = false;

    public bool rotAroundSelfX = false;
    public bool rotAroundSelfY = false;
    public bool rotAroundSelfZ = false;

    public Transform reference;
    public Transform obj;

    public GameObject componenteAnimacion;

    // Update is called once per frame
    void FixedUpdate()
    {
      if (rotAroundX == true && reference != null) {
          obj.transform.RotateAround(reference.transform.position, Vector3.right, -20.0f * Time.deltaTime);
            //obj.transform.RotateAround(new Vector3(0.0f,0.0f,0.0f), Vector3.up, -2.0f);
      }
      if (rotAroundY == true && reference != null) {
          obj.transform.RotateAround(reference.transform.position, Vector3.up, -20.0f * Time.deltaTime);
            //obj.transform.RotateAround(new Vector3(0.0f,0.0f,0.0f), Vector3.up, -2.0f);
      }
      if (rotAroundZ == true && reference != null) {
          obj.transform.RotateAround(reference.transform.position, Vector3.forward, -20.0f * Time.deltaTime);
            //obj.transform.RotateAround(new Vector3(0.0f,0.0f,0.0f), Vector3.up, -2.0f);
      }

      if (rotAroundSelfX == true) {
          obj.transform.RotateAround(obj.transform.position, Vector3.right, -20.0f * Time.deltaTime);
      }
      if (rotAroundSelfY == true) {
          obj.transform.RotateAround(obj.transform.position, Vector3.up, -20.0f * Time.deltaTime);
      }
      if (rotAroundSelfZ == true) {
          obj.transform.RotateAround(obj.transform.position, Vector3.forward, -20.0f * Time.deltaTime);
      }

      //Debug.Log(reference);
      //Debug.Log(rotAround);
    }

  //  public void ActualizaValores(){
  //      rotAroundY = componenteAnimacion.GetComponent<AnimateObject>().rotAroundOtherX;
  //      reference = componenteAnimacion.GetComponent<AnimateObject>().toRotate;
  //  }

}
