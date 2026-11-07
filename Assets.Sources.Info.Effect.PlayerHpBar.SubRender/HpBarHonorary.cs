using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.GameRule.GunKing;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarHonorary : BaseHpBar
{
	private static AssetInfo _bigheadKingAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/honorary/bigheadKing.png");

	private static AssetInfo _killBigheadKingAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/honorary/killBigheadKing.png");

	private static AssetInfo _bigheadAceAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/honorary/ace.png");

	private static AssetInfo _bighead2NdAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/honorary/2nd.png");

	private static AssetInfo _bighead3RdAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/honorary/3rd.png");

	private static AssetInfo _bigheadWetAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/honorary/wet.png");

	private static AssetInfo _kdAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/kd.png");

	private static AssetInfo _dominateAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/dominate.png");

	private static AssetInfo _survivorAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/survivor.png");

	private static AssetInfo _spreeAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/spree.png");

	private static AssetInfo _c4Asset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/c4.png");

	private static AssetInfo _aceAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/ace.png");

	private static AssetInfo _competeKingAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/competeKing.png");

	private static AssetInfo _2NdAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/2nd.png");

	private static AssetInfo _3RdAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/3rd.png");

	private static AssetInfo _mvpAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/mvp.png");

	private static AssetInfo _bountyhunterAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/bountyhunter.png");

	private static AssetInfo _blasterAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/blaster.png");

	private static AssetInfo _specialistsAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/specialists.png");

	private static AssetInfo _wetAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/wet.png");

	private static AssetInfo _gunkingAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/honorary/gunking.png");

	private static AssetInfo _useItem814Asset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/useItem/useItem814.png");

	private static AssetInfo _useItem836Asset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/useItem/useItem836.png");

	private static AssetInfo _useItem837Asset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/useItem/useItem837.png");

	private static AssetInfo _useItem838Asset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/useItem/useItem838.png");

	private static AssetInfo _useItem885Asset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/useItem/useItem885.png");

	private RectTransform _honors;

	private Image[] _honorImages = new Image[5];

	private RectTransform[] _honorImageTrans = new RectTransform[5];

	private GameObject[] _honorImageObjs = new GameObject[5];

	private Vector3 _lastHonorPos;

	private bool _lastHonorActive0;

	private bool _lastHonorActive1;

	private bool _lastHonorActive2;

	private bool _lastHonorActive3;

	private bool _lastHonorActive4;

	private bool _middleHonorActive0;

	private bool _middleHonorActive1;

	private bool _middleHonorActive2;

	private bool _middleHonorActive3;

	private bool _middleHonorActive4;

	private int _bioChangeTime;

	private GunKingTeamScoreDataComponent _gunKingTeamScoreData;

	private int _raceType;

	private AssetInfo[] _currHonorSprites = new AssetInfo[5];

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_honors = Tran.Find("WorldSpace/Honors").GetComponent<RectTransform>();
		for (int i = 0; i < 5; i++)
		{
			_honorImages[i] = Tran.Find("WorldSpace/Honors/HonorImage" + (i + 1)).GetComponent<Image>();
			_honorImageTrans[i] = _honorImages[i].rectTransform;
			_honorImageObjs[i] = _honorImages[i].gameObject;
		}
		SetActive(_honorImageObjs[0], ref _lastHonorActive0, newActive: false, force: true);
		SetActive(_honorImageObjs[1], ref _lastHonorActive1, newActive: false, force: true);
		SetActive(_honorImageObjs[2], ref _lastHonorActive2, newActive: false, force: true);
		SetActive(_honorImageObjs[3], ref _lastHonorActive3, newActive: false, force: true);
		SetActive(_honorImageObjs[4], ref _lastHonorActive4, newActive: false, force: true);
		_bioChangeTime = 0;
		_gunKingTeamScoreData = contexts.gameRule.gunKingTeamScoreData;
		_raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (!playerEntity.hasHonorary)
		{
			playerEntity.AddHonorary(0, newForceShowTitle: false);
		}
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		int num = 0;
		if (RaceType != 100 && !SameCameraTeam && (!GameRule.IsBio() || RaceType == 134))
		{
			SetActive(_honorImageObjs[0], ref _middleHonorActive0, newActive: false);
			SetActive(_honorImageObjs[1], ref _middleHonorActive1, newActive: false);
			SetActive(_honorImageObjs[2], ref _middleHonorActive2, newActive: false);
			SetActive(_honorImageObjs[3], ref _middleHonorActive3, newActive: false);
			SetActive(_honorImageObjs[4], ref _middleHonorActive4, newActive: false);
			FinalSetActive();
			return;
		}
		OneKillInfoData oneKillInfo = PlayerEntity.GetOneKillInfo();
		if (!HpBar.CareerActive)
		{
			if (GameRule.IsBighead())
			{
				if (oneKillInfo != null)
				{
					num = SetHonoraryImage(oneKillInfo.Overload, num, ref _bigheadKingAsset);
					num = SetHonoraryImage(oneKillInfo.Terminator, num, ref _killBigheadKingAsset);
					num = SetHonoraryImage(oneKillInfo.Ace, num, ref _bigheadAceAsset);
					num = SetHonoraryImage(oneKillInfo.Ace2, num, ref _bighead2NdAsset);
					num = SetHonoraryImage(oneKillInfo.Ace3, num, ref _bighead3RdAsset);
					num = SetHonoraryImage(oneKillInfo.KdKing, num, ref _kdAsset);
					num = SetHonoraryImage(oneKillInfo.Nurse, num, ref _bigheadWetAsset);
				}
			}
			else if (GameRule.IsBio())
			{
				if (oneKillInfo != null)
				{
					_bioChangeTime += BaseHpBar.FrameTime;
					if (_bioChangeTime > 10000)
					{
						_bioChangeTime = 0;
					}
					if (_bioChangeTime > 5000)
					{
						if (PlayerEntity.hasSkill)
						{
							IMyDictionary<int, PlayerInfoComponent.StatusDes> status = PlayerEntity.skill.Status;
							if (PlayerEntity.GetCareer() != "death" || PlayerEntity.GetCareer() != "pandoraMonther")
							{
								num = SetHonoraryImage(status.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_814.ID), num, ref _useItem814Asset);
							}
							num = SetHonoraryImage(status.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_836.ID), num, ref _useItem836Asset);
							num = SetHonoraryImage(status.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_837.ID), num, ref _useItem837Asset);
							num = SetHonoraryImage(status.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_838.ID), num, ref _useItem838Asset);
							SetActive(_honorImageObjs[0], ref _lastHonorActive0, newActive: false, force: true);
							SetActive(_honorImageObjs[1], ref _lastHonorActive1, newActive: false, force: true);
							SetActive(_honorImageObjs[2], ref _lastHonorActive2, newActive: false, force: true);
							if (num == 0 && PlayerEntity.GetStealthAlpha() > 0.8f)
							{
								num = SetHonoraryImage(oneKillInfo.Ace, num, ref _dominateAsset);
								num = SetHonoraryImage(oneKillInfo.Ace2, num, ref _survivorAsset);
								num = SetHonoraryImage(oneKillInfo.Ace3, num, ref _spreeAsset);
							}
						}
					}
					else
					{
						num = SetHonoraryImage(oneKillInfo.Ace, num, ref _dominateAsset);
						num = SetHonoraryImage(oneKillInfo.Ace2, num, ref _survivorAsset);
						num = SetHonoraryImage(oneKillInfo.Ace3, num, ref _spreeAsset);
						if (num == 0 && PlayerEntity.hasSkill)
						{
							IMyDictionary<int, PlayerInfoComponent.StatusDes> status2 = PlayerEntity.skill.Status;
							num = SetHonoraryImage(status2.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_814.ID), num, ref _useItem814Asset);
							num = SetHonoraryImage(status2.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_836.ID), num, ref _useItem836Asset);
							num = SetHonoraryImage(status2.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_837.ID), num, ref _useItem837Asset);
							num = SetHonoraryImage(status2.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_838.ID), num, ref _useItem838Asset);
							num = SetHonoraryImage(status2.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_885.ID), num, ref _useItem885Asset);
						}
					}
				}
			}
			else if (GameRule.IsExplode())
			{
				num = SetHonoraryImage(PlayerData.HasC4, num, ref _c4Asset);
				if (oneKillInfo != null)
				{
					num = SetHonoraryImage(oneKillInfo.Ace, num, ref _aceAsset);
					num = SetHonoraryImage(oneKillInfo.Ace2, num, ref _2NdAsset);
					num = SetHonoraryImage(oneKillInfo.Ace3, num, ref _3RdAsset);
					num = SetHonoraryImage(oneKillInfo.Mvp, num, ref _mvpAsset);
					num = SetHonoraryImage(oneKillInfo.KdKing, num, ref _kdAsset);
					num = SetHonoraryImage(oneKillInfo.GoldHunter, num, ref _bountyhunterAsset);
					num = SetHonoraryImage(oneKillInfo.MaxHidePack, num, ref _blasterAsset);
					num = SetHonoraryImage(oneKillInfo.MaxOpenPack, num, ref _specialistsAsset);
				}
			}
			else if (RaceType == 9)
			{
				if (oneKillInfo != null)
				{
					num = SetHonoraryImage(oneKillInfo.PlayerName == _gunKingTeamScoreData.GunkingPlayerName, num, ref _gunkingAsset);
					num = SetHonoraryImage(oneKillInfo.Ace2, num, ref _2NdAsset);
					num = SetHonoraryImage(oneKillInfo.Ace3, num, ref _3RdAsset);
					num = SetHonoraryImage(oneKillInfo.Mvp, num, ref _mvpAsset);
					num = SetHonoraryImage(oneKillInfo.KdKing, num, ref _kdAsset);
				}
			}
			else if (RaceType == 10)
			{
				if (oneKillInfo != null)
				{
					num = SetHonoraryImage(oneKillInfo.Ace, num, ref _gunkingAsset);
					num = SetHonoraryImage(oneKillInfo.Ace2, num, ref _2NdAsset);
					num = SetHonoraryImage(oneKillInfo.Ace3, num, ref _3RdAsset);
					num = SetHonoraryImage(oneKillInfo.Mvp, num, ref _mvpAsset);
					num = SetHonoraryImage(oneKillInfo.KdKing, num, ref _kdAsset);
				}
			}
			else if (RaceType == 100)
			{
				if (Contexts.sharedInstance.battleRoom.playerInfo.AllHonorDic.ContainsKey(PlayerData.Id))
				{
					foreach (string item in Contexts.sharedInstance.battleRoom.playerInfo.AllHonorDic[PlayerData.Id])
					{
						string text = "";
						string assetName = item;
						if (item.StartsWith("commonfree"))
						{
							text = "effect/commomfree";
							assetName = "Assets/Res/Assets/effect/" + item;
						}
						else if (item.StartsWith("common"))
						{
							text = "effect/common";
							assetName = "Assets/Res/Assets/effect/" + item;
						}
						else
						{
							text = "effect/" + FreeType + "mode";
						}
						AssetInfo asset = new AssetInfo(text, assetName);
						num = SetHonoraryImage(flag: true, num, ref asset);
					}
				}
			}
			else if (!RuleUtilty.IsUltimateChallenge() && oneKillInfo != null)
			{
				num = SetHonoraryImage(oneKillInfo.Ace, num, ref _aceAsset);
				num = SetHonoraryImage(oneKillInfo.Ace2, num, ref _2NdAsset);
				num = SetHonoraryImage(oneKillInfo.Ace3, num, ref _3RdAsset);
				num = SetHonoraryImage(oneKillInfo.KdKing, num, ref _kdAsset);
				num = SetHonoraryImage(oneKillInfo.Mvp, num, ref _mvpAsset);
				num = SetHonoraryImage(oneKillInfo.Nurse, num, ref _wetAsset);
				num = SetHonoraryImage(oneKillInfo.CompeteKing, num, ref _competeKingAsset);
			}
		}
		if (num > 0)
		{
			HpBar.PosY += 15;
			SetPosition(_honors, ref _lastHonorPos, new Vector3(0f, HpBar.PosY));
			HpBar.PosY += 15;
		}
		if (playerEntity.hasHonorary && playerEntity.honorary.ForceShowTitle)
		{
			playerEntity.honorary.NumHonorary = num;
			num = 0;
		}
		if (num <= 0)
		{
			SetHonoraryActive(_honorImageObjs[0], ref _middleHonorActive0, newActive: false);
		}
		if (num <= 1)
		{
			SetHonoraryActive(_honorImageObjs[1], ref _middleHonorActive1, newActive: false);
		}
		if (num <= 2)
		{
			SetHonoraryActive(_honorImageObjs[2], ref _middleHonorActive2, newActive: false);
		}
		if (num <= 3)
		{
			SetHonoraryActive(_honorImageObjs[3], ref _middleHonorActive3, newActive: false);
		}
		if (num <= 4)
		{
			SetHonoraryActive(_honorImageObjs[4], ref _middleHonorActive4, newActive: false);
		}
		FinalSetActive();
	}

	public void SetHonoraryActive(GameObject obj, ref bool lastActive, bool newActive, bool force = false)
	{
		if (newActive != lastActive || force)
		{
			lastActive = newActive;
		}
	}

	public void FinalSetActive()
	{
		if (_middleHonorActive0 != _lastHonorActive0)
		{
			_honorImageObjs[0].SetObjectActive(_middleHonorActive0);
			_lastHonorActive0 = _middleHonorActive0;
		}
		if (_middleHonorActive1 != _lastHonorActive1)
		{
			_honorImageObjs[1].SetObjectActive(_middleHonorActive1);
			_lastHonorActive1 = _middleHonorActive1;
		}
		if (_middleHonorActive2 != _lastHonorActive2)
		{
			_honorImageObjs[2].SetObjectActive(_middleHonorActive2);
			_lastHonorActive2 = _middleHonorActive2;
		}
		if (_middleHonorActive3 != _lastHonorActive3)
		{
			_honorImageObjs[3].SetObjectActive(_middleHonorActive3);
			_lastHonorActive3 = _middleHonorActive3;
		}
		if (_middleHonorActive4 != _lastHonorActive4)
		{
			_honorImageObjs[4].SetObjectActive(_middleHonorActive4);
			_lastHonorActive4 = _middleHonorActive4;
		}
	}

	protected int SetHonoraryImage(bool flag, int count, ref AssetInfo asset)
	{
		if (flag && count < 5)
		{
			if (_currHonorSprites[count] != asset)
			{
				_currHonorSprites[count] = asset;
				if (BaseHpBar.SpriteDic.ContainsKey(asset))
				{
					_honorImages[count].sprite = BaseHpBar.SpriteDic[asset];
					_honorImageTrans[count].sizeDelta = BaseHpBar.SpriteDic[asset].rect.size * 0.75f;
				}
				else
				{
					int count2 = count;
					AssetInfo info1 = asset;
					Loader.RetriveSprite(asset, delegate(Sprite sprite)
					{
						if (_currHonorSprites[count2] == info1)
						{
							_honorImages[count2].sprite = SaveSprite(info1, sprite);
							_honorImageTrans[count2].sizeDelta = sprite.rect.size * 0.75f;
						}
					});
				}
			}
			if (count == 0)
			{
				SetHonoraryActive(_honorImageObjs[0], ref _middleHonorActive0, newActive: true);
			}
			if (count == 1)
			{
				SetHonoraryActive(_honorImageObjs[1], ref _middleHonorActive1, newActive: true);
			}
			if (count == 2)
			{
				SetHonoraryActive(_honorImageObjs[2], ref _middleHonorActive2, newActive: true);
			}
			if (count == 3)
			{
				SetHonoraryActive(_honorImageObjs[3], ref _middleHonorActive3, newActive: true);
			}
			if (count == 4)
			{
				SetHonoraryActive(_honorImageObjs[4], ref _middleHonorActive4, newActive: true);
			}
			count++;
		}
		return count;
	}
}
