using System.Collections.Generic;
using Assets.Sources.Components.GameRule.rpg;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using SSJJAsset.Asset;
using UnityEngine;
using UnityEngine.UI;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerHpBar.SubRender;

public class HpBarHp : BaseHpBar
{
	private static readonly HashSet<string> CareerNoHp = new HashSet<string>
	{
		"rpg_tank1", "rpg_jetpack", "rpg_10500001", "rpg_10800002", "rpg_10800003", "rpg_empty_1", "rpg_10300307", "rpg_10003101", "rpg_10200701", "rpg_10100401",
		"rpg_10003125", "rpg_10003106", "rpg_10004001", "rpg_10005111", "rpg_10005112", "rpg_10005113", "rpg_10005114", "rpg_10005115", "rpg_10005116", "rpg_10005119",
		"rpg_10005120", "qiangling_yiliya"
	};

	private static HashSet<int> _showHpMode = new HashSet<int> { 126, 90, 19, 35, 36, 2019, 33, 120, 29 };

	private Image _hpBackImage;

	private RectTransform _hpBackTran;

	private GameObject _hpBackObj;

	private Image _hpProgress;

	private Image _shieldBackImage;

	private Image _critDef;

	private Image _critRateDef;

	private RectTransform _shieldBackTran;

	private GameObject _shieldBackObj;

	private Image _shieldProgress;

	private Image _superShieldProgress;

	private static AssetInfo _greenAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/hp/green.png");

	private static AssetInfo _yellowAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/hp/yellow.png");

	private static AssetInfo _redAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/hp/red.png");

	private new static Dictionary<AssetInfo, Sprite> SpriteDic = new Dictionary<AssetInfo, Sprite>();

	private AssetInfo _currHpSprite;

	private Vector3 _lastHpBackPos;

	private Vector3 _lastShieldBackPos;

	private bool _lastHpBackActive = true;

	private bool _lastShieldBackActive = true;

	private bool _critDefActive = true;

	private bool _critRateDefActive = true;

	private long _currHp;

	private long _currMaxHp;

	private long _currShield = -1L;

	private long _currSuperShield = -1L;

	private bool _hpLoaded;

	private bool _isShowHpRaceType;

	private bool _isShowHpCareer;

	private bool _isShowTargetHp;

	private bool _showShield;

	private bool _seeEnemyChanged;

	private bool _seeEnemyLast;

	public HpProgressDataComponent HpProgressData;

	public override void Init(PlayerEntity playerEntity, GameObject effectGameObject, Contexts contexts, PlayerHpBarRender hpBar)
	{
		base.Init(playerEntity, effectGameObject, contexts, hpBar);
		_hpBackImage = Tran.Find("WorldSpace/HpBack").GetComponent<Image>();
		_hpBackTran = _hpBackImage.rectTransform;
		_hpBackObj = _hpBackTran.gameObject;
		SetActive(_hpBackObj, ref _lastHpBackActive, newActive: false);
		_hpProgress = Tran.Find("WorldSpace/HpBack/HpProgress").GetComponent<Image>();
		_critDef = Tran.Find("WorldSpace/HpBack/critDef").GetComponent<Image>();
		_critRateDef = Tran.Find("WorldSpace/HpBack/critRateDef").GetComponent<Image>();
		SetActive(_critDef.gameObject, ref _critDefActive, newActive: false);
		SetActive(_critRateDef.gameObject, ref _critRateDefActive, newActive: false);
		_shieldBackImage = Tran.Find("WorldSpace/ShieldBack").GetComponent<Image>();
		_shieldBackTran = _shieldBackImage.rectTransform;
		_shieldBackObj = _shieldBackTran.gameObject;
		SetActive(_shieldBackObj, ref _lastShieldBackActive, newActive: false);
		_shieldProgress = Tran.Find("WorldSpace/ShieldBack/ShieldProgress").GetComponent<Image>();
		_superShieldProgress = Tran.Find("WorldSpace/ShieldBack/SuperShieldProgress").GetComponent<Image>();
		_isShowHpRaceType = GameRule.IsPve() || _showHpMode.Contains(RaceType) || RuleUtilty.IsTanLanRun(RaceType) || FreeType == "pushcar";
		_isShowHpCareer = !CareerNoHp.Contains(playerEntity.GetCareer()) && !playerEntity.GetCareer().Contains("qiangling");
		_isShowTargetHp = GameRule.IsShowTargetHp();
		_showShield = GameRule.IsRpg() && (!playerEntity.IsBot() || RaceType == 15006 || playerEntity.basicInfo.Current.IsJiqiren) && PlayerCareerConstantUtility.IsShowShield(playerEntity.GetCareer());
		HpProgressData = contexts.gameRule.hpProgressData;
		_seeEnemyChanged = false;
		_seeEnemyLast = false;
	}

