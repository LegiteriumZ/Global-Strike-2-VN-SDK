using System;
using Assets.Sources.Components.Time;
using share.constant;

public class commonDragonAuraSkillProvider : IcommonDragonAuraSkillProvider, IModuleProvider
{
	private float showTime;

	private string weaponName = "dragon_aura2";

	private int currentPlayerInfoID;

	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	public commonDragonAuraSkillProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		showTime = Math.Abs(time.RenderTime % 1000 - 500);
	}

	public float GetPercentage()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.DRAGON_AURA_HEAT1.ID))
		{
			return myPlayerEntity.skill.Status[PlayerInfoStatusConstant.DRAGON_AURA_HEAT1.ID].Number;
		}
		if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.DRAGON_AURA_HEAT2.ID))
		{
			return myPlayerEntity.skill.Status[PlayerInfoStatusConstant.DRAGON_AURA_HEAT2.ID].Number;
		}
		if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.DRAGON_AURA_HEAT3.ID))
		{
			return myPlayerEntity.skill.Status[PlayerInfoStatusConstant.DRAGON_AURA_HEAT3.ID].Number;
		}
		if (myPlayerEntity.HasStatus(10132041))
		{
			return myPlayerEntity.skill.Status[10132041].Number;
		}
		if (myPlayerEntity.HasStatus(10132042))
		{
			return myPlayerEntity.skill.Status[10132042].Number;
		}
		if (myPlayerEntity.HasStatus(10132043))
		{
			return myPlayerEntity.skill.Status[10132043].Number;
		}
		return 0f;
	}

	public float GetProgress()
	{
		return GetPercentage() / 100f;
	}

	public bool ShowUI()
	{
		return GetPercentage() > 0f;
	}

	public float GetAlpha(int index)
	{
		return showTime / 1000f + 0.5f;
	}

	private bool isCurrentWeapon(string weaponName)
	{
		switch (weaponName)
		{
		case "dragon_aura":
		case "dragon_aura1":
		case "dragon_aura2":
			return true;
		default:
			return false;
		}
	}
}
