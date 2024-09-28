using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 10f;
    [SerializeField]
    private float runSpeed = 15f;
    [SerializeField]
    private float jumpHeight = 1f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 10f;
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Vector3 movementOffset = Vector3.zero;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Animator anim;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction runAction;
    private InputAction jumpAction;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();

        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        runAction = playerInput.actions["Run"];
        jumpAction = playerInput.actions["Jump"];
    }

    private void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        if (move != Vector3.zero)
        {
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0f;

            move += movementOffset;

            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
        float currentSpeed = runAction.ReadValue<float>() > 0 ? runSpeed : walkSpeed;
        controller.Move(move * Time.deltaTime * currentSpeed);

        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        Vector2 lookInput = lookAction.ReadValue<Vector2>();    
        cameraTransform.Rotate(Vector3.right, -lookInput.y * Time.deltaTime * 100f);


        anim.SetFloat("Speed", move.magnitude * (currentSpeed == runSpeed ? 2f : 1f));
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus) 
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;

        }
    }
}
