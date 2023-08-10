using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Vector3 _pivot;


    [SerializeField]
    private float cameraSpeed = 5f; // Camera movement speed
    [SerializeField]
    private float rotationSpeed = 3f; // Camera rotation speed
    private Vector3 offset; // Offset between camera and player

    void Start()
    {
        offset = transform.position - _target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = _target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
