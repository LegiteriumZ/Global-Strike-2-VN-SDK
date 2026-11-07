using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class iTweenAlphaTo : MonoBehaviour
{
	public iTween.LoopType LoopType = iTween.LoopType.pingPong;

	public float Time = 1f;

	public float From = 1f;

	public float To;

	public float Delay;

	public bool ResetOnEnable;

	private void OnEnable()
	{
		if (ResetOnEnable)
		{
			SetTween();
		}
	}

	private void Start()
	{
		if (!ResetOnEnable)
		{
			SetTween();
		}
	}

	private void SetTween()
	{
		iTween.FadeTo(base.gameObject, iTween.Hash("alpha", From, "time", 0, "oncomplete", "OnResetComplete"));
	}

	private void OnResetComplete()
	{
		iTween.FadeTo(base.gameObject, iTween.Hash("alpha", To, "time", Time, "looptype", LoopType, "delay", Delay));
	}
}
