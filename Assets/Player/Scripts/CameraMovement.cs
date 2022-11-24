using UnityEngine;

public class CameraMovement : MonoBehaviour {

    GameObject gameManager;

    [SerializeField] float xClamp = 85f;
    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = 0.5f;
    float mouseX, mouseY;
    float xRotation = 0f;

    [SerializeField] Transform playerCamera;

    void Start() {
        gameManager = GameObject.FindWithTag("GameManager");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    public void ReceiveInput(Vector2 mouseInput) {
        if(gameManager.GetComponent<PauseMenu>().isPaused == false) {
            mouseX = mouseInput.x * sensitivityX;
            mouseY = mouseInput.y * sensitivityY;
        } else if(gameManager.GetComponent<PauseMenu>().isPaused == true) {
            mouseX = 0f;
            mouseY = 0f;
        }
    }

}
