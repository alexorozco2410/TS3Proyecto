using System.Collections;
using UnityEngine;

public class MoveObjects : MonoBehaviour {

    public string draggingTag;
    public Camera cam;

    private Vector3 dis;
    private float posX;
    private float posY;

    private bool touched = false;
    private bool dragging = false;

    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;

    private float moveInX = 1.0f;
    private float moveInY = 1.0f;
    private float moveInZ = 1.0f;

    void FixedUpdate () {

        if (Input.touchCount != 1) { //numero de toques en la pantalla, es decir si no hay uno y un solo dedo
            dragging = false;
            touched = false;
            if (toDragRigidbody) {
                SetFreeProperties(toDragRigidbody);
            }
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began) {
            RaycastHit hit;
            //se dispara un rayo desde la posicion en panmtalla donde tocamos
            Ray ray = cam.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == draggingTag) {
                toDrag = hit.transform;
                previousPosition = toDrag.position;
                toDragRigidbody = toDrag.GetComponent<Rigidbody>();

                dis = cam.WorldToScreenPoint(previousPosition);
                posX = Input.GetTouch(0).position.x - dis.x;
                posY = Input.GetTouch(0).position.y - dis.y;

                SetDraggingProperties(toDragRigidbody);

                touched = true;
            }
        }

        if (touched && touch.phase == TouchPhase.Moved) {
            dragging = true;

            float posXNow = Input.GetTouch(0).position.x - posX;
            float posYNow = Input.GetTouch(0).position.y - posY;
            Vector3 curPos = new Vector3(posXNow, posYNow, dis.z);

            //recibe la posicion en pixeles (pantalla) del toque que realizamos
            //y lo representa en una posicion de mundo
            Vector3 worldPos = cam.ScreenToWorldPoint(curPos) - previousPosition;
            worldPos = new Vector3(worldPos.x * moveInX, worldPos.y * moveInY, worldPos.z * moveInZ);

            toDragRigidbody.velocity = worldPos / (Time.deltaTime * 10);

            previousPosition = toDrag.position;
            toDrag.transform.parent.GetChild(1).GetComponent<MenuUpdate>().ActualizarMenu();
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
            toDragRigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            toDrag.transform.parent.GetChild(1).GetComponent<MenuUpdate>().ActualizarMenu();
            dragging = false;
            touched = false;
            previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
            SetFreeProperties(toDragRigidbody);
        }

    }

    public void MoveOnlyX(){
      moveInX = 1.0f;
      moveInY = 0.0f;
      moveInZ = 0.0f;
    }

    public void MoveOnlyY(){
      moveInX = 0.0f;
      moveInY = 1.0f;
      moveInZ = 0.0f;
    }

    public void MoveOnlyZ(){
      moveInX = 0.0f;
      moveInY = 0.0f;
      moveInZ = 1.0f;
    }

    public void MoveXYZ(){
      moveInX = 1.0f;
      moveInY = 1.0f;
      moveInZ = 1.0f;
    }

    private void SetDraggingProperties (Rigidbody rb) {
        rb.useGravity = false;
        rb.drag = 20; //que tan lento caera el objeto
    }

    private void SetFreeProperties (Rigidbody rb) {
      //  rb.useGravity = true;
        rb.drag = 3; //que tan lento caera el objeto
    }
}
