using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public abstract class AbstractKnifeEffectMb : MonoBehaviour, IKnifeAttackEffectControl
{
	public KnifeAttackConfig config = new KnifeAttackConfig();

	public abstract void Play();

	public abstract bool IsPlay();

	public abstract void Stop();
}
