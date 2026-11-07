using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.UnityObjects;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render.ViewRender;

public class PlayerHeroSangZhongViewRender : AbstractPlayerViewShowEffectRender
{
	public override void Init(PlayerEntity player)
	{
	}

	public override void Render(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		foreach (KeyValuePair<ParticleKey, PaticlePrefabInstancecs> particle in GetParticles(targetPlayer.firstPersonUnityObjects.HandGameObject))
		{
			if (particle.Key.JointName.Equals("player_particle_effect2"))
			{
				if (targetPlayer.viewAnim.ViewAnimInfo.StateId == 28)
				{
					particle.Value.SetInsActive(flag: true);
				}
				else
				{
					particle.Value.SetInsActive(flag: false);
				}
			}
			if (particle.Key.JointName.Equals("player_particle_effect1"))
			{
				if (targetPlayer.GetCurrentWeaponEffectLevel() > 0)
				{
					particle.Value.SetInsActive(flag: true);
				}
				else
				{
					particle.Value.SetInsActive(flag: false);
				}
			}
		}
	}
}
