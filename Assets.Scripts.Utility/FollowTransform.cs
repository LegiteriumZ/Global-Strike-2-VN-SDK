using SSJJMath;
using UnityEngine;

namespace Assets.Scripts.Utility;

public class FollowTransform : MonoBehaviour
{
	public Transform Target;

	public bool UseMatrixOnBegin;

	private bool _inited;

	private Vector3 _position;

	private Quaternion _rotation;

	public static void Follow(Transform follower, Transform target, bool useMatrixOnBegin)
	{
		FollowTransform followTransform = follower.gameObject.GetComponent<FollowTransform>();
		if (followTransform == null)
		{
			followTransform = follower.gameObject.AddComponent<FollowTransform>();
		}
		followTransform.Target = target;
		followTransform.UseMatrixOnBegin = useMatrixOnBegin;
		followTransform.Init();
		followTransform.LateUpdate();
	}

	private void Init()
	{
		if (!_inited)
		{
			_position = base.transform.localPosition;
			_rotation = base.transform.localRotation;
			_inited = true;
		}
	}

	private void Start()
	{
		Init();
	}

	private void LateUpdate()
	{
		if (Target != null)
		{
			Vector3 pos;
			Quaternion q;
			if (UseMatrixOnBegin)
			{
				pos = _position;
				q = _rotation;
			}
			else
			{
				pos = base.transform.localPosition;
				q = base.transform.localRotation;
			}
			Matrix4x4 matrix = Target.localToWorldMatrix * Matrix4x4.TRS(pos, q, Vector3.one);
			base.transform.localScale = matrix.ExtractScale();
			base.transform.rotation = matrix.ExtractRotation();
			base.transform.position = matrix.ExtractPosition();
		}
	}
}
