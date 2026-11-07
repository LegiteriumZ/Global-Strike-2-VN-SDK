using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson.TPS;

public class PlayerDyBoneSystem : IAfterPredicationSystem
{
	private PlayerContext _playerContext;

	private IGroup<PlayerEntity> _group;

	public PlayerDyBoneSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
	}

	public void OnAfterPredication()
	{
		foreach (PlayerEntity item in _group)
		{
			IDynamicBoneSsjj[] dynamicBones = item.thirdPersonUnityObjects.DynamicBones;
			bool flag = !item.hasVisiable || item.visiable.IsVisiable;
			if (dynamicBones == null)
			{
				continue;
			}
			IDynamicBoneSsjj[] array = dynamicBones;
			foreach (IDynamicBoneSsjj dynamicBoneSsjj in array)
			{
				if (flag)
				{
					dynamicBoneSsjj.BeforeUpdate();
					dynamicBoneSsjj.AfterUpdate();
				}
			}
		}
	}
}
