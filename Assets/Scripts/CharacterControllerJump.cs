using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerJump : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 _moveDirection;
    public float gravityScale;

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, _moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

if (controller.isGrounded) {
        if (Input.GetButtonDown("Jump"))
        {
            _moveDirection.y = jumpForce;
        }
}
        _moveDirection.y = _moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(_moveDirection * Time.deltaTime);
    }
}

