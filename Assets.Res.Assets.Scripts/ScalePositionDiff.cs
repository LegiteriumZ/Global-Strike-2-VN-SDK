using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class ScalePositionDiff : MonoBehaviour
{
	public enum AXIS
	{
		X,
		Y,
		Z
	}

	public float Scale;

	public float StartPosition;

	public AXIS Axis;

	private Transform _tran;

	private void Awake()
	{
		_tran = base.transform;
	}

	private void LateUpdate()
	{
		Vector3 localPosition = _tran.localPosition;
		if (Axis == AXIS.X)
		{
			localPosition.x = StartPosition + _tran.localScale.x * Scale;
		}
		else if (Axis == AXIS.Y)
		{
			localPosition.y = StartPosition + _tran.localScale.y * Scale;
		}
		else if (Axis == AXIS.Z)
		{
			localPosition.z = StartPosition + _tran.localScale.z * Scale;
		}
		_tran.localPosition = localPosition;
	}
}
