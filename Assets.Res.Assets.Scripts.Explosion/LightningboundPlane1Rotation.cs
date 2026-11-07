using UnityEngine;

namespace Assets.Res.Assets.Scripts.Explosion;

public class LightningboundPlane1Rotation : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		base.transform.rotation = Quaternion.LookRotation(new Vector3(0f, 1f, 0f), -Camera.main.transform.forward);
	}
}
