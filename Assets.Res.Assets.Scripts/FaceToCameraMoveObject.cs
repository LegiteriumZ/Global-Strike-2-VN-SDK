using UnityEngine;

namespace Assets.Res.Assets.Scripts;

internal class FaceToCameraMoveObject : MonoBehaviour
{
	public bool ZReverse;

	private void Update()
	{
		base.transform.LookAt(Camera.main.transform);
	}
}
