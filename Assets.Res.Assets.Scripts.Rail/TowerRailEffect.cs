using UnityEngine;

namespace Assets.Res.Assets.Scripts.Rail;

internal class TowerRailEffect : BaseRailEffect
{
	private Vector3 _forward;

	public float Velocity;

	private Transform _mainTransform;

	private Transform MainCameraTrans
	{
		get
		{
			if (_mainTransform == null)
			{
				_mainTransform = Camera.main.transform;
			}
			return _mainTransform;
		}
	}

	public override void Render()
	{
		UpdateBulletRail(Time.deltaTime);
	}

	protected override void InitIfDataChanged()
	{
		float num = _ParamData.StartOffsetRandom * Random.Range(0f, 1f);
		Vector3 vector = _ParamData.Start + (_ParamData.Start - MainCameraTrans.position).normalized * 1000f;
		Vector3 normalized = (_ParamData.End - vector).normalized;
		Vector3 vector2 = normalized * (_ParamData.StartOffsetBase + num);
		Vector3 vector3 = vector + vector2;
		_ParamData.Start = vector3;
		_forward = normalized;
		base.transform.position = vector3;
		UpdateBulletRail(0f);
	}

	private static Vector3 GetRight(Vector3 forward, Transform pTransform3D)
	{
		float num = Vector3.Dot(forward, -pTransform3D.right);
		float num2 = Vector3.Dot(forward, pTransform3D.forward);
		Vector3 result = default(Vector3);
		result.x = (0f - pTransform3D.right.x) * num2;
		result.y = (0f - pTransform3D.right.y) * num2;
		result.z = (0f - pTransform3D.right.z) * num2;
		result.x -= pTransform3D.forward.x * num;
		result.y -= pTransform3D.forward.y * num;
		result.z -= pTransform3D.forward.z * num;
		result.Normalize();
		return result;
	}

	private void UpdateBulletRail(float dt)
	{
		Vector3 vector = _forward * Velocity * dt * 1000f;
		Vector3 vector2 = base.transform.position + vector;
		if (dt == 0f)
		{
			vector2 += _forward * _ParamData.RailLength;
		}
		Enable = Vector3.Dot(vector2 - _ParamData.End, vector2 - _ParamData.Start) <= 0f;
		Enable = true;
		if (Enable)
		{
			base.transform.position = vector2;
			Vector3 upwards = Vector3.Cross(GetRight(_forward, MainCameraTrans), _forward);
			base.transform.rotation = Quaternion.LookRotation(_forward, upwards);
			SetLength(_ParamData.RailLength + Velocity * 0.9f * dt * 1000f);
		}
		else
		{
			_ParamData.Start = Vector3.zero;
			_ParamData.End = Vector3.zero;
		}
	}
}
