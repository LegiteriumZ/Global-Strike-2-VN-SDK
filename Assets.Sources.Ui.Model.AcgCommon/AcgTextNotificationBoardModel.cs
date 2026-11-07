using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Sources.Utils.Timer;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgTextNotificationBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgTextNotificationBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private TimeContext _timeContext;

	private ISSJJTimer _timer;

	private Color _transparent = new Color(1f, 1f, 1f, 0f);

	private Vector2 _middleStartPos = new Vector2(-200f, 0f);

	private Vector2 _middleEndPos = new Vector2(-200f, 100f);

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
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgTextNotificationBoardViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			if (_timeContext.commonTimer.CommonTimer.TryGetValue("ACG_TEXT_NOT_LEFT", out _timer))
			{
				_viewModel.MiddleTextcolor = Color.Lerp(_transparent, Color.white, (float)_timer.LeftTime / (float)_timer.Length);
				_viewModel.MiddleAnchoredposition = Vector2.Lerp(_middleStartPos, _middleEndPos, (float)(_timer.Length - _timer.LeftTime) / (float)_timer.Length);
			}
			else
			{
				_viewModel.MiddleShow = false;
			}
		}
	}

	protected override void DoSubscribe()
	{
		_timeContext = Contexts.sharedInstance.time;
		_viewModel.BottomShow = false;
		_viewModel.MiddleShow = false;
		NotifyManager.MakeTempNotify(GetClip, SetClipNot);
		NotifyManager.MakeTempNotify(GetNotdistinguish, SetNotdistinguishNot);
	}

	private bool GetNotdistinguish()
	{
		if (_weaponContext.currentWeaponEntity == null)
		{
			return false;
		}
		if (_weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName == "acg_notdistinguish")
		{
			return _weaponContext.currentWeaponEntity.basicInfo.Data.EffectLevel == 1;
		}
		return false;
	}

	private void SetNotdistinguishNot(bool oldBool, bool newBool)
	{
		_viewModel.MiddleShow = true;
		SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACG_TEXT_NOT_LEFT", new SSJJTimer(1500));
		_viewModel.MiddleString = (newBool ? ScriptLocalization.Get("ACG_HAVING_NOTDISTINGUISH") : ScriptLocalization.Get("ACG_NOT_HAVING_NOTDISTINGUISH"));
	}

	private bool GetClip()
	{
		if (_weaponContext.currentWeaponEntity == null)
		{
			return false;
		}
		if (_weaponContext.currentWeaponEntity.basicInfo.Data.MaxClip > 0)
		{
			return _weaponContext.currentWeaponEntity.basicInfo.Data.Clip > 0;
		}
		return false;
	}

	private void SetClipNot(bool oldBool, bool newBool)
	{
		_viewModel.BottomShow = !newBool;
		_viewModel.BottomString = ScriptLocalization.Get("ACG_NO_CLIP");
	}
}
