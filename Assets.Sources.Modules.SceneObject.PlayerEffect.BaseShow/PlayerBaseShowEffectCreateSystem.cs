using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.PlayerEffect;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.BaseShow;

public class PlayerBaseShowEffectCreateSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _playerGroup;

	private readonly IBattleRoom _battleRoomAdapter;

	public PlayerBaseShowEffectCreateSystem(Contexts contexts)
	{
		_playerGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
	}

	public void OnEntityCreate()
	{
		int frameCount = Time.frameCount;
		int num = 0;
		foreach (PlayerEntity item in _playerGroup)
		{
			if (item.isCameraOwner || (frameCount - num++) % 10 == 0)
			{
				CreatePlayerEffect(item);
			}
		}
	}

	public void OnPlayback()
	{
		OnEntityCreate();
	}

	private void CreatePlayerEffect(PlayerEntity player)
	{
		if (player.hasPlayerBaseShowRender || player.IsDead())
		{
			return;
		}
		for (int i = 0; i < PlayerEffectInfoFactory.Instance.PlayerEffectInfoShowList.Count; i++)
		{
			IPlayerShowEffectInfo playerShowEffectInfo = PlayerEffectInfoFactory.Instance.PlayerEffectInfoShowList[i];
			if (playerShowEffectInfo.IsEffectOn(player, _battleRoomAdapter))
			{
				Type renderType = playerShowEffectInfo.GetRenderType();
				if (renderType != null)
				{
					IPlayerShowEffectRender playerShowEffectRender = (IPlayerShowEffectRender)Activator.CreateInstance(renderType);
					playerShowEffectRender?.Init(player);
					player.AddPlayerBaseShowRender(playerShowEffectRender);
				}
			}
		}
	}
}
