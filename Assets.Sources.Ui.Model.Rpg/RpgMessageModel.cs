using System;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Constant;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Logger;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgMessageModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetGameRuleContext
{
	protected RpgMessageViewModel _viewModel;

	protected GameMessageTable _config;

	protected PlayerContext _playerContext;

	private HashSet<string> _modeName;

	private GameMessageTable.Row[] _currRows;

	private Dictionary<int, GameMessageTable.Row> _messageDic = new Dictionary<int, GameMessageTable.Row>();

	private ActiveChip _rpgMessageActiveChip1 = new ActiveChip();

	private ActiveChip _rpgMessageActiveChip2 = new ActiveChip();

	private ActiveChip _rpgMessageActiveChip3 = new ActiveChip();

	private ActiveChip _rpgMessageActiveChip4 = new ActiveChip();

	private ActiveChip _rpgMessageActiveChip5 = new ActiveChip();

	private ActiveChip[] _activeChips;

	private ScaleChip _rpgMessageScaleChip1 = new ScaleChip();

	private ScaleChip _rpgMessageScaleChip2 = new ScaleChip();

	private ScaleChip _rpgMessageScaleChip3 = new ScaleChip();

	private ScaleChip _rpgMessageScaleChip4 = new ScaleChip();

	private ScaleChip _rpgMessageScaleChip5 = new ScaleChip();

	private ScaleChip[] _scaleChips;

	private readonly bool[] _messageShow = new bool[6];

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new RpgMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			UpdateNumber();
		}
	}

	private void UpdateNumber()
	{
		for (int i = 1; i <= _currRows.Length && i <= 5; i++)
		{
			if (!_messageShow[i])
			{
				continue;
			}
			GameMessageTable.Row row = _currRows[i];
			if (row != null)
			{
				if (row.CounterType == GameMessageTable.CounterTypeEnum.Second || row.CounterType == GameMessageTable.CounterTypeEnum.RealSecond)
				{
					_viewModel.SetCountAString(i, StringCache.IntToString(_activeChips[i].Time / 1000));
				}
				else if (row.CounterType == GameMessageTable.CounterTypeEnum.MinuteSecond)
				{
					_viewModel.SetCountAString(i, StringCache.IntToString(_activeChips[i].Time / 60000));
					_viewModel.SetCountBString(i, StringCache.IntToString(_activeChips[i].Time % 60000 / 1000));
				}
				else if (row.CounterType == GameMessageTable.CounterTypeEnum.Msm)
				{
					_viewModel.SetCountAString(i, StringCache.IntToString(_activeChips[i].Time / 60000));
					_viewModel.SetCountBString(i, StringCache.IntToString(_activeChips[i].Time % 60000 / 1000));
					_viewModel.SetCountCString(i, StringCache.IntToString(_activeChips[i].Time % 1000));
				}
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_config = GameMessageLoader.Instance.Table;
		_currRows = new GameMessageTable.Row[6];
		if (_gameRuleContext.currentRule.Rule.IsRpgGroup())
		{
			_modeName = new HashSet<string> { "common", "rpgGroupModel", "rpgModel" };
		}
		else if (RuleUtilty.isHuntTre(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			_modeName = new HashSet<string> { "common", "guofengmodel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgDuel())
		{
			_modeName = new HashSet<string> { "common", "rpgDuelModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgKillOther())
		{
			_modeName = new HashSet<string> { "common", "rpgKillOtherModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgServivalPvp())
		{
			_modeName = new HashSet<string> { "common", "rpgSurvivalPvpModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgSpeed())
		{
			_modeName = new HashSet<string> { "common", "rpgModel", "rpgSpeedModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgAnnihilationModel())
		{
			_modeName = new HashSet<string> { "common", "rpgAnnihilationModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgDanrenMineMode())
		{
			_modeName = new HashSet<string> { "common", "rpgModel", "rpgDanrenMineModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgSpecialMode())
		{
			_modeName = new HashSet<string> { "common", "rpgModel", "rpgSpecialModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgHolidayMode())
		{
			_modeName = new HashSet<string> { "common", "rpgModel", "rpgHolidayModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgTowerMode())
		{
			_modeName = new HashSet<string> { "common", "rpgModel", "rpgTowerModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsGuoQingRace())
		{
			_modeName = new HashSet<string> { "common", "rpgModel", "rpgGuoQingModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsRpgTeamRace())
		{
			_modeName = new HashSet<string> { "common", "rpgTeamModel", "rpgModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsGeneralPve() && !_gameRuleContext.currentRule.Rule.IsNewRpgPvp())
		{
			_modeName = new HashSet<string> { "common", "rpgModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsJump())
		{
			_modeName = new HashSet<string> { "common", "jumpModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsCrazeMode())
		{
			_modeName = new HashSet<string> { "common", "crazeModel" };
		}
		else if (_gameRuleContext.currentRule.Rule.IsTDMode())
		{
			_modeName = new HashSet<string> { "common", "towerDefenseModel" };
		}
		if (_gameRuleContext.currentRule.Rule.IsRpg())
		{
			if (_modeName != null)
			{
				_modeName.Add("halfLoadedRes/playerMessage");
				_modeName.Add("halfLoadedRes/skatingMechaModel");
			}
			else
			{
				_modeName = new HashSet<string> { "halfLoadedRes/playerMessage" };
			}
		}
		_viewModel.MessageShow1 = false;
		_viewModel.MessageShow2 = false;
		_viewModel.MessageShow3 = false;
		_viewModel.MessageShow4 = false;
		_viewModel.MessageShow5 = false;
		NotifyManager.MakeNotify(13, UiIEventCondition.Get_gameMessageData_Changed, SetChanged, initinvoke: true);
		NotifyManager.MakeNotifyClass(14, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null || !_playerContext.isMyPlayer)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			int typeId = tipsEvent[i].TypeId;
			int num = 0;
			switch (typeId)
			{
			case -12601:
			case -2523:
			case -2522:
			case -2521:
			case -2520:
			case -2519:
				num = (int)(TimeUtility.UnixTimeNow() - Contexts.sharedInstance.battleRoom.sectionTime.LoadingSuccessTime) + 1000;
				break;
			case -12602:
			case -2526:
			case -2525:
			case -2524:
				if (!_playerContext.myPlayerEntity.basicInfo.Current.CanChangeBag)
				{
					continue;
				}
				num = (int)(TimeUtility.UnixTimeNow() - Contexts.sharedInstance.battleRoom.sectionTime.LoadingSuccessTime) + 1000;
				break;
			}
			ShowMessage(typeId, tipsEvent[i].Time1 - num, tipsEvent[i].Time2, tipsEvent[i].Str1, tipsEvent[i].Str2, !tipsEvent[i].ShowSpecified || tipsEvent[i].Show);
		}
		tipsEvent.Clear();
	}

	private void SetChanged(bool ov, bool changed)
	{
		if (!changed)
		{
			return;
		}
		if (_gameRuleContext.currentRule.Rule.IsJump())
		{
			SimpleProto gameMessageData_SimpleProto = UiIEventCondition.Get_gameMessageData_SimpleProto();
			if (gameMessageData_SimpleProto != null && gameMessageData_SimpleProto.Key == 1)
			{
				int type = gameMessageData_SimpleProto.Ins[1] % 1000 + 1000;
				int time = ((gameMessageData_SimpleProto.Ins.Count > 2) ? gameMessageData_SimpleProto.Ins[2] : 0);
				ShowMessage(type, time, 0, "", "");
			}
		}
		else
		{
			GameMessageData gameMessageData_MessageData = UiIEventCondition.Get_gameMessageData_MessageData();
			if (gameMessageData_MessageData != null)
			{
				int type2 = (int)gameMessageData_MessageData.Type;
				int time2 = gameMessageData_MessageData.Time;
				ShowMessage(type2, time2, 0, "", "");
			}
		}
	}

	protected void ShowMessage(int type, int time1, int time2, string text1, string text2, bool visible = true)
	{
		if (_modeName == null)
		{
			return;
		}
		if (!_messageDic.ContainsKey(type))
		{
			try
			{
				_messageDic[type] = _config.FindAll_Type(type).Find((GameMessageTable.Row x) => _modeName.Contains(x.Mode));
			}
			catch (NullReferenceException ex)
			{
				this.LogErrorFormat("TipsType: {0} \n{1}\n{2}", type, _modeName.Count, ex.Message);
			}
		}
		GameMessageTable.Row row = _messageDic[type];
		if (row == null)
		{
			return;
		}
		int index = (int)(row.Layer + 1);
		if (!visible && (_currRows[index] == null || _currRows[index].Type != type))
		{
			_viewModel.SetMessageShow(index, value: false);
		}
		else
		{
			if (_viewModel.GetMessageShow(index) && _currRows[index] != null && _currRows[index].Priority > row.Priority)
			{
				return;
			}
			_currRows[index] = row;
			_activeChips[index].Time = (visible ? row.Time : 0);
			if (!string.IsNullOrEmpty(row.Image))
			{
				if (row.Mode.Contains("halfLoadedRes"))
				{
					_viewModel.SetImageSprite(index, base.Loader.RetriveSprite("ui/" + row.Mode.ToLower(), "Assets/Res/Assets/ui/GameGUIRes/" + row.Mode + "/" + row.Image + ".png", delegate(Sprite sprite)
					{
						_viewModel.SetImageSprite(index, sprite);
						_viewModel.CallImageNtvsize(index);
					}));
				}
				else
				{
					_viewModel.SetImageSprite(index, base.Loader.RetriveSprite("ui/" + row.Mode.ToLower(), "Assets/Res/Assets/ui/GameGUIRes/" + row.Mode + "/message/" + row.Image + ".png", delegate(Sprite sprite)
					{
						_viewModel.SetImageSprite(index, sprite);
						_viewModel.CallImageNtvsize(index);
					}));
				}
				if (row.Anim == GameMessageTable.AnimEnum.Zoomin)
				{
					_scaleChips[index].Scale = Vector3.one * 0.4f;
					_scaleChips[index].Speed = Vector3.one * 2f;
				}
				else if (row.Anim == GameMessageTable.AnimEnum.Zoomout)
				{
					_scaleChips[index].Scale = Vector3.one * 2f;
					_scaleChips[index].Speed = -Vector3.one * 2f;
				}
				else
				{
					_scaleChips[index].Scale = Vector3.one;
				}
			}
			if (row.CounterType == GameMessageTable.CounterTypeEnum.Second || row.CounterType == GameMessageTable.CounterTypeEnum.MinuteSecond || row.CounterType == GameMessageTable.CounterTypeEnum.Time || row.CounterType == GameMessageTable.CounterTypeEnum.Msm)
			{
				_activeChips[index].Time = (visible ? time1 : 0);
			}
			if (row.MessagePosition.Length != 0)
			{
				_viewModel.SetMessagePosition(index, new Vector3(row.MessagePosition[0], row.MessagePosition[1]));
			}
			if (row.Counter1.Length != 0)
			{
				_viewModel.SetCountAPosition(index, new Vector3(row.Counter1[0], row.Counter1[1]));
				_viewModel.SetCountAString(index, time1.ToString());
				base.Loader.Load("number", "Assets/Res/Assets/number/" + row.Counter1[2] + ".fontsettings", delegate(UnityEngine.Object v)
				{
					_viewModel.SetCountATextfont(index, (Font)v);
				});
			}
			else
			{
				_viewModel.SetCountAString(index, "");
			}
			if (row.Counter2.Length != 0)
			{
				_viewModel.SetCountBPosition(index, new Vector3(row.Counter2[0], row.Counter2[1]));
				_viewModel.SetCountBString(index, time2.ToString());
				base.Loader.Load("number", "Assets/Res/Assets/number/" + row.Counter2[2] + ".fontsettings", delegate(UnityEngine.Object v)
				{
					_viewModel.SetCountBTextfont(index, (Font)v);
				});
			}
			else
			{
				_viewModel.SetCountBString(index, "");
			}
			if (row.Counter3.Length != 0)
			{
				_viewModel.SetCountCPosition(index, new Vector3(row.Counter3[0], row.Counter3[1]));
				_viewModel.SetCountCString(index, time1.ToString());
				base.Loader.Load("number", "Assets/Res/Assets/number/" + row.Counter3[2] + ".fontsettings", delegate(UnityEngine.Object v)
				{
					_viewModel.SetCountCTextfont(index, (Font)v);
				});
			}
			else
			{
				_viewModel.SetCountCString(index, "");
			}
			if (row.Text.Length != 0)
			{
				_viewModel.SetTextPosition(index, new Vector3(row.Text[0], row.Text[1]));
				_viewModel.SetTextString(index, text1);
				int num = row.Text[2];
				if (num == 137)
				{
					_viewModel.SetTextFontsize(index, 21);
					_viewModel.SetTextAlignment(index, (row.Text.Length > 3) ? ((TextAnchor)row.Text[3]) : TextAnchor.MiddleCenter);
					_viewModel.SetTextTextcolor(index, Color.white);
				}
			}
			else
			{
				_viewModel.SetTextString(index, "");
			}
		}
	}

	private void InitChips()
	{
		_rpgMessageActiveChip1.Time = 0;
		_rpgMessageActiveChip2.Time = 0;
		_rpgMessageActiveChip3.Time = 0;
		_rpgMessageActiveChip4.Time = 0;
		_rpgMessageActiveChip5.Time = 0;
		_activeChips = new ActiveChip[6] { null, _rpgMessageActiveChip1, _rpgMessageActiveChip2, _rpgMessageActiveChip3, _rpgMessageActiveChip4, _rpgMessageActiveChip5 };
		_rpgMessageScaleChip1.Scale = Vector3.one;
		_rpgMessageScaleChip2.Scale = Vector3.one;
		_rpgMessageScaleChip3.Scale = Vector3.one;
		_rpgMessageScaleChip4.Scale = Vector3.one;
		_rpgMessageScaleChip5.Scale = Vector3.one;
		_rpgMessageScaleChip1.TargetScale = Vector3.one;
		_rpgMessageScaleChip2.TargetScale = Vector3.one;
		_rpgMessageScaleChip3.TargetScale = Vector3.one;
		_rpgMessageScaleChip4.TargetScale = Vector3.one;
		_rpgMessageScaleChip5.TargetScale = Vector3.one;
		_scaleChips = new ScaleChip[6] { null, _rpgMessageScaleChip1, _rpgMessageScaleChip2, _rpgMessageScaleChip3, _rpgMessageScaleChip4, _rpgMessageScaleChip5 };
	}

	private void UpdateChips()
	{
		if (_messageShow[1] != _rpgMessageActiveChip1.Update(_timeComponent))
		{
			bool[] messageShow = _messageShow;
			bool flag = (_viewModel.MessageShow1 = _rpgMessageActiveChip1.Value);
			messageShow[1] = flag;
		}
		if (_messageShow[2] != _rpgMessageActiveChip2.Update(_timeComponent))
		{
			bool[] messageShow2 = _messageShow;
			bool flag = (_viewModel.MessageShow2 = _rpgMessageActiveChip2.Value);
			messageShow2[2] = flag;
		}
		if (_messageShow[3] != _rpgMessageActiveChip3.Update(_timeComponent))
		{
			bool[] messageShow3 = _messageShow;
			bool flag = (_viewModel.MessageShow3 = _rpgMessageActiveChip3.Value);
			messageShow3[3] = flag;
		}
		if (_messageShow[4] != _rpgMessageActiveChip4.Update(_timeComponent))
		{
			bool[] messageShow4 = _messageShow;
			bool flag = (_viewModel.MessageShow4 = _rpgMessageActiveChip4.Value);
			messageShow4[4] = flag;
		}
		if (_messageShow[5] != _rpgMessageActiveChip5.Update(_timeComponent))
		{
			bool[] messageShow5 = _messageShow;
			bool flag = (_viewModel.MessageShow5 = _rpgMessageActiveChip5.Value);
			messageShow5[5] = flag;
		}
		if (_messageShow[1])
		{
			_viewModel.MessageScale1 = _rpgMessageScaleChip1.Update(_timeComponent);
		}
		if (_messageShow[2])
		{
			_viewModel.MessageScale2 = _rpgMessageScaleChip2.Update(_timeComponent);
		}
		if (_messageShow[3])
		{
			_viewModel.MessageScale3 = _rpgMessageScaleChip3.Update(_timeComponent);
		}
		if (_messageShow[4])
		{
			_viewModel.MessageScale4 = _rpgMessageScaleChip4.Update(_timeComponent);
		}
		if (_messageShow[5])
		{
			_viewModel.MessageScale5 = _rpgMessageScaleChip5.Update(_timeComponent);
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
