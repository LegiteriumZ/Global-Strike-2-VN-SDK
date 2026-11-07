using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class SpineMono : MonoBehaviour
{
	private float _lastUpdate;

	public Vector3 SpeedInAngle;

	private void Awake()
	{
		_lastUpdate = Time.realtimeSinceStartup;
	}

	private void Update()
	{
		Vector3 localEulerAngles = base.transform.localEulerAngles;
		localEulerAngles += SpeedInAngle * (Time.realtimeSinceStartup - _lastUpdate);
		_lastUpdate = Time.realtimeSinceStartup;
		base.transform.localEulerAngles = localEulerAngles;
	}
}
