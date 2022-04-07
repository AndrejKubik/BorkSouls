using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float zoom = 10f;
    [SerializeField] private float pitch = 2f;
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 15f;
    [SerializeField] private float currentRotation = 0f;
    [SerializeField] private float rotationSpeed = 100f;

    private void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; //change the zoom with the mouse scroll by the chosen zoom speed
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom); //limit the zoom range from min to max zoom values
        currentRotation -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime; //get the rotation value based on the horizontal input value with chosen speed

    }

    private void LateUpdate()
    {
        transform.position = target.position - offset * zoom; //move the camera object to the target with a set offset and zoom
        transform.LookAt(target.position + Vector3.up * pitch); //set a vertical pitch to zooming in and out
        transform.RotateAround(target.position, Vector3.up, currentRotation); //rotate the camera object around it's target's position around the Y-axis by the calculater rotation value

    }
}
