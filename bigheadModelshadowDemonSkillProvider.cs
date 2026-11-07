using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using SSJJMath;
using share.constant;

public class bigheadModelshadowDemonSkillProvider : IbigheadModelshadowDemonSkillProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	public bigheadModelshadowDemonSkillProvider(Contexts contexts)
	{
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool isShow()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null && (myPlayerEntity.GetCareer().Equals("shadow_demon") || myPlayerEntity.GetCareer().Equals("shadow_demon_scar")))
		{
			return true;
		}
		return false;
	}

	public bool isShowEffect(int index)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null && myPlayerEntity.hasClientTime && myPlayerEntity.hasSkill)
		{
			int nextSkill = GetNextSkill(myPlayerEntity, GetPlayerStatusId(index));
			if (myPlayerEntity.GetClientTime() < nextSkill)
			{
				return false;
			}
			if (myPlayerEntity.GetClientTime() - 166 > nextSkill)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public string getEffectUrl(int index)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		int nextSkill = GetNextSkill(myPlayerEntity, GetPlayerStatusId(index));
		int intervalTimer = myPlayerEntity.GetClientTime() - nextSkill;
		int textureIndex = FlashMaths.GetTextureIndex(1, 4, 41.5f, intervalTimer, repeat: false);
		return $"/ui/GameGUIRes/halfLoadedRes/shadowDemonSkill/effect{textureIndex}";
	}

	public bool isShowMask(int index)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		int nextSkill = GetNextSkill(myPlayerEntity, GetPlayerStatusId(index));
		if (index == 1)
		{
			return GetNextSkill(myPlayerEntity, PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_5.ID) == 0;
		}
		return myPlayerEntity.GetClientTime() < nextSkill;
	}

	public float getMaskProgress(int index)
	{
		if (index == 1)
		{
			return 1f;
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		int nextSkill = GetNextSkill(myPlayerEntity, GetPlayerStatusId(index));
		float nextSkillMaxTime = GetNextSkillMaxTime(myPlayerEntity, GetPlayerStatusId(index));
		return (float)(nextSkill - myPlayerEntity.GetClientTime()) / nextSkillMaxTime;
	}

	public bool isShowTime(int index)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		int nextSkill = GetNextSkill(myPlayerEntity, GetPlayerStatusId(index));
		return myPlayerEntity.GetClientTime() < nextSkill;
	}

	public float getTime(int index)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		return (float)(GetNextSkill(myPlayerEntity, GetPlayerStatusId(index)) - myPlayerEntity.GetClientTime()) * 0.001f;
	}

	public bool isHasSkill(int index)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		return GetNextSkill(myPlayerEntity, PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_5.ID) > index;
	}

	private int GetPlayerStatusId(int index)
	{
		return index switch
		{
			0 => PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_3.ID, 
			1 => PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_2.ID, 
			2 => PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_4.ID, 
			_ => PlayerInfoStatusConstant.EV_SHADOW_DEMON_STATUS_1.ID, 
		};
	}

	private int GetNextSkill(PlayerEntity entity, int playerInfoId)
	{
		IMyDictionary<int, PlayerInfoComponent.StatusDes> status = entity.skill.Status;
		if (status.ContainsKey(playerInfoId))
		{
			return status[playerInfoId].Number;
		}
		return 0;
	}

	private float GetNextSkillMaxTime(PlayerEntity entity, int playerInfoId)
	{
		IMyDictionary<int, PlayerInfoComponent.StatusDes> status = entity.skill.Status;
		if (status.ContainsKey(playerInfoId))
		{
			return status[playerInfoId].Scale;
		}
		return 1f;
	}
}
