using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 5.0f;

    [SerializeField]
    //The layer that will determine what the raycast will hit
    LayerMask layerMask;
    //The UI text component that will display the name of the interactable hit
    public TextMeshProUGUI interactionInfo;

    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
    private void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        checkForCollider();
        //TODO: Raycast
        //1. Perform a raycast originating from the gameobject's position towards its forward direction.
        //   Make sure that the raycast will only hit the layer specified in the layermask
        //2. Check if the object hits any Interactable. If it does, show the interactionInfo and set its text
        //   to the id of the Interactable hit. If it doesn't hit any Interactable, simply disable the text
        //3. Make sure to interact with the Interactable only when the mouse button is pressed.
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            takeItem();
        }
    }

    void checkForCollider()
    {
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                interactionInfo.text = hit.collider.gameObject.name;
            }
            else
            {
                interactionInfo.text = "";
            }
        }
        else
        {
            interactionInfo.text = "";
        }
    }

    void takeItem()
    {
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                hit.collider.gameObject.GetComponent<Item>().Interact();
            }
            else
            {
                Debug.Log("this is not an interactable object");
            }
        }
        else
        {
            Debug.Log("there is nothing to interact");
        }
    }
}