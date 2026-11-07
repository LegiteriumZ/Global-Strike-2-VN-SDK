using System;
using System.Collections.Generic;
using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarCareer : BaseHpBar
{
	private static AssetInfo _bigheadiAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/careersuggest/bigheadi.png");

	private static AssetInfo _bigheadtAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/careersuggest/bigheadt.png");

	private static AssetInfo _bigheadheroiAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/careersuggest/bigheadheroi.png");

	private static AssetInfo _bigheadherotAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/careersuggest/bigheadherot.png");

	private static AssetInfo _bigheadhumanityAsset = new AssetInfo("effect/bigheadmode", "Assets/Res/Assets/effect/bigheadMode/careersuggest/humanity.png");

	private static AssetInfo _heroAsset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/biochiemicalcareersuggest/hero.png");

	private static AssetInfo _humanityAsset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/biochiemicalcareersuggest/humanity.png");

	private static AssetInfo _variationqueenAsset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/biochiemicalcareersuggest/variationqueen.png");

	private static AssetInfo _useItemVariationqueenAsset = new AssetInfo("effect/biomode", "Assets/Res/Assets/effect/bioMode/biochiemicalcareersuggest/useItemVariationqueen.png");

	private static AssetInfo _mechKingMarkAsset = new AssetInfo("effect/mechkingmodel", "Assets/Res/Assets/effect/mechKingModel/mark/humanity.png");

	private static AssetInfo[] _bioChallengeHumanityAssets = new AssetInfo[3]
	{
		new AssetInfo("effect/bioevolutionchallengemode", "Assets/Res/Assets/effect/bioEvolutionChallengeMode/biochiemicalcareersuggest/1.png"),
		new AssetInfo("effect/bioevolutionchallengemode", "Assets/Res/Assets/effect/bioEvolutionChallengeMode/biochiemicalcareersuggest/2.png"),
		new AssetInfo("effect/bioevolutionchallengemode", "Assets/Res/Assets/effect/bioEvolutionChallengeMode/biochiemicalcareersuggest/3.png")
	};

	private static Dictionary<string, AssetInfo> _careerAsset = new Dictionary<string, AssetInfo>
	{
		{
			"rpg_10800002",
			new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreCase.png")
		},
		{
			"rpg_10800003",
			new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreBag.png")
		}
	};

	private static AssetInfo _queenAsset = new AssetInfo("effect/finalbiomode", "Assets/Res/Assets/effect/finalbioMode/biochiemicalcareersuggest/queen.png");

	private static AssetInfo[] _heroLvAssets = new AssetInfo[5]
	{
		new AssetInfo("effect/finalbiomode", "Assets/Res/Assets/effect/finalbioMode/biochiemicalcareersuggest/herolevel0.png"),
		new AssetInfo("effect/finalbiomode", "Assets/Res/Assets/effect/finalbioMode/biochiemicalcareersuggest/herolevel1.png"),
		new AssetInfo("effect/finalbiomode", "Assets/Res/Assets/effect/finalbioMode/biochiemicalcareersuggest/herolevel2.png"),
		new AssetInfo("effect/finalbiomode", "Assets/Res/Assets/effect/finalbioMode/biochiemicalcareersuggest/herolevel3.png"),
		new AssetInfo("effect/finalbiomode", "Assets/Res/Assets/effect/finalbioMode/biochiemicalcareersuggest/herolevel4.png")
	};

	private static AssetInfo _toushiAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/suggest/toushi.png");

	private Image _careerImage;

	private GameObject _careerImageObj;

	private RectTransform _careerImageTran;

	private int _raceType;

	private AssetInfo _currCareerSprite;

	private Vector3 _lastCareerPos;

	private bool _lastCareerActive = true;

	public override void Init(PlayerEntity PlayerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(PlayerEntity, effectGameObject, contexts, hpBar);
		_careerImage = Tran.Find("WorldSpace/CareerImage").GetComponent<Image>();
		_careerImageObj = _careerImage.gameObject;
		_careerImageTran = _careerImage.rectTransform;
		SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
		_raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
	}

	private float GetDis(Vector3 one, Vector3 two)
	{
		return Vector3.Distance(one, two);
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		string playerCareer = ((playerEntity.hasBasicInfo && playerEntity.basicInfo.CareerInfo != null) ? playerEntity.basicInfo.CareerInfo.Name : "");
		if (!PlayerEntity.hasSkill)
		{
			return;
		}
		int cameraOwnerData_Level = UiIEventCondition.Get_cameraOwnerData_Level();
		if (PlayerEntity.hasSkill && PlayerEntity.skill.Status.ContainsKey(PlayerInfoStatusConstant.DARTSRED_FLASH_BEATTACK.ID))
		{
			SetCareerImage(flag: true, ref _toushiAsset);
		}
		else if (RaceType == 29)
		{
			int lv = PlayerEntity.GetPlayerInfo().Lv;
			int team = BaseHpBar.CameraOwner.GetTeam();
			string text = "";
			string text2 = "";
			text2 = ((playerEntity.GetTeam() != team) ? "targethero" : "selfhero");
			text2 = ((5 == lv) ? (text2 + "4.png") : ((4 == lv) ? (text2 + "3.png") : ((lv < 2) ? (text2 + "1.png") : (text2 + "2.png"))));
			text = "effect/mechwarriormode";
			text2 = "Assets/Res/Assets/effect/mechwarriorMode/careersuggest/" + text2;
			AssetInfo asset = new AssetInfo(text, text2);
			SetCareerImage(flag: true, ref asset, 0.875f);
			SetActive(_careerImageObj, ref _lastCareerActive, playerEntity.IsHero());
		}
		else if (_careerAsset.ContainsKey(PlayerData.Career))
		{
			AssetInfo asset2 = _careerAsset[PlayerData.Career];
			SetCareerImage(flag: true, ref asset2, 0.875f);
		}
		else if (GameRule.IsMechKing())
		{
			if (!SetCareerImage(gameRuleContext.hasMechKingData && gameRuleContext.mechKingData.showMarks && !SameCameraTeam, ref _mechKingMarkAsset))
			{
				SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
			}
		}
		else if (GameRule.IsBighead())
		{
			if (_raceType != 120)
			{
				Vector3 one = VectorCoordConverter.SsjjToUnity(UiIEventCondition.Get_cameraOwnerData_Position());
				float dis = GetDis(one, pos);
				bool flag = _raceType == 19 || _raceType == 90 || _raceType == 35 || _raceType == 36;
				int lv2 = PlayerEntity.GetPlayerInfo().Lv;
				if (!SetCareerImage(lv2 == 5 && SameCameraTeam, ref _bigheadiAsset) && !SetCareerImage(lv2 == 5 && !SameCameraTeam && (!flag || dis < 2000f), ref _bigheadtAsset) && !SetCareerImage(lv2 == 6 && SameCameraTeam, ref _bigheadheroiAsset, -1f, playerCareer) && !SetCareerImage(lv2 == 6 && !SameCameraTeam && (!flag || dis < 2000f), ref _bigheadherotAsset, -1f, playerCareer) && !SetCareerImage(lv2 < 5 && !SameCameraTeam && cameraOwnerData_Level == 6, ref _bigheadhumanityAsset))
				{
					SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
				}
			}
			else
			{
				bool uiCareer_IsHero = UiIEventCondition.Get_uiCareer_IsHero();
				if (!SetCareerImage(uiCareer_IsHero && !SameCameraTeam, ref _bigheadhumanityAsset))
				{
					SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
				}
			}
		}
		else if (RaceType == 14)
		{
			int num = Math.Max(Math.Min(PlayerEntity.GetPlayerInfo().Lv, _heroLvAssets.Length - 1), 0);
			if (!SetCareerImage(PlayerCareerConstantUtility.IsHero(PlayerData.Career), ref _heroLvAssets[num]) && !SetCareerImage(PlayerCareerConstantUtility.IsHumanity(PlayerData.Career) && PlayerCareerConstantUtility.IsEmpress(UiIEventCondition.Get_cameraOwnerData_Career()), ref _humanityAsset) && !SetCareerImage(PlayerData.Career == "queen", ref _queenAsset))
			{
				AssetInfo asset3 = (PlayerEntity.skill.Status.ContainsKey(PlayerInfoStatusConstant.BIOTEIM_ID_814.ID) ? _useItemVariationqueenAsset : _variationqueenAsset);
				if (!SetCareerImage(PlayerData.Career == "death" || PlayerData.Career == "pandoraMonther" || PlayerData.Career == "pandoraMonther_baigu", ref asset3))
				{
					SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
				}
			}
		}
		else if (RaceType == 118)
		{
			bool flag2 = BaseHpBar.CameraOwner.GetCareer() == "queen" || BaseHpBar.CameraOwner.GetCareer() == "death" || BaseHpBar.CameraOwner.GetCareer() == "pandoraMonther" || BaseHpBar.CameraOwner.GetCareer() == "pandoraMonther_baigu";
			int num2 = Math.Max(Math.Min(PlayerEntity.GetPlayerInfo().Lv, _heroLvAssets.Length - 1), 0);
			if (!SetCareerImage(PlayerCareerConstantUtility.IsHero(PlayerData.Career), ref _heroLvAssets[num2]) && !SetCareerImage(PlayerCareerConstantUtility.IsHumanity(PlayerData.Career) && flag2, ref _humanityAsset) && !SetCareerImage(PlayerData.Career == "death" && SameCameraTeam, ref _variationqueenAsset) && !SetCareerImage(PlayerData.Career == "queen", ref _queenAsset))
			{
				SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
			}
		}
		else if (GameRule.IsBioEvolutionChallengeMode())
		{
			bool flag3 = BaseHpBar.CameraOwner.GetCareer() == "death" || BaseHpBar.CameraOwner.GetCareer() == "pandoraMonther" || BaseHpBar.CameraOwner.GetCareer() == "pandoraMonther_baigu";
			int num3 = Math.Max(Math.Min(PlayerEntity.GetPlayerInfo().Lv, _heroLvAssets.Length - 1), 0);
			Dictionary<int, int> bioCareerLevels = Contexts.sharedInstance.gameRule.bioEvolutionChallenge.BioCareerLevels;
			int value = 1;
			bioCareerLevels?.TryGetValue(PlayerData.Id, out value);
			if (value == 0)
			{
				value = 1;
			}
			if (!SetCareerImage(PlayerCareerConstantUtility.IsHero(PlayerData.Career), ref _heroLvAssets[num3]) && !SetCareerImage(PlayerCareerConstantUtility.IsHumanity(PlayerData.Career) && flag3, ref _bioChallengeHumanityAssets[value - 1]) && !SetCareerImage(PlayerData.Career == "death", ref _variationqueenAsset) && !SetCareerImage(PlayerData.Career == "pandoraMonther", ref _variationqueenAsset) && !SetCareerImage(PlayerData.Career == "pandoraMonther_baigu", ref _variationqueenAsset))
			{
				SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
			}
		}
		else if (GameRule.IsBioEvolution())
		{
			bool flag4 = BaseHpBar.CameraOwner.GetCareer() == "death" || BaseHpBar.CameraOwner.GetCareer() == "pandoraMonther" || BaseHpBar.CameraOwner.GetCareer() == "pandoraMonther_baigu";
			int num4 = Math.Max(Math.Min(PlayerEntity.GetPlayerInfo().Lv, _heroLvAssets.Length - 1), 0);
			if (!SetCareerImage(PlayerCareerConstantUtility.IsHero(PlayerData.Career), ref _heroLvAssets[num4]) && !SetCareerImage(PlayerCareerConstantUtility.IsHumanity(PlayerData.Career) && flag4, ref _humanityAsset) && !SetCareerImage(PlayerData.Career == "death", ref _variationqueenAsset) && !SetCareerImage(PlayerData.Career == "pandoraMonther", ref _variationqueenAsset) && !SetCareerImage(PlayerData.Career == "pandoraMonther_baigu", ref _variationqueenAsset))
			{
				SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
			}
		}
		else if (GameRule.IsBio3())
		{
			bool flag5 = BaseHpBar.CameraOwner.GetCareer() == "death" || BaseHpBar.CameraOwner.GetCareer() == "pandoraMonther" || BaseHpBar.CameraOwner.GetCareer() == "pandoraMonther_baigu";
			if (!SetCareerImage(PlayerCareerConstantUtility.IsHumanity(PlayerData.Career) && flag5, ref _humanityAsset) && !SetCareerImage(PlayerData.Career == "death" && SameCameraTeam, ref _variationqueenAsset))
			{
				SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
			}
		}
		else if (GameRule.IsBio() && !GameRule.IsBio2())
		{
			if (!SetCareerImage(PlayerCareerConstantUtility.IsHero(PlayerData.Career), ref _heroAsset) && !SetCareerImage(PlayerCareerConstantUtility.IsHumanity(PlayerData.Career) && PlayerCareerConstantUtility.IsEmpress(UiIEventCondition.Get_cameraOwnerData_Career()), ref _humanityAsset) && !SetCareerImage(PlayerData.Career == "death" || PlayerData.Career == "pandoraMonther" || PlayerData.Career == "pandoraMonther_baigu", ref _variationqueenAsset))
			{
				SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
			}
		}
		else if (GameRule.IsBio2() && SameCameraTeam)
		{
			if (!SetCareerImage(PlayerCareerConstantUtility.IsHero(PlayerData.Career), ref _heroAsset) && !SetCareerImage(PlayerData.Career == "death" || PlayerData.Career == "pandoraMonther" || PlayerData.Career == "pandoraMonther_baigu", ref _variationqueenAsset))
			{
				SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
			}
		}
		else if (RaceType == 100 || GameRule.IsRpgPvp())
		{
			bool flag6 = false;
			if (Contexts.sharedInstance.battleRoom.playerInfo.AllCareerDic.ContainsKey(PlayerData.Id))
			{
				foreach (string item in Contexts.sharedInstance.battleRoom.playerInfo.AllCareerDic[PlayerData.Id])
				{
					string text3 = "";
					string assetName = item;
					if (item.StartsWith("commonfree"))
					{
						text3 = "ui/commomfree";
						assetName = "Assets/Res/Assets/ui/GameGUIRes/" + item;
					}
					else if (item.StartsWith("common"))
					{
						text3 = "ui/common";
						assetName = "Assets/Res/Assets/ui/GameGUIRes/" + item;
					}
					else
					{
						text3 = "ui/" + FreeType + "model";
					}
					AssetInfo asset4 = new AssetInfo(text3, assetName);
					flag6 = SetCareerImage(flag: true, ref asset4, 0.875f);
				}
			}
			if (!flag6)
			{
				SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
			}
		}
		if (playerEntity.IsDead() && _lastCareerActive)
		{
			SetActive(_careerImageObj, ref _lastCareerActive, newActive: false);
		}
		HpBar.CareerActive = _lastCareerActive;
	}

	private bool SetCareerImage(bool flag, ref AssetInfo asset, float scale = -1f, string playerCareer = "")
	{
		if (flag)
		{
			if (_currCareerSprite != asset)
			{
				_currCareerSprite = asset;
				if (BaseHpBar.SpriteDic.ContainsKey(asset))
				{
					_careerImage.sprite = BaseHpBar.SpriteDic[asset];
					_careerImageTran.sizeDelta = ((scale > 0f) ? (_careerImage.sprite.rect.size * scale) : new Vector2(56f, 56f));
				}
				else
				{
					AssetInfo info = asset;
					float scale2 = scale;
					Loader.RetriveSpriteByRef(ref info, delegate(Sprite sprite)
					{
						_careerImage.sprite = SaveSprite(info, sprite);
						_careerImageTran.sizeDelta = ((scale2 > 0f) ? (_careerImage.sprite.rect.size * scale2) : new Vector2(56f, 56f));
					});
				}
			}
			if (RaceType == 100 && FreeType.Equals("DeformedMen"))
			{
				Vector3 position = PlayerEntity.thirdPersonUnityObjects.ThirdTran.HeadTransform.position;
				if (PlayerEntity.basicInfo.CareerInfo.Name.Equals("chicken", StringComparison.OrdinalIgnoreCase))
				{
					_careerImageTran.position = position + new Vector3(0f, 53f, 0f);
				}
				else
				{
					_careerImageTran.position = position + new Vector3(0f, 43f, 0f);
				}
			}
			else
			{
				HpBar.PosY += 28;
				SetPosition(_careerImageTran, ref _lastCareerPos, new Vector3(0f, HpBar.PosY));
			}
			HpBar.PosY += 28;
			SetActive(_careerImageObj, ref _lastCareerActive, newActive: true);
			if (playerCareer == "p3hero")
			{
				HpBar.PosY = 45;
				SetPosition(_careerImageTran, ref _lastCareerPos, new Vector3(0f, HpBar.PosY));
			}
		}
		return flag;
	}
}
