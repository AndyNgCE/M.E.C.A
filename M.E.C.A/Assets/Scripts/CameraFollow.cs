using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 cameraOffset;

    public float smoothSpeed = 0.125f;

    void Start()
    {
        cameraOffset = transform.position - PlayerTransform.position;
    }

    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothSpeed);

    }
}
