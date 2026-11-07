using UnityEngine;

namespace Assets.Scripts.Utility;

public class FollowTransform2 : MonoBehaviour
{
	public Transform Target;

	public Vector3 Delta;

	private Vector3 posTemp;

	private Quaternion rotTemp;

	public static FollowTransform2 Follow(Transform follower, Transform target)
	{
		FollowTransform2 followTransform = follower.gameObject.GetComponent<FollowTransform2>();
		if (followTransform == null)
		{
			followTransform = follower.gameObject.AddComponent<FollowTransform2>();
		}
		followTransform.Target = target;
		followTransform.enabled = true;
		followTransform.Init();
		followTransform.LateUpdate();
		return followTransform;
	}

	public void Awake()
	{
		posTemp = base.transform.localPosition;
		rotTemp = base.transform.localRotation;
	}

	private void Init()
	{
	}

	private void Start()
	{
		Init();
	}

	private void LateUpdate()
	{
		if (Target != null)
		{
			base.transform.position = Target.position + Delta;
			base.transform.rotation = Target.rotation;
		}
	}

	public void Restore()
	{
		base.transform.localPosition = posTemp;
		base.transform.localRotation = rotTemp;
	}
}
