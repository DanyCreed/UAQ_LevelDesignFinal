using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    public float sensitivity = 10f; // Sensibilidad
    private float currentX = 0f;
    private float currentY = 0f;
    public float movementSpeed = 0.2f; // Movimiento

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //ocultar mouse
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; //eje x
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; // eje y

        currentX += mouseX;
        currentY += mouseY;
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        transform.rotation = rotation;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * movementSpeed * Time.deltaTime;

        movement = transform.TransformDirection(movement);
        movement.y = 0f;

        transform.position += movement;
    }
}
