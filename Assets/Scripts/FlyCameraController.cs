using UnityEngine;
using UnityEngine.InputSystem;

public class FlyCameraController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float fastMoveMultiplier = 2f;

    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 0.1f;

    [SerializeField] private WindPanelToggle panelToggle;

    private PlayerInputActions inputActions;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private float rotationX;
    private float rotationY;

    private void Awake() =>inputActions = new PlayerInputActions();

    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 currentRotation = transform.eulerAngles;

        rotationX = currentRotation.y;
        rotationY = currentRotation.x;
    }

    private void Update()
    {
        if (panelToggle.IsPanelOpen)
            return;

        ReadInput();
        HandleMouseLook();
        HandleMovement();

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void ReadInput()
    {
        moveInput = inputActions.Camera.Move.ReadValue<Vector2>();
        lookInput = inputActions.Camera.Look.ReadValue<Vector2>();
    }

    private void HandleMouseLook()
    {
        rotationX += lookInput.x * mouseSensitivity;
        rotationY -= lookInput.y * mouseSensitivity;

        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0f);
    }

    private void HandleMovement()
    {
        float currentSpeed = moveSpeed;

        if (inputActions.Camera.FastMove.IsPressed())
            currentSpeed *= fastMoveMultiplier;

        Vector3 moveDirection = Vector3.zero;

        moveDirection += transform.forward * moveInput.y;
        moveDirection += transform.right * moveInput.x;

        if (inputActions.Camera.MoveUp.IsPressed())
            moveDirection += Vector3.up;

        if (inputActions.Camera.MoveDown.IsPressed())
            moveDirection += Vector3.down;

        transform.position += moveDirection * currentSpeed * Time.deltaTime;
    }
}