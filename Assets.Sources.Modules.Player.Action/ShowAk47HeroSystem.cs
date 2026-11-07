using System;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using NetData;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Action;

public class ShowAk47HeroSystem : IPlaybackSystem
{
	private WorldCameraContext _cameraContext;

	private PlayerContext _playerContext;

	private SnapshotContext _snapshotContext;

	private PlayerBagContext _playerBagContext;

	private TimeComponent _time;

	public ShowAk47HeroSystem(Contexts contexts)
	{
		_cameraContext = contexts.worldCamera;
		_playerContext = contexts.player;
		_snapshotContext = contexts.snapshot;
		_playerBagContext = contexts.playerBag;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		if (!_playerContext.isCameraOwner || !_playerBagContext.isCurrentBag)
		{
			return;
		}
		PlayerBagData data = _playerBagContext.currentBagEntity.basicInfo.Data;
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		BaseWeaponData weaponFormBag = GetWeaponFormBag(data, cameraOwnerEntity.basicInfo.Current.CurrentWeapon, cameraOwnerEntity.basicInfo.Current.CurrentWeaponIndex);
		if (weaponFormBag != null)
		{
			if (cameraOwnerEntity.hasViewAnim && cameraOwnerEntity.viewAnim.ViewAnimInfo != null && cameraOwnerEntity.viewAnim.ViewAnimInfo.StateId == 44 && weaponFormBag.AkHero != null)
			{
				cameraOwnerEntity.ReplaceAk47Hero(5000, 0, Vector3.zero, null);
			}
			else
			{
				if (cameraOwnerEntity.hasAk47Hero)
				{
					cameraOwnerEntity.RemoveAk47Hero();
				}
				if (cameraOwnerEntity.isShowAk47Hero)
				{
					cameraOwnerEntity.isShowAk47Hero = false;
				}
			}
		}
		UpdateAk47HeroShow(_time.FrameInterval);
	}

	private void UpdateAk47HeroShow(int frameInterval)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		Vector3 compenstatePos = cameraOwnerEntity.GetCompenstatePos(cameraOwnerEntity.fpos.Change.GetPosIndex());
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.hasBasicInfo || item.GetPlayerInfo().AkheroRecord == null || item.basicInfo.Current.Id == cameraOwnerEntity.basicInfo.Current.Id || !item.hasSkill || item.GetTeam() != cameraOwnerEntity.GetTeam())
			{
				continue;
			}
			if (item.GetPlayerInfo().AkheroRecord != null)
			{
				if (!item.hasAk47Hero)
				{
					item.AddAk47Hero(0, 0, Vector3.zero, null);
				}
				if (item.ak47Hero.ShowTime <= 0 && item.ak47Hero.WaitTime <= 0 && item.ak47Hero.Record != item.GetPlayerInfo().AkheroRecord)
				{
					item.ak47Hero.ShowTime = 5000;
					item.ak47Hero.WaitTime = 90000;
					item.ak47Hero.Record = item.GetPlayerInfo().AkheroRecord;
				}
			}
			else
			{
				item.isShowAk47Hero = false;
			}
			if (!item.hasAk47Hero)
			{
				continue;
			}
			item.ak47Hero.ShowTime -= frameInterval;
			item.ak47Hero.WaitTime -= frameInterval;
			if (item.ak47Hero.ShowTime < 0)
			{
				item.isShowAk47Hero = false;
				continue;
			}
			Vector3 compenstatePos2 = item.GetCompenstatePos(item.fpos.Change.GetPosIndex());
			Vector3 worldPoint = new Vector3(0f - compenstatePos2.y, compenstatePos2.z, compenstatePos2.x);
			if (item.hasVisiable && item.visiable.IsVisiable)
			{
				float num = compenstatePos.x - compenstatePos2.x;
				float num2 = compenstatePos.y - compenstatePos2.y;
				float num3 = compenstatePos.z - compenstatePos2.z;
				if (num * num + num2 * num2 + num3 * num3 < 4000000f)
				{
					worldPoint += new Vector3(0f, 180f, 0f);
					item.ak47Hero.ScreenPos = RectTransformUtility.WorldToScreenPoint(_cameraContext.unityObjects.mainCamera, worldPoint);
					item.isShowAk47Hero = true;
				}
			}
		}
	}

	public BaseWeaponData GetWeaponFormBag(PlayerBagData bag, int key, int index = 0)
	{
		if (bag == null)
		{
			return null;
		}
		switch (key)
		{
		case 5:
			try
			{
				return _snapshotContext.snapshots.LatestSnapshot.BagList.C4Weapon;
			}
			catch (Exception message)
			{
				this.LogError(message);
				return null;
			}
		case 1:
			return bag.FirstWeapon;
		case 2:
			return bag.SecondaryWeapon;
		case 3:
			return bag.MeleeWeapon;
		case 4:
			switch (index)
			{
			case 0:
				return bag.BombWeapons0;
			case 1:
				return bag.BombWeapons1;
			case 2:
				return bag.BombWeapons2;
			}
			break;
		}
		return null;
	}
}
