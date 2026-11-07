using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class PositionInteger : MonoBehaviour
{
	private void LateUpdate()
	{
		Vector3 vector = new Vector3((int)base.transform.position.x, (int)base.transform.position.y, (int)base.transform.position.z);
		if (base.transform.position != vector)
		{
			base.transform.position = vector;
		}
	}
}
