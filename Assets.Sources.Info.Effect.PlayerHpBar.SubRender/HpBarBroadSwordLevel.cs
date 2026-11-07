using System.Collections.Generic;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarBroadSwordLevel : BaseHpBar
{
	private GameObject _levelObj;

	private Image _levelImage;

	private int _level = -1;

	private Vector3 _lastPos;

	private bool _lastActive = true;

	private int _raceType;

	private BattleRoomContext _battleRoom;

	private AssetInfo[] _levelAssetInfos = new AssetInfo[5];

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_levelImage = Tran.Find("WorldSpace/BroadSwordLevel").GetComponent<Image>();
		_levelObj = _levelImage.gameObject;
		SetActive(_levelObj, ref _lastActive, newActive: false);
		_raceType = contexts.battleRoom.roomData.Data.RaceType;
		_battleRoom = contexts.battleRoom;
		_levelAssetInfos[0] = new AssetInfo("effect/broadswordmode", "Assets/Res/Assets/effect/BroadSwordMode/Level/Len_5.png");
		_levelAssetInfos[1] = new AssetInfo("effect/broadswordmode", "Assets/Res/Assets/effect/BroadSwordMode/Level/Len_10.png");
		_levelAssetInfos[2] = new AssetInfo("effect/broadswordmode", "Assets/Res/Assets/effect/BroadSwordMode/Level/Len_20.png");
		_levelAssetInfos[3] = new AssetInfo("effect/broadswordmode", "Assets/Res/Assets/effect/BroadSwordMode/Level/Len_30.png");
		_levelAssetInfos[4] = new AssetInfo("effect/broadswordmode", "Assets/Res/Assets/effect/BroadSwordMode/Level/Len_40.png");
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		if (_raceType != 123)
		{
			return;
		}
		List<OneKillInfoData> all = _battleRoom.playerInfo.All;
		int id = playerEntity.basicInfo.Current.Id;
		int num = -1;
		foreach (OneKillInfoData item in all)
		{
			if (item.Id == id)
			{
				num = item.Lv;
			}
		}
		if (num < 0)
		{
			SetActive(_levelObj, ref _lastActive, newActive: false);
			return;
		}
		if (_level != num)
		{
			_level = num;
			Loader.RetriveSprite(_levelAssetInfos[_level], delegate(Sprite sprite)
			{
				_levelImage.sprite = sprite;
				_levelImage.SetNativeSize();
				SetActive(_levelObj, ref _lastActive, newActive: true);
			});
		}
		HpBar.PosY += 30;
		SetPosition(_levelObj.transform, ref _lastPos, new Vector3(0f, HpBar.PosY));
		HpBar.PosY += 30;
	}
}
