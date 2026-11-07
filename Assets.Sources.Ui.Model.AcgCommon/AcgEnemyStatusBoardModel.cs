using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Components.GameRule.rpg;
using Assets.Sources.Components.Time;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgEnemyStatusBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgEnemyStatusBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	private HpProgressDataComponent _hpProgressData;

	private AcgAttributesTable _acgAttributesTable;

	private PlayerEntity _player;

	private Vector2 _posCache;

	private Vector2 _sizeCache;

	private List<Image> _buffList;

	private const int ONE_NUMBER = 11;

	private const int ONE_CHINESE_CHARACTER = 20;

	private const string LONG = "Long";

	private const string MEDIUM = "Medium";

	private const string SHORT = "Short";

	private const int ELITE_MAX_BUFFS_ONE_LINE = 12;

	private const int BOSS_MAX_BUFFS_ONE_LINE = 16;

	private const int ONE_BUFF_IMAGE_X = 35;

	private const int ONE_BUFF_IMAGE_Y = -40;

	private const int HP_BAR_POS_OFFSET_X = 25;

	private const int COMMON_SHIELD_BAR_WIDTH = 330;

	private const int ELITE_SHIELD_BAR_WIDTH = 470;

	private const int BOSS_SHIELD_BAR_WIDTH = 650;

	private const int SHIELD_BAR_HEIGHT = 6;

	private int _index;

	private Image _image;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		_playerContext = Contexts.sharedInstance.player;
		_viewModel.ShowShow = false;
		_acgAttributesTable = AcgInfoLoader.Instance.AcgAttributesTable;
		_posCache = default(Vector2);
		_sizeCache = default(Vector2);
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgEnemyStatusBoardViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		_hpProgressData = _gameRuleContext.hpProgressData;
		_buffList = new List<Image> { _viewModel.BuffImage0 };
		_viewModel.BuffObj0.SetActive(value: false);
		_viewModel.ShowShow = false;
		NotifyManager.MakeNotify(100, UiIEventCondition.Get_hpProgressData_AcgTargetId, SetTarget);
		NotifyManager.MakeNotify(106, GetAddBuff, SetAddBuff, initinvoke: true);
		NotifyManager.MakeNotify(107, GetRemoveBuff, SetRemoveBuff, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_AcgTargetHpPercent, SetHp);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_AcgTargetHpDamagePercent, SetDamageHp);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_hpProgressData_AcgTargetShieldHpPercent, SetShieldHp);
	}

	private void SetTarget(int oldId, int newId)
	{
		if (newId == 0 || !_gameRuleContext.hasHpProgressData)
		{
			_viewModel.ShowShow = false;
			return;
		}
		IUiResourcesLoader loader = base.Loader;
		int acgTarget = (int)_hpProgressData.AcgTarget;
		loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/EnemyStatusBoard/EnemyIconBorder" + acgTarget + ".png", delegate(Sprite sprite)
		{
			_viewModel.IconBorderImage.sprite = sprite;
		});
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/EnemyIcons/" + _hpProgressData.AcgTargetCareer + ".png", delegate(Sprite sprite)
		{
			_viewModel.EnemyIconImage.sprite = sprite;
		});
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/ElementIcons/" + _hpProgressData.AcgTargetElement + ".png", delegate(Sprite sprite)
		{
			_viewModel.ElementIconImage.sprite = sprite;
		});
		_viewModel.EnemyNameString = "Lv. " + _hpProgressData.AcgTargetLevel + " " + _hpProgressData.AcgTargetName;
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/EnemyStatusBoard/ShieldBar" + _hpProgressData.AcgTargetElement + ".png", delegate(Sprite sprite)
		{
			_viewModel.ShieldBarImage.sprite = sprite;
			_sizeCache.x = ((_hpProgressData.AcgTarget == HpProgressDataComponent.AcgTargetType.Common) ? 330 : ((_hpProgressData.AcgTarget == HpProgressDataComponent.AcgTargetType.Elite) ? 470 : 650));
			_sizeCache.y = 6f;
			_viewModel.ShieldBarSize = _sizeCache;
			_viewModel.ShieldBarBaseSize = _sizeCache;
		});
		if (_hpProgressData.AcgTargetName != null)
		{
			_posCache.x = _hpProgressData.AcgTargetLevel.ToString().Length * 11 + _hpProgressData.AcgTargetName.Length * 20;
			_posCache.y = 0f;
			_viewModel.EnemyAttributesAnchoredposition = _posCache;
			_viewModel.EnemyAttributesString = "";
			if (_hpProgressData.AcgTarget == HpProgressDataComponent.AcgTargetType.Boss)
			{
				_viewModel.EnemyAttributesFontsize = 20;
				UpdateAttributesString(isBoss: true);
				SetHpBarImage("Long");
			}
			else if (_hpProgressData.AcgTarget == HpProgressDataComponent.AcgTargetType.Elite)
			{
				_viewModel.EnemyAttributesFontsize = 18;
				UpdateAttributesString(isBoss: false);
				SetHpBarImage("Medium");
			}
			else
			{
				_viewModel.EnemyAttributesFontsize = 18;
				UpdateAttributesString(isBoss: false);
				SetHpBarImage("Short");
			}
			_viewModel.ShowShow = true;
		}
	}

	private void SetHpBarImage(string type)
	{
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/EnemyStatusBoard/" + type + "WhiteBar.png", delegate(Sprite sprite)
		{
			_viewModel.HpWhiteBarImage.sprite = sprite;
			_viewModel.HpBarMaskImage.sprite = sprite;
			_viewModel.HpWhiteBarNtvsize();
			_viewModel.HpBarMaskNtvsize();
		});
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/EnemyStatusBoard/" + type + "GrayBar.png", delegate(Sprite sprite)
		{
			_viewModel.HpBarBaseImage.sprite = sprite;
			_viewModel.HpBarBaseNtvsize();
		});
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/EnemyStatusBoard/" + type + "RedBar.png", delegate(Sprite sprite)
		{
			_viewModel.HpRedBarImage.sprite = sprite;
			_viewModel.HpRedBarNtvsize();
		});
	}

	private void UpdateAttributesString(bool isBoss)
	{
		if (_hpProgressData.AcgTargetAttributes == null)
		{
			return;
		}
		for (int i = 0; i < _hpProgressData.AcgTargetAttributes.Count && _hpProgressData.AcgTargetAttributes[i] != 0; i++)
		{
			if (isBoss && i == 4)
			{
				_viewModel.EnemyAttributesString += "\n";
			}
			_viewModel.EnemyAttributesString += _acgAttributesTable.GetRowList()[_hpProgressData.AcgTargetAttributes[i] - 1].Name;
		}
	}

	private int GetAddBuff()
	{
		return -1;
	}

	private int GetRemoveBuff()
	{
		return -1;
	}

	private void SetAddBuff(int oldId, int newId)
	{
		_player = _playerContext.GetEntityWithEntityId(_hpProgressData.AcgTargetId);
		if (_player == null || !_player.hasBuff || _player.buff.AcgBuffs.Count == 0)
		{
			return;
		}
		_index = _player.buff.AcgBuffs.Count - 1;
		if (_buffList.Count >= _player.buff.AcgBuffs.Count)
		{
			base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/BuffIcons/" + _player.buff.AcgBuffs[_index] + ".png", delegate(Sprite sprite)
			{
				_buffList[_index].sprite = sprite;
				_buffList[_index].gameObject.SetActive(value: true);
			});
			return;
		}
		_image = Object.Instantiate(_viewModel.BuffObj0, _viewModel.BuffListObj.transform).GetComponent<Image>();
		_buffList.Add(_image);
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/BuffIcons/" + _player.buff.AcgBuffs[_index] + ".png", delegate(Sprite sprite)
		{
			_image.sprite = sprite;
			_image.gameObject.SetActive(value: true);
		});
		GetPosCache();
		_image.transform.localPosition = _posCache;
	}

	private void SetRemoveBuff(int oldId, int newId)
	{
		_player = _playerContext.GetEntityWithEntityId(_hpProgressData.AcgTargetId);
		if (_player != null && _player.hasBuff)
		{
			_image = _buffList[_player.buff.AcgRemoveIndex];
			_image.gameObject.SetActive(value: false);
			_buffList.RemoveAt(_player.buff.AcgRemoveIndex);
			_buffList.Add(_image);
			for (_index = _player.buff.AcgRemoveIndex; _index < _buffList.Count; _index++)
			{
				GetPosCache();
				_image = _buffList[_index];
				_image.transform.localPosition = _posCache;
			}
		}
	}

	private void GetPosCache()
	{
		if (_hpProgressData.AcgTarget == HpProgressDataComponent.AcgTargetType.Common)
		{
			_posCache.x = _index * 35;
			_posCache.y = 0f;
		}
		else if (_hpProgressData.AcgTarget == HpProgressDataComponent.AcgTargetType.Elite)
		{
			_posCache.x = _index % 12 * 35;
			_posCache.y = (_index + 1) / 12 * -40;
		}
		else if (_hpProgressData.AcgTarget == HpProgressDataComponent.AcgTargetType.Boss)
		{
			_posCache.x = _index % 16 * 35;
			_posCache.y = (_index + 1) / 16 * -40;
		}
	}

	private void SetHp(float oldPercent, float newPercent)
	{
		_posCache.x = (0f - (_viewModel.HpWhiteBarImage.rectTransform.sizeDelta.x - 25f)) * (1f - newPercent);
		_posCache.y = 0f;
		_viewModel.HpWhiteBarAnchoredposition = _posCache;
	}

	private void SetDamageHp(float oldPercent, float newPercent)
	{
		_posCache.x = (0f - (_viewModel.HpRedBarImage.rectTransform.sizeDelta.x - 25f)) * (1f - newPercent);
		_posCache.y = 0f;
		_viewModel.HpRedBarAnchoredposition = _posCache;
	}

	private void SetShieldHp(float oldPercent, float newPercent)
	{
		_viewModel.ShieldBarFillamount = newPercent;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
