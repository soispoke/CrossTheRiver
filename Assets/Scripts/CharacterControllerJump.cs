using UnityEngine;

public class CharacterControllerJump : MonoBehaviour
{
    enum ButtonState { Released, Held };

    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float jumpTimer = 0.2f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController player;
    float jumpElapsedTime;
    ButtonState previousButtonState;

    public bool CanJump
    {
        get
        {
            return player.isGrounded && previousButtonState == ButtonState.Released;
        }
    }

    public bool CanContinueJump
    {
        get
        {
            return jumpElapsedTime <= jumpTimer && player.isGrounded == false;
        }
    }
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        // If grounded, we set our jump elapsed to zero
        if (player.isGrounded) jumpElapsedTime = 0f;

        bool jumpButtonPressed = Input.GetKey(KeyCode.J);
        if (jumpButtonPressed)
        {
            if (CanJump || CanContinueJump)
            {
                moveDirection.y = jumpSpeed;
                jumpElapsedTime += Time.deltaTime;
            }
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        player.Move(moveDirection * Time.deltaTime);

        // We don't need this if the user is allowed to hold and keep jumping
        // Most games don't do this, so we have a button state and the user has to hit jump again on landing
        // previousButtonState = jumpButtonPressed ? ButtonState.Held : ButtonState.Released;
    }
}