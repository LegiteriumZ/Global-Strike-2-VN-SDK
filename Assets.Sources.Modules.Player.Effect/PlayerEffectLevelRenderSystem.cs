using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerEffectLevelRenderSystem : IRenderSystem
{
	private readonly IGroup<PlayerEntity> _thirdGroup;

	private readonly IGroup<PlayerEntity> _firstGroup;

	public PlayerEffectLevelRenderSystem(Contexts contexts)
	{
		_thirdGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_firstGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.FirstPersonUnityObjects));
	}

	private void CommonParticleEffect(PlayerEntity entity, IPaticlePrefabInstancecs particle, bool inScreen)
	{
		bool flag = particle.getPlayerInfoEffectConfig().IsEffect();
		bool flag2 = true;
		if (flag)
		{
			if (entity.HasStatus(particle.getPlayerInfoEffectConfig().getStatusId()) && !particle.getPlayerInfoEffectConfig().getVisiable())
			{
				flag2 = false;
			}
			else if (!entity.HasStatus(particle.getPlayerInfoEffectConfig().getStatusId()) && particle.getPlayerInfoEffectConfig().getVisiable())
			{
				flag2 = false;
			}
		}
		if (particle.getVisibleState() == 0)
		{
			if (flag)
			{
				particle.SetInsActive(flag2 && inScreen);
			}
			else
			{
				particle.SetInsActive(inScreen);
			}
		}
		else
		{
			particle.SetInsActive(inScreen && flag2 && (entity.basicInfo.Current.CurrentWeaponEffectLevel & (1 << (int)(particle.getVisibleState() - 1))) > 0);
		}
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _firstGroup)
		{
			foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> handPatricle in item.firstPersonUnityObjects.HandPatricles)
			{
				CommonParticleEffect(item, handPatricle.Value, inScreen: true);
			}
		}
		foreach (PlayerEntity item2 in _thirdGroup)
		{
			foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> playerParticle in item2.thirdPersonUnityObjects.PlayerParticles)
			{
				bool inScreen = !item2.hasVisiable || item2.visiable.IsVisiable || item2.visiable.IsNear;
				CommonParticleEffect(item2, playerParticle.Value, inScreen);
			}
		}
	}
}
