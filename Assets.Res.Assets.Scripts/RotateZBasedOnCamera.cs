using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class RotateZBasedOnCamera : MonoBehaviour
{
	private void Update()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.z = Camera.main.transform.eulerAngles.y;
		base.transform.eulerAngles = eulerAngles;
	}
}
