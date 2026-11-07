using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class SceneBuffMessageModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private SceneBuffMessageViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private MessageContext _messageContext;

	private ActiveChip _timer;

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new SceneBuffMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_messageContext = Contexts.sharedInstance.message;
		base.DoSubscribe();
		NotifyManager.MakeNotify(85, GetSpriteIndex, SetSprite);
	}

	private int GetSpriteIndex()
	{
		return 0;
	}

	private void SetSprite(int arg1, int arg2)
	{
		base.Loader.RetriveSprite("ui/halfloadedres/scenebuffermessage", _messageContext.sceneBuffMessageData.messageIndex + ".png", delegate(Sprite sprite)
		{
			_viewModel.MessageSprite = sprite;
		});
		if (_messageContext.sceneBuffMessageData.Args.Count > 0)
		{
			_viewModel.PlayerNameString = _messageContext.sceneBuffMessageData.Args[0];
		}
		_timer.Time = 3000;
	}

	private void InitChips()
	{
		_timer = new ActiveChip();
		_timer.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _timer.Update(_timeComponent);
	}
}
