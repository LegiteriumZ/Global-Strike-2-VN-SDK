using System.Collections.Generic;
using Assets.Sources.Components.Time;
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
public class AcgPlayerStatusBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgPlayerStatusBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	private List<Image> _buffList;

	private Vector2 _posCache;

	private const int ONE_BUFF_IMAGE_X = 35;

	private Image _image;

	private int _index;

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgPlayerStatusBoardViewModel();
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
		_buffList = new List<Image> { _viewModel.BuffImage0 };
		_viewModel.BuffImage0.gameObject.SetActive(value: false);
		_viewModel.DeadIconShow = false;
		_posCache = default(Vector2);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetPlayerIcon, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Hp, SetHp, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_AcgShieldHp, SetShieldHp, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_IsDead, SetDead);
		NotifyManager.MakeNotifyClass(101, UiIEventCondition.Get_cameraOwnerData_AcgBuffList, SetBuffAdd, initinvoke: true);
		NotifyManager.MakeNotifyClass(102, UiIEventCondition.Get_cameraOwnerData_AcgBuffList, SetBuffRemove, initinvoke: true);
	}

	private void SetDead(bool oldBool, bool newBool)
	{
		_viewModel.DeadIconShow = newBool;
	}

	private void SetPlayerIcon(string oldStr, string newStr)
	{
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PlayerIcon/" + newStr + ".png", delegate(Sprite sprite)
		{
			_viewModel.PlayerIconImage.sprite = sprite;
		});
	}

	private void SetHp(long oldHp, long newHp)
	{
		if (_playerContext.cameraOwnerEntity != null)
		{
			_viewModel.HpBarFillamount = (float)newHp / (float)_playerContext.cameraOwnerEntity.basicInfo.Current.MaxHp;
			_viewModel.HpBarTextString = newHp.ToString();
		}
	}

	private void SetShieldHp(long oldShieldHp, long newShieldHp)
	{
		if (_playerContext.cameraOwnerEntity != null)
		{
			_viewModel.ShieldHpBarFillamount = (float)newShieldHp / (float)_playerContext.cameraOwnerEntity.basicInfo.Current.AcgShieldMaxHp;
			_viewModel.ShieldHpBarTextString = newShieldHp.ToString();
		}
	}

	private void SetBuffAdd(List<int> oldList, List<int> newList)
	{
		if (newList == null || newList.Count == 0)
		{
			return;
		}
		if (_buffList.Count >= newList.Count)
		{
			_index = newList.Count - 1;
			base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/BuffIcons/" + newList[_index] + ".png", delegate(Sprite sprite)
			{
				_buffList[_index].sprite = sprite;
				_buffList[_index].gameObject.SetActive(value: true);
			});
			for (int i = newList.Count; i < _buffList.Count; i++)
			{
				_buffList[i].gameObject.SetActive(value: false);
			}
			return;
		}
		_image = Object.Instantiate(_viewModel.BuffObj0, _viewModel.BuffListObj.transform).GetComponent<Image>();
		_buffList.Add(_image);
		_index = newList.Count - 1;
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/BuffIcons/" + newList[_index] + ".png", delegate(Sprite sprite)
		{
			_image.sprite = sprite;
			_image.gameObject.SetActive(value: true);
		});
		_posCache.x = _index * 35;
		_posCache.y = 0f;
		_image.transform.localPosition = _posCache;
	}

	private void SetBuffRemove(List<int> oldList, List<int> newList)
	{
		_index = _playerContext.cameraOwnerEntity.buff.AcgRemoveIndex;
		if (_index != -1 && _buffList != null && _index < _buffList.Count)
		{
			_image = _buffList[_index];
			_image.gameObject.SetActive(value: false);
			_buffList.RemoveAt(_index);
			_buffList.Add(_image);
			while (_index < _buffList.Count)
			{
				_posCache.x = _index * 35;
				_posCache.y = 0f;
				_image = _buffList[_index];
				_image.transform.localPosition = _posCache;
				_index++;
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
