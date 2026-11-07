using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class iTweenRotate : MonoBehaviour
{
	public Vector3 Distance;

	public iTween.EaseType EaseType;

	public iTween.LoopType LoopType;

	public float Time;

	private void Start()
	{
		iTween.RotateBy(base.gameObject, iTween.Hash("amount", Distance, "time", Time, "looptype", LoopType, "easetype", EaseType));
	}
}
