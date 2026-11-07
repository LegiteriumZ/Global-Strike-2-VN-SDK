using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public abstract class IFireEffectControl : MonoBehaviour, IEntitsFireEffectControl
{
	public abstract bool Fire(bool special);

	public abstract void SetRender(bool flag);

	public abstract void SetNoUse();
}
