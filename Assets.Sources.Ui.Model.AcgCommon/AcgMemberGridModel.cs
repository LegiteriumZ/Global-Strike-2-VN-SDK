using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgMemberGridModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext, IPlayerScoreCell, ISetPlayerContext
{
	private AcgMemberGridViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	protected Vector2 _posCache;

	protected List<Image> _buffList;

	protected const int ONE_BUFF_IMAGE_X = 35;

	protected const int ONE_GRID_Y = 75;

	protected bool _hasSubscribed;

	private Image _image;

	public GameObject Container { get; set; }

	public int Index { get; set; }

	public IListNotify Listener { get; set; }

	protected override IUiViewModel ViewModel => _viewModel;

	public bool HasSubscribed()
	{
		return _hasSubscribed;
	}

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

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgMemberGridViewModel();
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
		_viewModel.ViewGameObject.transform.SetParent(Container.transform);
		_viewModel.AcgMemberGridShow = false;
		_viewModel.BuffObj.SetActive(value: false);
		_viewModel.DeadIconShow = false;
		_buffList = new List<Image> { _viewModel.BuffImage };
		_posCache = default(Vector2);
		Listener.AddEvent<PlayerEntity, string>("PlayerName", UiIEventCondition.Get_PlayerEntity_PlayerName, SetPlayerName, Index);
		Listener.AddEvent<PlayerEntity, long>("PlayerHp", UiIEventCondition.Get_PlayerEntity_PlayerHp, SetPlayerHp, Index);
		Listener.AddEvent<PlayerEntity, bool>("PlayerDead", UiIEventCondition.Get_PlayerEntity_IsDead, SetPlayerIsDead, Index);
		Listener.AddEvent<PlayerEntity, List<int>>("AcgBuffsAdd", UiIEventCondition.Get_PlayerEntity_AcgBuffs, SetPlayerAcgBuffsAdd, Index, 104);
		Listener.AddEvent<PlayerEntity, List<int>>("AcgBuffsRemove", UiIEventCondition.Get_PlayerEntity_AcgBuffs, SetPlayerAcgBuffsRemove, Index, 105);
		_hasSubscribed = true;
	}

	private void SetPlayerIsDead(PlayerEntity player, int idx, bool oldBool, bool newBool, ElementStatus status)
	{
		_viewModel.DeadIconShow = newBool;
	}

	private void SetPlayerName(PlayerEntity player, int idx, string oldName, string newName, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.PlayerNameString = newName;
			_viewModel.AcgMemberGridShow = true;
			base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/PlayerIcon/" + player.basicInfo.Current.Career + ".png", delegate(Sprite sprite)
			{
				_viewModel.PlayerIconImage.sprite = sprite;
			});
			_viewModel.ViewGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, Index * 75);
		}
		else
		{
			_viewModel.AcgMemberGridShow = false;
		}
	}

	private void SetPlayerHp(PlayerEntity player, int idx, long oldHp, long newHp, ElementStatus status)
	{
		_viewModel.HpBarFillamount = (float)newHp / (float)player.basicInfo.Current.MaxHp;
	}

	private void SetPlayerAcgBuffsAdd(PlayerEntity player, int idx, List<int> oldList, List<int> newList, ElementStatus status)
	{
		if (newList == null || newList.Count == 0)
		{
			return;
		}
		if (_buffList.Count >= newList.Count)
		{
			int index = newList.Count - 1;
			base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/BuffIcons/" + newList[index] + ".png", delegate(Sprite sprite)
			{
				_buffList[index].sprite = sprite;
				_buffList[index].gameObject.SetActive(value: true);
			});
			for (int i = newList.Count; i < _buffList.Count; i++)
			{
				_buffList[i].gameObject.SetActive(value: false);
			}
			return;
		}
		_image = Object.Instantiate(_viewModel.BuffObj, _viewModel.BuffListObj.transform).GetComponent<Image>();
		_buffList.Add(_image);
		int num = newList.Count - 1;
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/BuffIcons/" + newList[num] + ".png", delegate(Sprite sprite)
		{
			_image.sprite = sprite;
			_image.gameObject.SetActive(value: true);
		});
		_posCache.x = num * 35;
		_posCache.y = 0f;
		_image.transform.localPosition = _posCache;
	}

	private void SetPlayerAcgBuffsRemove(PlayerEntity player, int idx, List<int> oldList, List<int> newList, ElementStatus status)
	{
		int acgRemoveIndex = player.buff.AcgRemoveIndex;
		if (acgRemoveIndex != -1)
		{
			_image = _buffList[acgRemoveIndex];
			_image.gameObject.SetActive(value: false);
			_buffList.RemoveAt(acgRemoveIndex);
			_buffList.Add(_image);
			for (acgRemoveIndex = 0; acgRemoveIndex < _buffList.Count; acgRemoveIndex++)
			{
				_posCache.x = acgRemoveIndex * 35;
				_posCache.y = 0f;
				_image = _buffList[acgRemoveIndex];
				_image.transform.localPosition = _posCache;
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
