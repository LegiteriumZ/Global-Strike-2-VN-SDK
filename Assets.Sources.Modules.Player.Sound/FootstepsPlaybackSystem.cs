using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;
using SSJJAsset.Asset;
using SSJJAsset.AssetManager;
using SSJJBase.String;
using SSJJBase.Thread;
using SSJJMath;
using Sharpen;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.Sound;

internal abstract class FootstepsPlaybackSystem : IResourceLoadSystem
{
	protected readonly Dictionary<string, AudioClip> ClipCache = new Dictionary<string, AudioClip>();

	protected readonly Dictionary<int, StepInfo> StepIndexCache = new Dictionary<int, StepInfo>();

	protected IGroup<PlayerEntity> Players;

	private Dictionary<long, Vector3> _lastPosition = new Dictionary<long, Vector3>();

	private Comparison<PlayingSound> _sortCompComparsion;

	private List<PlayingSound> _playList = new List<PlayingSound>();

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		if (!Contexts.sharedInstance.player.isCameraOwner)
		{
			return;
		}
		PlayerEntity cameraOwnerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
		foreach (PlayerEntity player in Players)
		{
			Process(coRoutineManager, player, cameraOwnerEntity);
		}
	}

	private void Process(ICoRoutineManager coRoutineManager, PlayerEntity playerEntity, PlayerEntity camerOwner)
	{
		if ((playerEntity.isMyPlayer && Contexts.sharedInstance.gameRule.currentRule.Rule.IsGeneralPve()) || Vector3.Distance(camerOwner.GetCompenstatePos(camerOwner.fpos.Change.GetPosIndex()), playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex())) >= 3000f)
		{
			return;
		}
		float num = 2f;
		int intval = 0;
		AssetInfo assetInfo = default(AssetInfo);
		assetInfo.BundleName = new IgnoreCaseString("");
		assetInfo.AssetName = new IgnoreCaseString("");
		AssetInfo info = assetInfo;
		if (playerEntity.basicInfo.Current.EType == 2)
		{
			num = 0.6f;
			if (playerEntity.basicInfo.IsDead || !playerEntity.partBasicInfo.IsFootStep)
			{
				return;
			}
			info = (playerEntity.state.GetPlayerStateType(16777216) ? SoundResourceUtility.GetPlayerStepOnLadder() : ((!playerEntity.HasStatus(PlayerInfoStatusConstant.MANGWANG_NO_SPEED_LIMIT.ID)) ? ((!PlayerCareerConstantUtility.IsHaveOwerStepSound(playerEntity.basicInfo.CareerInfo.Name)) ? GetDefaultStepAssetInfo(playerEntity) : SoundResourceUtility.GetPlayerStepCareer(playerEntity.basicInfo.CareerInfo.Name)) : SoundResourceUtility.GetPlayerStepCareer(playerEntity.basicInfo.CareerInfo.Name)));
		}
		else if (playerEntity.basicInfo.Current.EType == 0)
		{
			if (playerEntity.basicInfo.Current.IsDead)
			{
				return;
			}
			long cid = playerEntity.basicInfo.Cid;
			if (!_lastPosition.ContainsKey(cid))
			{
				_lastPosition[cid] = Vector3.zero;
			}
			if (_lastPosition[cid] == playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex()))
			{
				return;
			}
			_lastPosition[cid] = playerEntity.GetCompenstatePos(playerEntity.fpos.Change.GetPosIndex());
			int num2 = ((camerOwner != playerEntity) ? playerEntity.move.Velocity2D : ((int)Mathf.Sqrt(playerEntity.move.Velocity.x * playerEntity.move.Velocity.x + playerEntity.move.Velocity.y * playerEntity.move.Velocity.y)));
			bool playerStateType = playerEntity.state.GetPlayerStateType(16777216);
			if (playerEntity.isCameraOwner)
			{
				num = 0.6f;
			}
			if (playerStateType && num2 > 350 && playerEntity.move.Moving)
			{
				info = SoundResourceUtility.GetPlayerStepOnLadder();
			}
			else if (!playerStateType && num2 > 350 && playerEntity.move.OnGround)
			{
				intval = 650 - num2;
				info = ((!playerEntity.HasStatus(PlayerInfoStatusConstant.MANGWANG_NO_SPEED_LIMIT.ID)) ? ((!PlayerCareerConstantUtility.IsHaveOwerStepSound(playerEntity.basicInfo.CareerInfo.Name)) ? GetDefaultStepAsset(playerEntity) : SoundResourceUtility.GetPlayerStepCareer(playerEntity.basicInfo.CareerInfo.Name)) : SoundResourceUtility.GetPlayerStepCareer(playerEntity.basicInfo.CareerInfo.Name));
			}
		}
		num *= GetFootStepVolMultiplier(playerEntity);
		if (string.IsNullOrEmpty(info.AssetName))
		{
			return;
		}
		FootstepControl footstepControl = GetFootstepControl(playerEntity);
		if (ClipCache.ContainsKey(info.AssetName))
		{
			AudioClip audioClip = ClipCache[info.AssetName];
			if (audioClip != null && footstepControl != null)
			{
				footstepControl.Play(audioClip, num, 1500, intval);
			}
			_playList.Add(PlayingSound.Create(null, footstepControl));
		}
		else
		{
			IEnumerator enumerator = Process(info, footstepControl, num, intval);
			coRoutineManager.StartCoRoutine(enumerator);
			_playList.Add(PlayingSound.Create(enumerator, footstepControl));
		}
		for (int num3 = _playList.Count - 2; num3 >= 0; num3--)
		{
			if (_playList[num3].Control == _playList.Last().Control)
			{
				PlayingSound.Recircyle(_playList[num3]);
				_playList.RemoveAt(num3);
			}
			else if (_playList[num3].Control == null)
			{
				PlayingSound.Recircyle(_playList[num3]);
				_playList.RemoveAt(num3);
			}
		}
		if (_sortCompComparsion == null)
		{
			_sortCompComparsion = SortComp;
		}
		if (_playList.Count > 4)
		{
			_playList.Sort(_sortCompComparsion);
			_playList.Last().Stop(coRoutineManager);
			_playList.RemoveLast();
		}
	}

	private float GetFootStepVolMultiplier(PlayerEntity playerEntity)
	{
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.WeakFootstep.ID))
		{
			return 0.25f;
		}
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.THUNDER_LEGEND_IN_CONTROL.ID))
		{
			return 0f;
		}
		if (playerEntity.HasStatus(PlayerInfoStatusConstant.NO_Footstep.ID))
		{
			return 0f;
		}
		if (playerEntity.hasBasicInfo)
		{
			return 1f + (float)playerEntity.basicInfo.Current.FootstepsSound / 100f;
		}
		return 1f;
	}

	private AssetInfo GetDefaultStepAssetInfo(PlayerEntity playerEntity)
	{
		StepIndexCache.TryGetValue(playerEntity.GetId(), out var value);
		if (value == null)
		{
			value = new StepInfo();
			StepIndexCache.Add(playerEntity.GetId(), value);
		}
		FootstepControl footstepControl = GetFootstepControl(playerEntity);
		if (value.stepTime > 0f && !footstepControl.canChangeClip())
		{
			return value.sndInfo;
		}
		int num;
		for (num = UnityEngine.Random.Range(1, 4); num == value.stepInex; num = UnityEngine.Random.Range(1, 4))
		{
		}
		value.stepInex = num;
		value.stepTime = Time.time;
		value.sndInfo = SoundResourceUtility.GetPlayerStepForIndex(num);
		return value.sndInfo;
	}

	private AssetInfo GetDefaultStepAsset(PlayerEntity playerEntity)
	{
		return GetDefaultStepAssetInfo(playerEntity);
	}

	private Vector3 GetMyPosition()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			return VectorCoordConverter.SsjjToUnity(myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex()));
		}
		return Vector3.zero;
	}

	private int SortComp(PlayingSound a, PlayingSound b)
	{
		Vector3 myPosition = GetMyPosition();
		float num = Vector3.Distance(a.Control.transform.position, myPosition);
		float num2 = Vector3.Distance(b.Control.transform.position, myPosition);
		if (num < num2)
		{
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		return 0;
	}

	protected abstract FootstepControl GetFootstepControl(PlayerEntity playerEntity);

	private IEnumerator Process(AssetInfo info, FootstepControl control, float vol, int intval)
	{
		AudioClip audioClip;
		if (!ClipCache.ContainsKey(info.AssetName))
		{
			AssetAsyncLoader<AudioClip> loader = new AssetAsyncLoader<AudioClip>();
			yield return loader.LoadAsync(info);
			audioClip = loader.Instantiate();
			if (audioClip != null)
			{
				ClipCache[info.AssetName] = audioClip;
			}
		}
		else
		{
			audioClip = ClipCache[info.AssetName];
		}
		if (audioClip != null && control != null)
		{
			control.Play(audioClip, vol, 1500, intval);
		}
	}
}
