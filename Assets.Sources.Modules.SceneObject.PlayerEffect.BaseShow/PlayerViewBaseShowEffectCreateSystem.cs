using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.PlayerEffect;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.BaseShow;

public class PlayerViewBaseShowEffectCreateSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _playerGroup;

	private readonly IBattleRoom _battleRoomAdapter;

	public PlayerViewBaseShowEffectCreateSystem(Contexts contexts)
	{
		_playerGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.FirstPersonUnityObjects));
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
		if (player.hasPlayerViewBaseShowRender || player.IsDead())
		{
			return;
		}
		for (int i = 0; i < PlayerEffectInfoFactory.Instance.PlayerEffectInfoViewShowList.Count; i++)
		{
			IPlayerViewShowEffectInfo playerViewShowEffectInfo = PlayerEffectInfoFactory.Instance.PlayerEffectInfoViewShowList[i];
			if (playerViewShowEffectInfo.IsEffectOn(player, _battleRoomAdapter))
			{
				Type renderType = playerViewShowEffectInfo.GetRenderType();
				if (renderType != null)
				{
					IPlayerViewShowEffectRender playerViewShowEffectRender = (IPlayerViewShowEffectRender)Activator.CreateInstance(renderType);
					playerViewShowEffectRender?.Init(player);
					player.AddPlayerViewBaseShowRender(playerViewShowEffectRender);
				}
			}
		}
	}
}
