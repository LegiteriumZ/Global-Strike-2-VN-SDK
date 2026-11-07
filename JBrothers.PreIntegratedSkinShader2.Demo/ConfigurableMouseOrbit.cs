using UnityEngine;

namespace JBrothers.PreIntegratedSkinShader2.Demo;

[AddComponentMenu("Camera-Control/Configurable Mouse Orbit")]
public class ConfigurableMouseOrbit : MonoBehaviour
{
	public enum MouseButton
	{
		None = -1,
		Left = 0,
		Middle = 2,
		Right = 1
	}

	public Transform target;

	public float distance = 3f;

	public float zoomSpeed = 1f;

	public float distanceMin = 0.2f;

	public float distanceMax = 10f;

	public float xSpeed = 250f;

	public float ySpeed = 120f;

	public float yMinLimit;

	public float yMaxLimit = 90f;

	private float x;

	private float y;

	public bool centerToAABB = true;

	public bool ScrollZoom = true;

	public MouseButton mouseButton;

	public bool lockCursor = true;

	private bool CursorLocked
	{
		get
		{
			return Screen.lockCursor;
		}
		set
		{
			Screen.lockCursor = value;
		}
	}

	private void Start()
	{
		if ((bool)target)
		{
			Vector3 eulerAngles = base.transform.eulerAngles;
			x = eulerAngles.y;
			y = eulerAngles.x;
			if ((bool)GetComponent<Rigidbody>())
			{
				GetComponent<Rigidbody>().freezeRotation = true;
			}
		}
	}

	private bool isMouseOverGUI()
	{
		return GUIUtility.hotControl != 0;
	}

	private void Update()
	{
		if (!target)
		{
			return;
		}
		if (mouseButton == MouseButton.None || (Input.GetMouseButton((int)mouseButton) && !isMouseOverGUI()))
		{
			if (!CursorLocked && lockCursor)
			{
				CursorLocked = true;
			}
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		}
		else if (CursorLocked && lockCursor)
		{
			CursorLocked = false;
		}
		if (ScrollZoom)
		{
			float axis = Input.GetAxis("Mouse ScrollWheel");
			if (axis != 0f)
			{
				distance = Mathf.Clamp(distance * (1f - axis * zoomSpeed), distanceMin, distanceMax);
			}
			if (Input.touchCount == 2)
			{
				Touch touch = Input.GetTouch(0);
				Touch touch2 = Input.GetTouch(1);
				Vector2 vector = touch.position - touch.deltaPosition;
				Vector2 vector2 = touch2.position - touch2.deltaPosition;
				float magnitude = (vector - vector2).magnitude;
				float magnitude2 = (touch.position - touch2.position).magnitude;
				float num = magnitude - magnitude2;
				distance = Mathf.Clamp(distance * (1f + num * zoomSpeed * 0.1f), distanceMin, distanceMax);
			}
		}
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		Quaternion quaternion = Quaternion.Euler(y, x, 0f);
		Vector3 localPosition = quaternion * new Vector3(0f, 0f, 0f - distance) + target.position;
		if (centerToAABB && (bool)target.GetComponent<Renderer>())
		{
			localPosition += target.transform.InverseTransformPoint(target.GetComponent<Renderer>().bounds.center);
		}
		base.transform.localRotation = quaternion;
		base.transform.localPosition = localPosition;
	}

	private static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}
}
