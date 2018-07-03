using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private const float y_angle_min = 0f;
    private const float y_angle_max = 60f;

    public Transform target;
    public Transform camTransform;
    public float distance = 10f;

    private float currentX = 50f;
    private float currentY = 11f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
		if (Input.GetKey("mouse 0"))
		{
			currentX += Input.GetAxis("Mouse X");
			currentY += Input.GetAxis("Mouse Y");

			currentY = Mathf.Clamp(currentY, y_angle_min, y_angle_max);
		}
    }

    private void LateUpdate()
    {
		Vector3 dir = new Vector3(0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
		camTransform.position = target.position + rotation * dir;
		camTransform.LookAt(target.position);
    }
}
