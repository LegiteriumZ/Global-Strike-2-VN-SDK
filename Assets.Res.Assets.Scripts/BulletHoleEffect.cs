using UnityEngine;
using share.constant;

namespace Assets.Res.Assets.Scripts;

public class BulletHoleEffect : MonoBehaviour
{
	public Transform FireTransform;

	public ParticleSystem KeliParticleSystem;

	public GameObject HuoXingParticleSystem;

	public GameObject YanParticleSystem;

	public Transform HoleTransform;

	public float FireScaleDisatance = 200f;

	private float _startTime;

	private void OnEnable()
	{
		_startTime = Time.realtimeSinceStartup;
	}

	private void LateUpdate()
	{
		UpdateScaleAndOrientatio();
	}

	public void UpdateScaleAndOrientatio()
	{
		if (Camera.main == null)
		{
			return;
		}
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return;
		}
		float num = 1f;
		Vector3 a = Camera.main.transform.position + new Vector3(0f, PlayerConf.ColliderZ() * 2 - 10, 0f);
		a.y += PlayerConf.ColliderZ() * 2 - 10;
		float num2 = Vector3.Distance(a, FireTransform.position);
		float num3 = Mathf.Abs(a.y - HoleTransform.position.y);
		float num4 = num2 - FireScaleDisatance;
		if (num4 > 0f)
		{
			num += 0.25f / FireScaleDisatance * num4;
		}
		if (num3 <= 60f)
		{
			HoleTransform.gameObject.SetObjectActive(isactive: true);
		}
		else
		{
			float f = Vector3.Dot(HoleTransform.forward.normalized, Camera.main.transform.forward);
			bool flag = myPlayerEntity.hasFov && myPlayerEntity.fov.IsZoom();
			HoleTransform.gameObject.SetObjectActive(!(Mathf.Abs(f) <= 0.4f) || !(num2 >= 2200f) || !flag);
		}
		bool flag2 = Time.realtimeSinceStartup - _startTime < 0.05f;
		if (FireTransform.gameObject.IsActiveSelf() != flag2)
		{
			FireTransform.gameObject.SetObjectActive(flag2);
			FireTransform.localScale = Vector3.one * num;
			FireTransform.LookAt(Camera.main.transform, Vector3.right);
		}
		flag2 = Time.realtimeSinceStartup - _startTime < 0.8f;
		if (KeliParticleSystem.gameObject.IsActiveSelf() != flag2)
		{
			KeliParticleSystem.gameObject.SetObjectActive(flag2);
			if (flag2)
			{
				ParticleSystem.MainModule main = KeliParticleSystem.main;
				main.startSizeMultiplier = num * 1.2f;
			}
		}
		if (HuoXingParticleSystem.IsActiveSelf() != flag2)
		{
			HuoXingParticleSystem.SetObjectActive(flag2);
		}
		if (YanParticleSystem.IsActiveSelf() != flag2)
		{
			YanParticleSystem.SetObjectActive(flag2);
		}
	}
}
