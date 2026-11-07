using UnityEngine;

public class RotateWithEye : MonoBehaviour
{
	private void Update()
	{
		WorldCameraContext worldCamera = Contexts.sharedInstance.worldCamera;
		if (worldCamera != null && worldCamera.hasUnityObjects && worldCamera.unityObjects.nodeEye != null)
		{
			base.transform.rotation = worldCamera.unityObjects.nodeEye.transform.rotation;
		}
	}
}
