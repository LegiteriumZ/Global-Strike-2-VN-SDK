using UnityEngine;

namespace Assets.Scripts.Utility;

public class FollowTransform3 : MonoBehaviour
{
	public Transform Target;

	public Vector3 PosDelta;

	public Vector3 AngleDelta;

	public static FollowTransform3 Follow(Transform follower, Transform target)
	{
		FollowTransform3 followTransform = follower.gameObject.GetComponent<FollowTransform3>();
		if (followTransform == null)
		{
			followTransform = follower.gameObject.AddComponent<FollowTransform3>();
		}
		followTransform.Target = target;
		followTransform.Init();
		followTransform.LateUpdate();
		return followTransform;
	}

	private void Init()
	{
		PosDelta = base.transform.position - Target.position;
		AngleDelta = base.transform.eulerAngles - Target.eulerAngles;
	}

	private void Start()
	{
		Init();
	}

	private void LateUpdate()
	{
		if (Target != null)
		{
			base.transform.position = Target.position + PosDelta;
			base.transform.eulerAngles = Target.eulerAngles + AngleDelta;
		}
	}
}
