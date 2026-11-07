using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Tests;

public class LogTransform : MonoBehaviour
{
	private Vector3 LastPosition;

	private void LateUpdate()
	{
		float magnitude = (base.transform.position - LastPosition).magnitude;
		if (magnitude > 0f)
		{
			Vector3 normalized = (base.transform.position - LastPosition).normalized;
			this.DebugFormat("{0} Position {1} Rotation {2} Dir {3} lenght {4}", base.transform.name, base.transform.position, base.transform.rotation, normalized, magnitude);
		}
		LastPosition = base.transform.position;
	}
}
