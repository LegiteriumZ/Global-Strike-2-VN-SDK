using UnityEngine;

public class RamdonMeshEffect : MonoBehaviour
{
	public enum AxisType
	{
		X,
		Y,
		Z
	}

	public float FrameTime = 0.02f;

	public AxisType Axis;

	public float ChangeTime;

	private void Update()
	{
		if (ChangeTime <= 0f)
		{
			ChangeTime = FrameTime;
			Vector3 localEulerAngles = base.transform.localEulerAngles;
			if (Axis == AxisType.Z)
			{
				localEulerAngles.z = Random.Range(0, 180);
			}
			if (Axis == AxisType.Y)
			{
				localEulerAngles.y = Random.Range(0, 180);
			}
			if (Axis == AxisType.X)
			{
				localEulerAngles.x = Random.Range(0, 180);
			}
			base.transform.localEulerAngles = localEulerAngles;
		}
		ChangeTime -= Time.deltaTime;
	}
}
