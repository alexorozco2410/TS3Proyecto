using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject selectedObject;

    public void quitObject(){
      Destroy(selectedObject,.5f);
    }
}
