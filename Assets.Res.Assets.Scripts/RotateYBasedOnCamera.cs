using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class RotateYBasedOnCamera : MonoBehaviour
{
	private void Update()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		eulerAngles.y = Camera.main.transform.eulerAngles.y;
		base.transform.eulerAngles = eulerAngles;
	}
}
