using System;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using share.constant;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerSetStealthAlphaSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	private TimeComponent _time;

	public PlayerSetStealthAlphaSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.hasState || !item.hasSkill)
			{
				continue;
			}
			float num = (float)item.basicInfo.Current.Alpha / 100f;
			float stealthSelfAlpha = (float)item.basicInfo.Current.SelfAlpha / 100f;
			if (item.state.GetPlayerStateType(2048))
			{
				num = Math.Min(_gameRuleContext.currentRule.Rule.GetStealthAlpha1(), num);
			}
			else if (item.state.GetPlayerStateType(4096))
			{
				num = Math.Min(_gameRuleContext.currentRule.Rule.GetStealthAlpha2(), num);
			}
			else if (item.state.GetPlayerStateType(8192))
			{
				num = Math.Min(_gameRuleContext.currentRule.Rule.GetStealthAlpha3(), num);
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.THUNDER_LEGEND_SHADOW.ID))
			{
				num = 0.01f;
				if (!_gameRuleContext.currentRule.Rule.IsBio() && !_gameRuleContext.currentRule.Rule.IsBio2() && !_gameRuleContext.currentRule.Rule.IsBio3() && !_gameRuleContext.currentRule.Rule.IsBioEvolution() && !_gameRuleContext.currentRule.Rule.IsBioEvolutionChallengeMode())
				{
					if (_playerContext.cameraOwnerEntity.basicInfo.Cid != item.basicInfo.Cid)
					{
						num = 0.4f;
					}
				}
				else if (_playerContext.cameraOwnerEntity.basicInfo.Current.Team == item.basicInfo.Current.Team && _playerContext.cameraOwnerEntity.basicInfo.Cid != item.basicInfo.Cid)
				{
					num = 0.4f;
				}
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.PLAYER_STEALTH4_FLAG.ID))
			{
				num = 0.01f;
				if (_playerContext.cameraOwnerEntity.basicInfo.Current.Team == item.basicInfo.Current.Team && _playerContext.cameraOwnerEntity.basicInfo.Cid != item.basicInfo.Cid)
				{
					num = 0.2f;
				}
			}
			else if (item.HasStatus(PlayerInfoStatusConstant.HideBody.ID))
			{
				stealthSelfAlpha = 0.01f;
				num = 0.01f;
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_BOSS21_YINSHEN.ID))
			{
				num = 0.01f;
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.ANYING1_STATE.ID))
			{
				num = ((!item.hasFirstPersonUnityObjects) ? 0f : 0.5f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.ANYING2_STATE.ID))
			{
				num = ((!item.hasFirstPersonUnityObjects) ? 0.25f : 0.5f);
			}
			else if (item.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_XP1003_SKILL_KILLED.ID) || item.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_XP1004_SIWANG_FEI.ID) || item.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_XP1004_SIWANG_JING.ID) || item.skill.Status.ContainsKey(PlayerInfoStatusConstant.BLOCK_COMBINED_CANNON_KILL.ID))
			{
				num = item.skill.getStealthAlpha();
				num -= (float)_time.FrameInterval * 0.003f;
				if ((double)num <= 0.01)
				{
					num = 0.01f;
				}
			}
			item.skill.setStealthAlpha(num);
			item.skill.setStealthSelfAlpha(stealthSelfAlpha);
		}
	}
}
