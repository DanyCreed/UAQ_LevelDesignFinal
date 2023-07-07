using UnityEngine;

public class CameraCollisionDetection : MonoBehaviour
{
    public Transform cameraTransform;
    public float collisionRadius = 0.5f;
    public LayerMask collisionLayer;

    private void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        Vector3 cameraPosition = cameraTransform.position;
        Collider[] colliders = Physics.OverlapSphere(cameraPosition, collisionRadius, collisionLayer);

        if (colliders.Length > 0)
        {
            // Colisi�n detectada, realizar acciones necesarias
            Debug.Log("�Colisi�n detectada!");

            // Ejemplo de acci�n: mover la c�mara hacia atr�s para evitar la colisi�n
            Vector3 cameraForward = cameraTransform.forward;
            cameraTransform.position -= cameraForward * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collisionRadius);
    }
}
