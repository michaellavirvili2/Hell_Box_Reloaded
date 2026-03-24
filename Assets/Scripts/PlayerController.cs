using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float lookSpeed = 60.0f;

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
       float mouseX = Input.GetAxis("Mouse X")*lookSpeed*Time.deltaTime;
       float mouseY = Input.GetAxis("Mouse Y")*lookSpeed*Time.deltaTime;
       
       transform.Rotate(0.0f, mouseX, 0.0f);
       
       verticalRotation -= mouseY;
       verticalRotation = Mathf.Clamp(verticalRotation, -maxLookAngle, maxLookAngle);
       cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
       
       // float horizontal = Input.GetAxis("Horizontal");
       // float vertical = Input.GetAxis("Vertical");
       //
       // Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;
       // rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
       //
       _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       Debug.Log(_moveInput);
       if (_moveInput == Vector2.zero)
       {
           rb.linearVelocity = Vector3.zero;
           return;
       }
       
      // rb.linearVelocity = (transform.forward * _moveInput.x + transform.right * _moveInput.y).normalized * moveSpeed; 
       _moveInput = Vector2.zero;
       
       
       // Read move & look input
       //   _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       //   _lookInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
       //   
       //   // Consume look input first
       // //transform.Rotate(Vector3.up * _lookInput.x * lookSpeed * Time.deltaTime);
       //   //cameraTransform.Rotate(Vector3.right *( - _lookInput.y) * lookSpeed * Time.deltaTime);
       //   //_lookInput = Vector2.zero;
       //   
       //   // Consume move input afterwards
       
       //   
       //  
    }
}