using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float lookSpeed = 60.0f;
    [SerializeField] private float maxSpeed = 10.0f;

    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private float verticalRotation = 0;
    private float maxLookAngle = 80.0f;
    

    private void Start()
    {
        // Reset move input
        _moveInput = Vector2.zero;
        _lookInput = Vector2.zero;
    }

    private void Update()
    {
       float mouseX = ( Input.GetAxis("Mouse X")*lookSpeed)*Time.deltaTime;
       float mouseY = (Input.GetAxis("Mouse Y")*lookSpeed)*Time.deltaTime;
       
       transform.Rotate(0.0f, mouseX, 0.0f);
       
       verticalRotation -= mouseY;
       verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);
       cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
       
       _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       
       if (_moveInput == Vector2.zero)
       {
           rb.linearVelocity = Vector3.zero;
           return;
       }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity = ((transform.forward * _moveInput.y) + (transform.right * _moveInput.x)).normalized;
        rb.AddForce(velocity * moveSpeed, ForceMode.Force);
        
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        _moveInput = Vector2.zero;
    }
}

