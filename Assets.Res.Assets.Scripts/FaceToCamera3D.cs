using UnityEngine;

namespace Assets.Res.Assets.Scripts;

internal class FaceToCamera3D : MonoBehaviour
{
	public bool ZReverse;

	private void Update()
	{
		if (Camera.main != null)
		{
			if (ZReverse)
			{
				base.transform.LookAt(Camera.main.transform);
			}
			else
			{
				base.transform.forward = (base.transform.position - Camera.main.transform.position).normalized;
			}
		}
	}
}
