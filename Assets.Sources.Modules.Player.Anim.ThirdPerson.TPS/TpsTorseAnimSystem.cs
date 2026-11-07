using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Assets.Sources.Info.AnimState;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Weapon;
using Entitas;
using SSJJAnim.AnimState;
using SSJJAnim.CareerAnim;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson.TPS;

public class TpsTorseAnimSystem : FrameExecuteSystem, IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private readonly PlayerContext _playerContext;

	private bool _isCanFrame;

	public TpsTorseAnimSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.TorseAnim));
		int raceType = contexts.battleRoom.roomData.Data.RaceType;
		_isCanFrame = !RuleUtilty.IsGroupModel(raceType) && !RuleUtilty.IsExplode(raceType);
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			if (PlayerAnimationUtility.CheckIsTPSAnimSystem(player))
			{
				UpdatePlayerTorsoAnim(player);
			}
		}
	}

	public void OnPlayback()
	{
		OnRender();
	}

	private bool CheckIsCustomAnimSystem(PlayerEntity entity)
	{
		if (PlayerAnimationUtility.CheckIsTPSAnimSystem(entity))
		{
			return true;
		}
		return false;
	}

	private void UpdatePlayerTorsoAnim(PlayerEntity playerEntity)
	{
		if (!playerEntity.hasThirdPersonUnityObjects)
		{
			return;
		}
		ICareerInfo careerInfo = playerEntity.thirdPersonUnityObjects.CareerInfo;
		if (BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimInfo(careerInfo) == null)
		{
			return;
		}
		IEntitsWeaponInfo weaponInfo = playerEntity.thirdPersonUnityObjects.WeaponInfo;
		TorseAnimComponent torseAnim = playerEntity.torseAnim;
		LegAnimComponent legAnim = playerEntity.legAnim;
		ISjAnimatior animator = playerEntity.thirdPersonUnityObjects.Animator;
		float num = torseAnim.EclipsedTime;
		if (torseAnim.TorsoAnimInfo == null)
		{
			return;
		}
		TorseAnimCache.TorseAnimParam param = default(TorseAnimCache.TorseAnimParam);
		param.StateId = torseAnim.TorsoAnimInfo.StateId;
		param.CareerName = careerInfo.Name;
		param.WeaponName = weaponInfo.Name;
		param.DuckState = playerEntity.move.DuckState;
		string text = SingletonInstance<TorseAnimCache>.Instance.GetAnimCache(param);
		if (string.IsNullOrEmpty(text))
		{
			text = TorseAnimUtil.GetTorseAnimationName(careerInfo.Name, animator.GetAnimations(), torseAnim.TorsoAnimInfo.StateId, weaponInfo, playerEntity.move.DuckState);
			if (text == null)
			{
				animator.Stop(1);
				return;
			}
			SingletonInstance<TorseAnimCache>.Instance.SetAnimCache(param, text);
		}
		if (text == null)
		{
			this.LogErrorFormat("AnimationName not implented StateId {0} WeaponName {1} CareerName {2} DuckState {3}", torseAnim.TorsoAnimInfo.StateId, weaponInfo.Name, careerInfo.Name, playerEntity.move.DuckState);
		}
		float num2 = num;
		torseAnim.TorsoAnimInfo.IsWarpAnim = false;
		bool visiable = !playerEntity.hasVisiable || playerEntity.visiable.IsVisiable || playerEntity.visiable.IsNear;
		if (torseAnim.TorsoAnimInfo.CheckTorseEnable(weaponInfo, careerInfo, legAnim.LegsAnimInfo.StateId))
		{
			animator.PlayAtFixedTime(1, text, num2 * 0.001f, 1f, torseAnim.TorsoAnimInfo.IsLoop, isReverse: false, 0f, visiable);
		}
		else
		{
			animator.Stop(1);
		}
		if (playerEntity != _playerContext.myPlayerEntity && WeaponUtility.IsSpecial(weaponInfo.Name) && playerEntity.hasThirdBoneCache && playerEntity.thirdBoneCache.Cache != null)
		{
			if (playerEntity.IsDead())
			{
				WeaponUtility.ResetHandScale(animator, 1f);
				torseAnim.SpecialMode = true;
			}
			else
			{
				WeaponUtility.ResetHandScale(animator, 1f);
				if (!torseAnim.SpecialMode && playerEntity.hasThirdBoneCache)
				{
					playerEntity.thirdBoneCache.Store();
				}
				WeaponUtility.SetHandBoneScale(animator, 0.01f, weaponInfo.Name, playerEntity.GetCurrentWeaponEffectLevel());
				if (!torseAnim.SpecialMode && playerEntity.hasThirdBoneCache)
				{
					playerEntity.thirdBoneCache.Revert();
				}
				torseAnim.SpecialMode = false;
			}
		}
		if (playerEntity.thirdPersonUnityObjects.WeaponAnimator != null)
		{
			playerEntity.thirdPersonUnityObjects.WeaponAnimator.PlayAtFixedTime(0, text, num2 * 0.001f, 1f, isLoop: false, isReverse: false, 0f, visiable);
		}
		torseAnim.LastTorseAnimInfo = torseAnim.TorsoAnimInfo;
	}
}
