using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using SSJJAsset.Asset;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar;

public class PlayerHpBarEffectInfo
{
	private static PlayerHpBarEffectInfo _instance;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private static AssetInfo _assetInfo = new AssetInfo("playereffectprefab/playerhpbar", "PlayerHpBar", typeof(GameObject));

	public static PlayerHpBarEffectInfo Instance => _instance ?? (_instance = new PlayerHpBarEffectInfo());

	public void Clear()
	{
		_instance._battleRoomContext = null;
		_instance._gameRuleContext = null;
		_instance = null;
	}

	public PlayerHpBarEffectInfo()
	{
		Contexts sharedInstance = Contexts.sharedInstance;
		_battleRoomContext = sharedInstance.battleRoom;
		_gameRuleContext = sharedInstance.gameRule;
	}

	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (player.HasStatus(PlayerInfoStatusConstant.LIGHTHING_SEE_ALL.ID))
		{
			return true;
		}
		if (player.basicInfo.Current.MaxHudun > 1 || player.basicInfo.Current.MaxZhuangjia > 0)
		{
			return true;
		}
		if (RuleUtilty.IsUltimateChallenge() && player.HasStatus(PlayerInfoStatusConstant.HIDE_IN_MAP.ID))
		{
			return false;
		}
		if (_battleRoomContext.roomData.IsObserver && !_gameRuleContext.currentRule.Rule.IsBio() && !_gameRuleContext.currentRule.Rule.IsBighead())
		{
			return false;
		}
		if (player.IsMySelf())
		{
			return false;
		}
		if (player.GetTeam() != UiIEventCondition.Get_uiMyPlayer_Team() && !_gameRuleContext.currentRule.Rule.IsShowEnemyHpBar() && !_gameRuleContext.currentRule.Rule.IsShowKiller())
		{
			return false;
		}
		if (player.hasSkill && player.hasThirdPersonUnityObjects && player.skill.getStealthAlpha() <= 0.05f && !_gameRuleContext.currentRule.Rule.IsBio() && !_gameRuleContext.currentRule.Rule.IsBio2() && !_gameRuleContext.currentRule.Rule.IsBio3() && !_gameRuleContext.currentRule.Rule.IsBioEvolutionChallengeMode() && _gameRuleContext.currentRule.Rule.IsBioEvolution() && !player.HasStatus(PlayerInfoStatusConstant.PLAYER_STEALTH4_FLAG.ID))
		{
			return false;
		}
		if (player.IsDead() && !player.HasState(524288) && !PlayerCareerConstantUtility.IsEmpress(player.GetCareer()))
		{
			return false;
		}
		return true;
	}

	public AssetInfo GetAssetInfo()
	{
		return _assetInfo;
	}
}
