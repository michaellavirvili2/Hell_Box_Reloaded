using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float lookSpeed = 60.0f;

    private Vector2 _moveInput = Vector2.zero;
    private Vector2 _lookInput = Vector2.zero;

    private void Start()
    {
        // Reset move input
        _moveInput = Vector2.zero;
        _lookInput = Vector2.zero;
    }

    private void Update()
    {
        // Reed move & look input
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _lookInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        
        // Consume look input first
        transform.Rotate(Vector3.up * _lookInput.x * lookSpeed * Time.deltaTime);
        cameraTransform.Rotate(Vector3.right *- _lookInput.y * lookSpeed * Time.deltaTime);
        _lookInput = Vector2.zero;
        
        // Consume move input afterwards
        if (_moveInput == Vector2.zero)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }
        
        rb.linearVelocity = (transform.forward * _moveInput.y + transform.right * _moveInput.x).normalized * moveSpeed;
        _moveInput = Vector2.zero;
    }
}