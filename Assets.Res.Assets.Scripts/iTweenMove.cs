using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class iTweenMove : MonoBehaviour
{
	public Vector3 Distance;

	public iTween.LoopType LoopType;

	public iTween.EaseType EaseType = iTween.EaseType.linear;

	public float Time;

	public float Delay;

	public bool ResetOnEnable;

	private Vector3 _startPosition;

	private void Awake()
	{
		_startPosition = base.transform.localPosition;
	}

	private void Start()
	{
		if (!ResetOnEnable)
		{
			SetTween();
		}
	}

	private void OnEnable()
	{
		if (ResetOnEnable)
		{
			SetTween();
		}
	}

	private void SetTween()
	{
		base.transform.localPosition = _startPosition;
		iTween.MoveBy(base.gameObject, iTween.Hash("amount", Distance, "time", Time, "looptype", LoopType, "easetype", EaseType, "delay", Delay));
	}
}
