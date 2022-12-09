using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float smoothTime = 0.1f;
    float smoothVelocity;
    public static Vector3 direction;
    Vector3 velocity;
    public float gravity = -9.81f;
    PlayerManager playerManager;

    public void Start()
    {
        playerManager = GetComponent<PlayerManager>();
    }
    //manage gravety
    public void HandleGravety(float delta)
    {
        playerManager.grounded = controller.isGrounded;
        if (playerManager.grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (!playerManager.grounded)
        {
            velocity.y += gravity * delta;
            controller.Move(velocity * delta);
        }
    }

    //manage gravety
    public void HandleMovement(float delta)
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //smooth the angle transition
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection.y = velocity.y;
            controller.Move(moveDirection.normalized * playerManager.speed * delta);

        }
    }
}
