using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class LookToCamera : MonoBehaviour
{
	private Renderer _render;

	private Vector3 _scalOriginal;

	public bool KeepSize;

	public Camera Camera;

	public bool RectKeepSize = true;

	public bool IsYAxis;

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
		if (IsYAxis)
		{
			base.transform.rotation = Quaternion.LookRotation((Camera != null) ? Camera.transform.up : Camera.main.transform.up);
		}
		else
		{
			base.transform.rotation = Quaternion.LookRotation((Camera != null) ? Camera.transform.forward : Camera.main.transform.forward);
		}
		if (!FaceToCamera.UpdateKeepSize(KeepSize, _render, _scalOriginal, base.transform))
		{
			RectTransform component = base.transform.GetComponent<RectTransform>();
			if (component != null && RectKeepSize)
			{
				FaceToCamera.UpdateKeepSize(KeepSize, component, _scalOriginal);
			}
		}
	}
}
