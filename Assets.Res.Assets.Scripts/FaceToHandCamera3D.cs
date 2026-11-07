using UnityEngine;

namespace Assets.Res.Assets.Scripts;

internal class FaceToHandCamera3D : MonoBehaviour
{
	public bool ZReverse;

	private void Update()
	{
		Camera[] allCameras = Camera.allCameras;
		foreach (Camera camera in allCameras)
		{
			if (camera.gameObject.tag.Equals("HandCamera") && Camera.main != null)
			{
				if (ZReverse)
				{
					base.transform.LookAt(camera.transform);
				}
				else
				{
					base.transform.forward = (base.transform.position - camera.transform.position).normalized;
				}
			}
		}
	}
}
