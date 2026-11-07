using System.Collections.Generic;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Guofengmodel;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Guofengmodel;

[GameUiTest]
public class Guofengmodel_timeModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private Guofengmodel_timeViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private ActiveChip _centerActiveChip = new ActiveChip();

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
		_viewModel = new Guofengmodel_timeViewModel();
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
		base.DoSubscribe();
		_viewModel.numString = "0";
		_viewModel.boxNumShow = false;
		_viewModel.boxhpShow = false;
		_viewModel.f_keyShow = false;
		NotifyManager.MakeNotifyClass(156, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -141013)
			{
				_viewModel.numString = tipsEvent[i].Time1.ToString();
				_viewModel.boxhp_pFillamount = (float)tipsEvent[i].Time1 * 1f / (float)tipsEvent[i].Time2;
				_viewModel.boxhpShow = tipsEvent[i].Show;
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -141014)
			{
				_viewModel.boxNm_pFillamount = (float)tipsEvent[i].Time1 * 1f / (float)tipsEvent[i].Time2;
				_viewModel.boxNumShow = tipsEvent[i].Show;
				if (tipsEvent[i].Time3 > 0)
				{
					_viewModel.lockIconShow = true;
					base.Loader.RetriveSprite("ui/guofengmodel", "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/Lock.png", delegate(Sprite sprite)
					{
						_viewModel.boxNm_pSprite = sprite;
					});
				}
				else
				{
					_viewModel.lockIconShow = false;
					base.Loader.RetriveSprite("ui/guofengmodel", "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/BoxOpenTime.png", delegate(Sprite sprite)
					{
						_viewModel.boxNm_pSprite = sprite;
					});
				}
				if (_viewModel.boxNm_pFillamount >= 0.99f)
				{
					base.Loader.RetriveSprite("ui/guofengmodel", "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/box1.png", delegate(Sprite sprite)
					{
						_viewModel.boxSprite1 = sprite;
						_viewModel.boxSprite2 = sprite;
						_viewModel.boxSprite3 = sprite;
					});
				}
				else if (_viewModel.boxNm_pFillamount > 0.75f)
				{
					base.Loader.RetriveSprite("ui/guofengmodel", "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/box1.png", delegate(Sprite sprite)
					{
						_viewModel.boxSprite1 = sprite;
						_viewModel.boxSprite2 = sprite;
					});
					base.Loader.RetriveSprite("ui/guofengmodel", "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/box0.png", delegate(Sprite sprite)
					{
						_viewModel.boxSprite3 = sprite;
					});
				}
				else if (_viewModel.boxNm_pFillamount > 0.5f)
				{
					base.Loader.RetriveSprite("ui/guofengmodel", "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/box1.png", delegate(Sprite sprite)
					{
						_viewModel.boxSprite1 = sprite;
					});
					base.Loader.RetriveSprite("ui/guofengmodel", "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/box0.png", delegate(Sprite sprite)
					{
						_viewModel.boxSprite2 = sprite;
						_viewModel.boxSprite3 = sprite;
					});
				}
				else
				{
					base.Loader.RetriveSprite("ui/guofengmodel", "Assets/Res/Assets/ui/GameGUIRes/guofengmodel/box0.png", delegate(Sprite sprite)
					{
						_viewModel.boxSprite1 = sprite;
						_viewModel.boxSprite2 = sprite;
						_viewModel.boxSprite3 = sprite;
					});
				}
				tipsEvent.RemoveAt(i);
				i--;
			}
			else if (tipsEvent[i].TypeId == -141015)
			{
				_viewModel.f_keyShow = tipsEvent[i].Show;
				_centerActiveChip.Time = tipsEvent[i].Time2 - tipsEvent[i].Time1;
				_centerActiveChip.maxTime = tipsEvent[i].Time2;
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		if (_centerActiveChip.maxTime == 0 && _viewModel.f_keyShow)
		{
			_viewModel.f_key_pFillamount = 0f;
			return;
		}
		_centerActiveChip.Update(time);
		_viewModel.f_key_pFillamount = 1f - (float)_centerActiveChip.Time * 1f / (float)_centerActiveChip.maxTime;
	}
}
