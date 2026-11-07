using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class RotateToCamera : MonoBehaviour
{
	private Renderer _render;

	private Vector3 _scalOriginal;

	public bool KeepSize;

	public Camera Camera;

	private void Awake()
	{
		_render = base.gameObject.GetComponent<Renderer>();
		_scalOriginal = base.transform.localScale;
	}

	private void LateUpdate()
	{
		if (!(Camera.main != null))
		{
			return;
		}
		Camera camera = ((Camera != null) ? Camera : Camera.main);
		Vector3 vector = base.transform.position - camera.transform.position;
		vector.y = 0f;
		if (vector == Vector3.zero)
		{
			vector = camera.transform.forward;
			vector.y = 0f;
		}
		base.transform.rotation = Quaternion.LookRotation(vector);
		if (!FaceToCamera.UpdateKeepSize(KeepSize, _render, _scalOriginal, base.transform))
		{
			RectTransform component = base.transform.GetComponent<RectTransform>();
			if (component != null)
			{
				FaceToCamera.UpdateKeepSize(KeepSize, component, _scalOriginal);
			}
		}
	}
}
