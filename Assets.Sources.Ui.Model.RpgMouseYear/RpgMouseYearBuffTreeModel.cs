using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMouseYear;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.Logger;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearBuffTreeModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, IKeyboardResponder, ICursorControl
{
	private RpgMouseYearBuffTreeViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private List<RpgMouseYearSkillTreeModel.BufferDes> _bufferDes = new List<RpgMouseYearSkillTreeModel.BufferDes>();

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
		try
		{
			InitDes();
		}
		catch (Exception ex)
		{
			this.LogError("ParseMouseYearError > " + ex);
		}
	}

	private void InitDes()
	{
		base.Loader.Load("effect/rpgmode_18006", "Assets/Res/Assets/effect/rpgmode_18006/playerBuffer.txt", delegate(UnityEngine.Object res)
		{
			string input = res.ToString();
			foreach (Match item2 in new Regex("\\{.*?\\}").Matches(input))
			{
				string[] array = item2.Value.Replace("{", "").Replace("}", "").Trim()
					.Split(',');
				int id = int.Parse(array[0].Split(':')[1]);
				string title = array[1].Split(':')[1];
				string des = array[2].Split(':')[1];
				RpgMouseYearSkillTreeModel.BufferDes item = new RpgMouseYearSkillTreeModel.BufferDes(title, des, id);
				_bufferDes.Add(item);
			}
		});
	}

	private RpgMouseYearSkillTreeModel.BufferDes GetBuff(int index)
	{
		foreach (RpgMouseYearSkillTreeModel.BufferDes bufferDe in _bufferDes)
		{
			if (bufferDe.IsEqual(index))
			{
				return bufferDe;
			}
		}
		return null;
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgMouseYearBuffTreeViewModel();
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
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_MouseYear_ShowSkillTree, ShowSkillTree, null, initinvoke: true);
		for (int j = 1; j <= 12; j++)
		{
			int i1 = j;
			_viewModel.CreateTriggerEntry(_viewModel.GetBuffTriggers(i1), EventTriggerType.PointerEnter, delegate
			{
				BufferPress(i1, isPress: true);
			});
			_viewModel.CreateTriggerEntry(_viewModel.GetBuffTriggers(i1), EventTriggerType.PointerExit, delegate
			{
				BufferPress(i1, isPress: false);
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void BufferPress(int index, bool isPress)
	{
		_viewModel.DesShow = isPress;
		Vector3 buffPosition = _viewModel.GetBuffPosition(index);
		buffPosition = new Vector3((int)buffPosition.x, (int)buffPosition.y, (int)buffPosition.z);
		_viewModel.DesPosition = buffPosition - new Vector3(68f, 38f, 0f);
		int value = 0;
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		if (mouseYear.Buffer != null && mouseYear.Buffer.ContainsKey(index))
		{
			value = mouseYear.Buffer[index];
		}
		RpgMouseYearSkillTreeModel.BufferDes buff = GetBuff(index);
		_viewModel.DesNameString = buff.ToTitle();
		_viewModel.DesContentString = buff.ToDes(value);
	}

	private void ShowBuffer()
	{
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		for (int i = 1; i <= 12; i++)
		{
			_viewModel.SetBuffColor(i, new Color(1f, 1f, 1f, 0f));
			if (mouseYear.Buffer != null && mouseYear.Buffer != null && mouseYear.Buffer.ContainsKey(i))
			{
				_viewModel.SetBuffColor(i, new Color(1f, 1f, 1f, 1f));
			}
		}
	}

	private void ShowSkillTree(bool arg1, bool arg2)
	{
		_viewModel.PanelShow = arg2;
		_viewModel.DesShow = false;
		ShowBuffer();
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.P)
		{
			if (_viewModel.PanelShow)
			{
				_gameRuleContext.mouseYear.IsShowSkillTree = false;
			}
			else
			{
				Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(108, new ShowSkillTreeRequest());
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public int GetCursorState()
	{
		if (!_viewModel.PanelShow)
		{
			return 0;
		}
		return 8192;
	}

	public int GetForbidButtons()
	{
		return 175;
	}
}
