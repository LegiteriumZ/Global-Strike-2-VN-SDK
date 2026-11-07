using Assets.Sources.Components.Interface.Info.AnimData;
using SSJJAnim.Animator;

namespace Assets.Scripts.Asset;

public class FirstPersonWeapon : WeaponGameObject
{
	public ISjAnimatior Animator;

	public override void OnCreated()
	{
		base.OnCreated();
		Animator = GetGameObject().AddComponent<SJAnimator>();
		Animator.AddLayer(0, 1f);
	}

	public override void OnRecycle()
	{
		base.OnRecycle();
	}
}
