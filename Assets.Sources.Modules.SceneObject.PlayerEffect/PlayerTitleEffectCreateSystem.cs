using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Entitas;
using SSJJAsset.Asset;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect;

public class PlayerTitleEffectCreateSystem : IEntityCreateSystem
{
	private readonly IGroup<PlayerEntity> _playerGroup;

	private readonly SceneObjectContext _sceneObjectContext;

	private readonly BattleRoomContext _battleRoomContext;

	private readonly IBattleRoom _battleRoomAdapter;

	private GameRuleContext _gameRuleContext;

	public PlayerTitleEffectCreateSystem(Contexts contexts)
	{
		_playerGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects));
		_sceneObjectContext = contexts.sceneObject;
		_battleRoomContext = contexts.battleRoom;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_gameRuleContext = contexts.gameRule;
	}

	public void OnEntityCreate()
	{
		if (!Contexts.sharedInstance.player.isMyPlayer)
		{
			return;
		}
		int frameCount = Time.frameCount;
		int num = 0;
		foreach (PlayerEntity item in _playerGroup)
		{
			if ((!item.isCameraOwner || (frameCount - num++) % 10 == 0) && IsSuggestTitle(item))
			{
				CreatePlayerEffect(item);
			}
		}
	}

	public bool IsSuggestTitle(PlayerEntity playerEntity)
	{
		if (playerEntity.GetStealthAlpha() <= 0.8f)
		{
			return false;
		}
		if (playerEntity.IsDead())
		{
			return false;
		}
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.PLAYER_USING_CHEATING_FLAG.ID))
		{
			return false;
		}
		if (playerEntity.basicInfo.Current.TitleId <= 0 && playerEntity.hasHonorary)
		{
			return false;
		}
		if (!_gameRuleContext.currentRule.Rule.IsGeneralPve() && playerEntity.hasHonorary && playerEntity.honorary.NumHonorary > 0 && (!RuleUtilty.IsTurnBasedModel(_battleRoomContext.roomData.Data.RaceType) || _battleRoomContext.roomData.Data.SectionTime - _battleRoomContext.sectionTime.SectionTime > 5000))
		{
			return false;
		}
		Vector3 uiMyPlayer_Position = UiIEventCondition.Get_uiMyPlayer_Position();
		float num = uiMyPlayer_Position.x - playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).x;
		float num2 = uiMyPlayer_Position.y - playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).y;
		float num3 = uiMyPlayer_Position.z - playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()).z;
		if (num * num + num2 * num2 + num3 * num3 > 100000000f)
		{
			return false;
		}
		playerEntity.IsBot();
		if (2 == GameSetting.Config.SuggestFlag)
		{
			return false;
		}
		return UiIEventCondition.Get_uiMyPlayer_Team() == playerEntity.GetTeam();
	}

	private void CreatePlayerEffect(PlayerEntity player)
	{
		PlayerTitleEffectData titleEffectData = ParticleManager.Instance().GetTitleEffectData(player.basicInfo.Current.TitleId);
		if (titleEffectData != null)
		{
			string name = titleEffectData.GetName();
			EntityEffectId entityEffectId = new EntityEffectId(player.entityId.Value, name);
			if (_sceneObjectContext.GetEntityWithPlayerEffectId(entityEffectId) == null)
			{
				SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
				sceneObjectEntity.AddPlayerEffectId(entityEffectId);
				sceneObjectEntity.AddPosition(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()));
				sceneObjectEntity.AddScale(Vector3.one);
				sceneObjectEntity.AddPlayerTitleEffect(player.entityId.Value, player.basicInfo.Current.TitleId, titleEffectData.viewHeightTop);
				sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(titleEffectData.AssetInfo), entityEffectId);
			}
		}
	}
}