	public override void Update(PlayerEntity playerEntity, Vector3 pos)
	{
		base.Update(playerEntity, pos);
		bool flag = BaseHpBar.CameraOwner != null && BaseHpBar.CameraOwner.hasSkill && BaseHpBar.CameraOwner.HasStatus(PlayerInfoStatusConstant.LIGHTHING_SEE_ALL.ID);
		_seeEnemyChanged = ((_seeEnemyLast && !flag) ? true : false);
		_seeEnemyLast = flag;
		if (_seeEnemyChanged)
		{
			SetActive(_hpBackObj, ref _lastHpBackActive, newActive: false, force: true);
			SetActive(_shieldBackObj, ref _lastHpBackActive, newActive: false, force: true);
			_seeEnemyChanged = false;
		}
		else if (!SameCameraTeam && (RaceType != 29 || (RaceType == 29 && !playerEntity.IsHero())) && (HpProgressData.BotId != PlayerData.Id || !_isShowTargetHp) && !flag)
		{
			SetActive(_hpBackObj, ref _lastHpBackActive, newActive: false);
			SetActive(_shieldBackObj, ref _lastShieldBackActive, newActive: false);
		}
		else
		{
			if ((!_isShowHpRaceType && !(!SameCameraTeam && flag)) || !_isShowHpCareer)
			{
				return;
			}
			HpBar.PosY += 5;
			SetPosition(_hpBackTran, ref _lastHpBackPos, new Vector3(0f, HpBar.PosY));
			HpBar.PosY += 5;
			bool flag2 = _showShield && SameCameraTeam;
			if (flag2)
			{
				HpBar.PosY += 3;
				SetPosition(_shieldBackTran, ref _lastShieldBackPos, new Vector3(0f, HpBar.PosY));
				HpBar.PosY += 3;
			}
			if (PlayerData.IsDead)
			{
				SetActive(_hpBackObj, ref _lastHpBackActive, newActive: false);
				SetActive(_shieldBackObj, ref _lastShieldBackActive, newActive: false);
				return;
			}
			SetActive(_hpBackObj, ref _lastHpBackActive, newActive: true);
			SetActive(_shieldBackObj, ref _lastShieldBackActive, flag2);
			if (!_hpLoaded)
			{
				_hpLoaded = true;
				Loader.RetriveSprite("effect/common", "Assets/Res/Assets/effect/common/hp/back.png", delegate(Sprite sprite)
				{
					_hpBackImage.sprite = sprite;
				});
				Loader.RetriveSprite("effect/rpgcommon", "Assets/Res/Assets/effect/rpgcommon/shiled/shiledBg.png", delegate(Sprite sprite)
				{
					_shieldBackImage.sprite = sprite;
				});
				Loader.RetriveSprite("effect/rpgcommon", "Assets/Res/Assets/effect/rpgcommon/shiled/shiled.png", delegate(Sprite sprite)
				{
					_shieldProgress.sprite = sprite;
				});
				Loader.RetriveSprite("effect/rpgcommon", "Assets/Res/Assets/effect/rpgcommon/shiled/superShield.png", delegate(Sprite sprite)
				{
					_superShieldProgress.sprite = sprite;
				});
			}
			if (PlayerData.Hp != _currHp || PlayerData.MaxHp != _currMaxHp)
			{
				_currHp = PlayerData.Hp;
				_currMaxHp = PlayerData.MaxHp;
				float num = ((PlayerData.MaxHp > 0) ? ((float)PlayerData.Hp / (float)PlayerData.MaxHp) : 0f);
				if (num > 0.66f)
				{
					SetHpSprite(ref _greenAsset);
				}
				else if (num > 0.33f)
				{
					SetHpSprite(ref _yellowAsset);
				}
				else
				{
					SetHpSprite(ref _redAsset);
				}
				_hpProgress.fillAmount = num;
				_hpProgress.gameObject.SetObjectActive(!Mathf.Approximately(num, 0f));
			}
			if (flag2)
			{
				if (PlayerData.ShieldHp != _currShield)
				{
					_currShield = PlayerData.ShieldHp;
					float num2 = ((PlayerData.ShieldMaxHp > 0) ? ((float)PlayerData.ShieldHp / (float)PlayerData.ShieldMaxHp) : 0f);
					_shieldProgress.fillAmount = num2;
					_shieldProgress.gameObject.SetObjectActive(!Mathf.Approximately(num2, 0f));
				}
				if (PlayerData.SuperShieldHp != _currSuperShield)
				{
					_currSuperShield = PlayerData.SuperShieldHp;
					float num3 = ((PlayerData.SuperShieldMaxHp > 0) ? ((float)PlayerData.SuperShieldHp / (float)PlayerData.SuperShieldMaxHp) : 0f);
					_superShieldProgress.fillAmount = num3;
					_superShieldProgress.gameObject.SetObjectActive(!Mathf.Approximately(num3, 0f));
				}
			}
			UpdateImageIndex();
		}
	}

