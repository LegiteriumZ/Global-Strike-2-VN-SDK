using UnityEngine;

namespace Assets.Sources.Utils.Uf3d;

public class StaticBillboard : MonoBehaviour
{
	private void OnWillRenderObject()
	{
		if (!(Camera.main == null))
		{
			base.transform.LookAt(base.transform.position + Camera.main.transform.forward, Camera.main.transform.up);
			Vector3 eulerAngles = base.transform.eulerAngles;
			eulerAngles.x = 90f;
			base.transform.eulerAngles = eulerAngles;
		}
	}
}
