using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 50f;

    private CharacterController characterController;
    private bool isVRActive;
    private InputDevice leftController;
    private InputDevice rightController;

    void Start()
    {
        // Enable VR detection
        isVRActive = XRSettings.enabled;
        characterController = GetComponent<CharacterController>(); // Ensure you have one!

        if (isVRActive)
        {
            // Get VR Controllers
            leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            rightController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        }
    }

    void Update()
    {
        if (isVRActive)
        {
            VRMovement(); // Move using VR controllers
        }
        else
        {
            KeyboardMovement(); // Move using keyboard
        }
    }

    void KeyboardMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D
        float moveVertical = Input.GetAxis("Vertical"); // W/S

        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        characterController.SimpleMove(moveDirection * moveSpeed);

        // Rotate with Mouse
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed * Time.deltaTime);
    }

    void VRMovement()
    {
        Vector2 moveInput;
        Vector2 rotateInput;

        if (leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out moveInput))
        {
            // Move with left joystick
            Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
            moveDirection.y = 0f; // Prevent floating movement
            characterController.SimpleMove(moveDirection * moveSpeed);
        }

        if (rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out rotateInput))
        {
            // Rotate with right joystick
            float turnAmount = rotateInput.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up * turnAmount);
        }
    }
}