	private void SetHpSprite(ref AssetInfo asset)
	{
		if (!(_currHpSprite != asset))
		{
			return;
		}
		_currHpSprite = asset;
		if (SpriteDic.ContainsKey(asset))
		{
			_hpProgress.sprite = SpriteDic[asset];
			return;
		}
		AssetInfo info = asset;
		Loader.RetriveSpriteByRef(ref info, delegate(Sprite sprite)
		{
			_hpProgress.sprite = SaveSprite(info, sprite);
		});
	}

	protected void UpdateImageIndex()
	{
		int critDefTextureName = GetCritDefTextureName(PlayerData.CritDef);
		int critRateDefTextureName = GetCritRateDefTextureName(PlayerData.CritRateDef);
		if (critDefTextureName >= 0 && RuleUtilty.IsRpgPvp(RaceType) && !PlayerData.IsBot)
		{
			Loader.RetriveSprite("effect/common", $"Assets/Res/Assets/effect/common/resistance/critDef{critDefTextureName}.png", delegate(Sprite sprite)
			{
				_critDef.sprite = sprite;
			});
			SetActive(_critDef.gameObject, ref _critDefActive, newActive: true);
		}
		else
		{
			SetActive(_critDef.gameObject, ref _critDefActive, newActive: false);
		}
		if (critRateDefTextureName >= 0 && RuleUtilty.IsRpgPvp(RaceType) && !PlayerData.IsBot)
		{
			Loader.RetriveSprite("effect/common", $"Assets/Res/Assets/effect/common/resistance/critRateDef{critRateDefTextureName}.png", delegate(Sprite sprite)
			{
				_critRateDef.sprite = sprite;
			});
			SetActive(_critRateDef.gameObject, ref _critRateDefActive, newActive: true);
		}
		else
		{
			SetActive(_critRateDef.gameObject, ref _critRateDefActive, newActive: false);
		}
	}

	private int GetCritDefTextureName(float critDef)
	{
		if (0f == critDef)
		{
			return -1;
		}
		if (critDef <= 0.5f)
		{
			return 1;
		}
		if (critDef <= 1f)
		{
			return 2;
		}
		if (critDef <= 2f)
		{
			return 3;
		}
		return 4;
	}

	private int GetCritRateDefTextureName(float critRateDef)
	{
		if (0f == critRateDef)
		{
			return -1;
		}
		if (critRateDef <= 1f)
		{
			return 1;
		}
		if (critRateDef <= 3f)
		{
			return 2;
		}
		if (critRateDef <= 6f)
		{
			return 3;
		}
		return 4;
	}
}
