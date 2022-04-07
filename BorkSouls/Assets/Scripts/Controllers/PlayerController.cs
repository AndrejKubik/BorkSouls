using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))] //make sure that unity finds a player movement component
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask movementMask;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Interactable focusedObject;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return; //if the cursor is hovering over UI then do nothing

        if(Input.GetMouseButtonDown(0)) //when left mouse button is clicked
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition); //create a ray at the global position of the click
            RaycastHit hit; //create a reference for the target hit by the ray

            if(Physics.Raycast(ray, out hit, 100, movementMask)) //if the created ray has hit something within the maximum allowed distance in the chosen layer
            {
                movement.MoveToPoint(hit.point); //move the player object to the position of the click
                RemoveFocus(); //reset the camera focus
            }
        }

        if (Input.GetMouseButtonDown(1)) //when right mouse button is clicked
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition); //create a ray at the global position of the click
            RaycastHit hit; //create a reference for the target hit by the ray

            if (Physics.Raycast(ray, out hit, 100)) //if the created ray has hit something within the maximum allowed distance
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>(); //store the information about a clicked interactable object
                if(interactable != null) //if an interactable object is clicked
                {
                    SetFocusTo(interactable); //focus onto the clicked object
                }
            }
        }
    }

    void SetFocusTo(Interactable newFocus)
    {
        if(newFocus != focusedObject) //when we focus a different interactable object
        {
            if(focusedObject != null) //if there is a focused object
            {
                focusedObject.OnDeFocused(); //reset the focus bool and clear player's transform
            }
            focusedObject = newFocus; //focus on the clicked interactable object
            movement.FollowTarget(newFocus); //move towards the interactable object
        }
        newFocus.OnFocused(transform); //trigger the focus bool on the interactable object and load in player's transform for distance measure
    }

    void RemoveFocus()
    {
        if(focusedObject != null) //if there is a focused object
        {
            focusedObject.OnDeFocused(); //reset the focus bool and clear player's transform
            focusedObject = null; //remove the focus from an object
        }
        movement.StopFollowingTarget(); //stop moving towards the interactable object
    }
}
