using UnityEngine;

namespace SSJJ.Render;

public class BillBoardToCamera : MonoBehaviour
{
	private void Update()
	{
		if (Camera.main != null)
		{
			base.transform.LookAt(Camera.main.transform);
		}
	}
}
