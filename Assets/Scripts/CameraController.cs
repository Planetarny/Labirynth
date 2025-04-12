using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float mouseSensivity = 1f;
    private Transform playerBody;
    float xRotation = 0f;
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;

    }
    private void Update()
    {

        CameraRotation();

    }
    private void CameraRotation()
    {

        float mouseX = Input.GetAxis("Mouse X")*mouseSensivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensivity*Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


    }

}
