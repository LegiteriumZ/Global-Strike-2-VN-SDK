using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class iTweenScaleTo : MonoBehaviour
{
	public Vector3 To;

	public iTween.LoopType LoopType;

	public iTween.EaseType EaseType = iTween.EaseType.linear;

	public float Time;

	public float Delay;

	public bool ResetOnEnable;

	private Vector3 _startScale;

	private void Awake()
	{
		_startScale = base.transform.localScale;
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
		base.transform.localScale = _startScale;
		iTween.ScaleTo(base.gameObject, iTween.Hash("scale", To, "time", Time, "looptype", LoopType, "easetype", EaseType, "delay", Delay));
	}
}
