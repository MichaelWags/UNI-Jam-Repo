using UnityEngine;
using UnityEngine.InputSystem;

public class BoulderControls : MonoBehaviour
{
   
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float torqueStrength = 20f;

    private Rigidbody rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        moveInput = moveAction.action.ReadValue<Vector2>();
    }

    //Move boulder lives in fixed update, so everything in Moveboulder will be effected by time.delta time. This should let us set timescale and get slowmo movement.
    private void FixedUpdate()
    {
        MoveBoulder();
    }

    private void MoveBoulder()
    {
        if (cameraTransform == null)
            return;

        // Get the direction the camera faces.
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        // Remove the camera's vertical angle.
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // Convert WASD input into camera-relative movement.
        Vector3 moveDirection =cameraForward * moveInput.y + cameraRight * moveInput.x;

        if (moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // Torque must be perpendicular to the desired movement.
        Vector3 torqueDirection = Vector3.Cross(Vector3.up, moveDirection);

        rb.AddTorque(torqueDirection * torqueStrength, ForceMode.Acceleration);
    }
}
