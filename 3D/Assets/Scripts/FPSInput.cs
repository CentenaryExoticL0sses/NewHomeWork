using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float Speed = 6.0f;

    public float Gravity = -9.8f;

    private CharacterController _charController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = Input.GetAxis("Vertical") * Speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, Speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        movement.y = Gravity;

        _charController.Move(movement);
    }
}
