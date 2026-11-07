using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class iTweenColorTo : MonoBehaviour
{
	public iTween.LoopType LoopType = iTween.LoopType.pingPong;

	public float Time = 1f;

	public Color To = Color.white;

	private void Start()
	{
		iTween.ColorTo(base.gameObject, iTween.Hash("color", To, "time", Time, "looptype", LoopType));
	}
}
