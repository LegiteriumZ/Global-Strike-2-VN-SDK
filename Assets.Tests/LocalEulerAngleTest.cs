using UnityEngine;

namespace Assets.Tests;

public class LocalEulerAngleTest : MonoBehaviour
{
	public Vector3 localEulerAngles;

	private void Update()
	{
		base.transform.localEulerAngles = localEulerAngles;
	}
}
