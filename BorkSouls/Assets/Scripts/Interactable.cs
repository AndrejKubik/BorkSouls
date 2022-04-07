using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public Transform interactionTransform;

    [SerializeField] private bool isFocused;
    [SerializeField] private bool wasInteracted;
    [SerializeField] private Transform player;
    [SerializeField] private float distance;

    private void Start()
    {
        wasInteracted = false;
    }

    private void Update()
    {
        if(isFocused && !wasInteracted) //if the interactable object is focused and wasn't interacted with
        {
            distance = Vector3.Distance(player.position, interactionTransform.position); //calculate the distancee between the player and the interactable object
            if(distance <= radius) //if the distance is not bigger than the object's interaction radius
            {
                Interact(); //do the interaction method
                wasInteracted = true; //trigger the interaction check
            }
        }
    }

    public virtual void Interact()
    {
        //Debug.Log("Interacting with " + gameObject.name); //print something
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform; //load in the player's transform component
        wasInteracted = false; //reset the interaction check, so that we can interact with the focused object once
    }

    public void OnDeFocused()
    {
        isFocused = false;
        player = null; //clear the transform component
        wasInteracted = false; //reset the interaction check
    }
    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null) interactionTransform = transform; //just to prevent errors from showing in editor

        Gizmos.color = Color.yellow; //set the radius color to yellow
        Gizmos.DrawWireSphere(interactionTransform.position, radius); //draw a wire sphere gizmo around the object
    }
}
