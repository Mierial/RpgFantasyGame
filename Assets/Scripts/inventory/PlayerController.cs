using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera cam;

    public Interactable focus;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        if (focus != null) {
            float distance = Vector3.Distance(focus.transform.position, transform.position);
            if (distance > focus.radius) {
                removeFocus();
            }
        }

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void SetFocus(Interactable newFocus) {
        focus = newFocus;
    }

    void removeFocus() {
        focus = null;
    }
}
