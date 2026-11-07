using Assets.Generated.Table;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using I2.Loc;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Attack.WeaponAttack;

internal class ShotGunLaserLitePredicationSystem : AbstractAttackPredicationSystem
{
	internal class ShotGunLaserFrameAction : IFrameCmdAction, ICmdAction
	{
		private readonly MessageContext _messageContext;

		public ShotGunLaserFrameAction(Contexts contexts)
		{
			_messageContext = contexts.message;
		}

		public bool Action(ref CommonWeaponArg arg)
		{
			if (!arg.Player.hasFirstPersonUnityObjects)
			{
				return false;
			}
			PlaySkillSound(ref arg);
			return false;
		}

		private void ChangeMode(ref CommonWeaponArg arg)
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			if (!arg.Cmd.IsDemolitionOn || !CanChangeAnim(arg.Player) || !CheckGameRule(raceType))
			{
				return;
			}
			if (!arg.CurrentWeapon.special.SpecialMode)
			{
				if ((!RuleUtilty.IsGeneralPve(raceType)) ? (arg.CurrentWeapon.power.Power2 > 0) : (arg.CurrentWeapon.power.Power2 > 3))
				{
					NormalToSpecialModel(ref arg);
					return;
				}
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("FUEL_SHORTAGE_CAN_NOT_USE"));
				NotifyManager.ForceInvoke(38);
			}
			else
			{
				SpecialToNormalModel(ref arg);
			}
		}

		private static void PlaySkillSound(ref CommonWeaponArg arg)
		{
			AudioSource audioSource = arg.Player.firstPersonUnityObjects.WeaponGameObject.GetComponent<AudioSource>();
			if (audioSource == null)
			{
				audioSource = arg.Player.firstPersonUnityObjects.WeaponGameObject.AddComponent<AudioSource>();
			}
			if (arg.CurrentWeapon.special.SpecialMode && arg.Cmd.IsAttackOn)
			{
				if (!audioSource.isPlaying)
				{
					audioSource.volume = GameSoundManager.Config.WeaponVolume;
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, arg.Player.isMyPlayer, audioSource, new AssetInfo("sound/weapon/shotgun_laser", "Assets/Res/Assets/sound/weapon/shotgun_laser_fire3.mp3"));
				}
			}
			else if (audioSource.isPlaying)
			{
				audioSource.Stop();
			}
		}

		private bool CheckGameRule(int raceType)
		{
			if (!RuleUtilty.IsGeneralPve(raceType) && !RuleUtilty.IsPve(raceType))
			{
				return RuleUtilty.IsBioMode(raceType);
			}
			return true;
		}

		private bool CanChangeAnim(PlayerEntity player)
		{
			if (!PlayerAnimationUtility.IsViewAnimEqual(player, 36) && !PlayerAnimationUtility.IsViewAnimEqual(player, 37) && !PlayerAnimationUtility.IsViewAnimEqual(player, 46) && !PlayerAnimationUtility.IsViewAnimEqual(player, 17) && !PlayerAnimationUtility.IsViewAnimEqual(player, 44))
			{
				return !PlayerAnimationUtility.IsViewAnimEqual(player, 117);
			}
			return false;
		}

		public void NormalToSpecialModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 36);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 36);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = true;
		}

		public void SpecialToNormalModel(ref CommonWeaponArg arg)
		{
			PlayerAnimationUtility.SetViewAnimation(arg.Player, 37);
			int viewAnimDuration = PlayerAnimationUtility.GetViewAnimDuration(arg.CurrentWeapon.basicInfo.Info, 37);
			arg.CurrentWeapon.attack.NextAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.attack.NextSecondaryAttackTimer = arg.ClientTime + viewAnimDuration;
			arg.CurrentWeapon.special.SpecialMode = false;
		}
	}

	public ShotGunLaserLitePredicationSystem(Contexts contexts)
		: base(contexts)
	{
		IdleActions.Add(new RifleIdleAction(contexts));
		LeftActions.Add(new ShotGunSpecialLeftAction(contexts));
		RightActions.Add(new RifleMeleeSpecialRightAction(contexts));
		FrameActions.Add(new ShotGunLaserFrameAction(contexts));
	}
}
