using System;
using System.Collections.Generic;
using System.Text;
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
using SSJJBase.String;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearSkillTreeModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, IKeyboardResponder, ICursorControl
{
	internal class SkillDes
	{
		private string _title;

		private string _des;

		private string _value;

		private int _id;

		private string[] _valueSplits;

		internal SkillDes(string title, string des, string value, int id)
		{
			_title = title;
			_des = des;
			_value = value;
			_id = id;
			_valueSplits = _value.Split('|');
		}

		internal string ToTitle()
		{
			return _title;
		}

		internal string ToDes(bool isActive)
		{
			if (isActive)
			{
				int num = 0;
				StringBuilder stringBuilder = new StringBuilder("");
				for (int i = 0; i < _des.Length; i++)
				{
					if (_des[i] == 'x' || _des[i] == 'X')
					{
						int num2 = 0;
						if (i < _des.Length - 1)
						{
							if (_des[i + 1] == 'm' || _des[i + 1] == 'M')
							{
								num2 = 1;
							}
							if (_des[i + 1] == 's' || _des[i + 1] == 'S')
							{
								num2 = 2;
							}
						}
						switch (num2)
						{
						case 1:
							stringBuilder.Append(int.Parse(_valueSplits[num++]) / 100);
							break;
						case 2:
							stringBuilder.Append(((float)int.Parse(_valueSplits[num++]) / 1000f).ToString("0.0"));
							break;
						default:
							stringBuilder.Append(_valueSplits[num++]);
							break;
						}
					}
					else
					{
						stringBuilder.Append(_des[i]);
					}
				}
				return stringBuilder.ToString();
			}
			return _des.Replace("x", "0").Replace("X", "0");
		}

		internal bool IsEqual(int index)
		{
			return _id == index;
		}
	}

	internal class BufferDes
	{
		private string _title;

		private string _des;

		private int _id;

		internal BufferDes(string title, string des, int id)
		{
			_title = title;
			_des = des;
			_id = id;
		}

		internal string ToTitle()
		{
			return _title;
		}

		internal string ToDes(int value)
		{
			StringBuilder stringBuilder = new StringBuilder("");
			for (int i = 0; i < _des.Length; i++)
			{
				if (_des[i] == 'x' || _des[i] == 'X')
				{
					int num = 0;
					if (i < _des.Length - 1)
					{
						if (_des[i + 1] == 'M' || _des[i + 1] == 'm')
						{
							num = 1;
						}
						else if (_des[i + 1] == 's' || _des[i + 1] == 'S')
						{
							num = 2;
						}
					}
					switch (num)
					{
					case 1:
						stringBuilder.Append(value / 100);
						break;
					case 2:
						stringBuilder.Append(((float)value / 1000f).ToString("0.0"));
						break;
					default:
						stringBuilder.Append(value);
						break;
					}
				}
				else
				{
					stringBuilder.Append(_des[i]);
				}
			}
			return stringBuilder.ToString();
		}

		internal bool IsEqual(int index)
		{
			return _id == index;
		}
	}

	private class SkillTreeLine
	{
		public int ToIndex;

		public int PreIndex;

		public GameObject LineObj;
	}

	private RpgMouseYearSkillTreeViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private List<SkillDes> _skillDes = new List<SkillDes>();

	private List<BufferDes> _bufferDes = new List<BufferDes>();

	private List<SkillTreeLine> _skillTreeLines;

	private int _skillLevelUpPressIndex = -1;

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
		base.Loader.Load("effect/rpgmode_18006", "Assets/Res/Assets/effect/rpgmode_18006/playerSkill.txt", delegate(UnityEngine.Object res)
		{
			string input2 = res.ToString();
			foreach (Match item3 in new Regex("\\{.*?\\}").Matches(input2))
			{
				string[] array2 = item3.Value.Replace("{", "").Replace("}", "").Trim()
					.Split(',');
				int id2 = int.Parse(array2[0].Split(':')[1]);
				string title2 = array2[1].Split(':')[1];
				string des2 = array2[2].Split(':')[1];
				string value = array2[3].Split(':')[1];
				SkillDes item2 = new SkillDes(title2, des2, value, id2);
				_skillDes.Add(item2);
			}
		});
		base.Loader.Load("effect/rpgmode_18006", "Assets/Res/Assets/effect/rpgmode_18006/playerBuffer.txt", delegate(UnityEngine.Object res)
		{
			string input = res.ToString();
			foreach (Match item4 in new Regex("\\{.*?\\}").Matches(input))
			{
				string[] array = item4.Value.Replace("{", "").Replace("}", "").Trim()
					.Split(',');
				int id = int.Parse(array[0].Split(':')[1]);
				string title = array[1].Split(':')[1];
				string des = array[2].Split(':')[1];
				BufferDes item = new BufferDes(title, des, id);
				_bufferDes.Add(item);
			}
		});
	}

	private SkillDes GetSkill(int index)
	{
		foreach (SkillDes skillDe in _skillDes)
		{
			if (skillDe.IsEqual(index))
			{
				return skillDe;
			}
		}
		return null;
	}

	private BufferDes GetBuff(int index)
	{
		foreach (BufferDes bufferDe in _bufferDes)
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
		_viewModel = new RpgMouseYearSkillTreeViewModel();
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
		_viewModel.PanelShow = false;
		InitSkillTreeLine();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_MouseYear_ShowSkillTree, ShowSkillTree, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_MouseYear_SkillTreePoint, ShowSkillPoint, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_MouseYear_SkillTreeActive, ShowSkillActive, null, initinvoke: true);
		for (int j = 1; j <= 22; j++)
		{
			int i1 = j;
			_viewModel.CreateTriggerEntry(_viewModel.GetSkillTriggers(i1), EventTriggerType.PointerClick, delegate
			{
				SkillLevelUpClick(i1);
			});
			_viewModel.CreateTriggerEntry(_viewModel.GetSkillTriggers(i1), EventTriggerType.PointerEnter, delegate
			{
				SkillLevelUpPress(i1, isPress: true);
			});
			_viewModel.CreateTriggerEntry(_viewModel.GetSkillTriggers(i1), EventTriggerType.PointerExit, delegate
			{
				SkillLevelUpPress(i1, isPress: false);
			});
		}
		for (int k = 1; k <= 12; k++)
		{
			int i2 = k;
			_viewModel.CreateTriggerEntry(_viewModel.GetBuffTriggers(i2), EventTriggerType.PointerEnter, delegate
			{
				BufferPress(i2, isPress: true);
			});
			_viewModel.CreateTriggerEntry(_viewModel.GetBuffTriggers(i2), EventTriggerType.PointerExit, delegate
			{
				BufferPress(i2, isPress: false);
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void SkillLevelUpClick(int index)
	{
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(109, new ClickSkillTreeRequest
		{
			SkillIndex = index
		});
	}

	private void SkillLevelUpPress(int index, bool isPress)
	{
		_viewModel.DesShow = isPress;
		if (!isPress)
		{
			_skillLevelUpPressIndex = -1;
		}
		else
		{
			_skillLevelUpPressIndex = index;
		}
		Vector3 skillPosition = _viewModel.GetSkillPosition(index);
		skillPosition -= new Vector3(68f, 38f, 0f);
		_viewModel.DesPosition = new Vector3((int)skillPosition.x, (int)skillPosition.y, (int)skillPosition.z);
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		bool isActive = false;
		if (mouseYear.ActiveSkillList != null)
		{
			isActive = mouseYear.ActiveSkillList.Contains(index);
		}
		SkillDes skill = GetSkill(index);
		if (skill != null)
		{
			_viewModel.DesNameString = skill.ToTitle();
			_viewModel.DesContentString = skill.ToDes(isActive);
		}
	}

	private void BufferPress(int index, bool isPress)
	{
		_viewModel.DesShow = isPress;
		Vector3 buffPosition = _viewModel.GetBuffPosition(index);
		_viewModel.DesPosition = buffPosition - new Vector3(68f, 38f, 0f);
		int value = 0;
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		if (mouseYear.Buffer != null && mouseYear.Buffer.ContainsKey(index))
		{
			value = mouseYear.Buffer[index];
		}
		BufferDes buff = GetBuff(index);
		_viewModel.DesNameString = buff.ToTitle();
		_viewModel.DesContentString = buff.ToDes(value);
	}

	private void InitSkillTreeLine()
	{
		_skillTreeLines = new List<SkillTreeLine>();
		for (int i = 1; i < 4; i++)
		{
			Transform transform = _viewModel.GetSkillParentObj(i).transform;
			List<Transform> list = new List<Transform>();
			Transform[] componentsInChildren = transform.GetComponentsInChildren<Transform>();
			foreach (Transform transform2 in componentsInChildren)
			{
				if (transform2.name.Contains("Line"))
				{
					list.Add(transform2);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				string[] array = list[k].name.Split('_');
				SkillTreeLine item = new SkillTreeLine
				{
					PreIndex = int.Parse(array[1]),
					ToIndex = int.Parse(array[2]),
					LineObj = list[k].gameObject
				};
				_skillTreeLines.Add(item);
			}
		}
	}

	private void ShowSkillActive(List<int> arg1, List<int> arg2)
	{
		ShowSkillActive();
		if (_viewModel.DesShow)
		{
			SkillLevelUpPress(_skillLevelUpPressIndex, isPress: true);
		}
	}

	private void ShowSkillActive()
	{
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		for (int i = 1; i <= 22; i++)
		{
			_viewModel.SetSkillColor(i, new Color(1f, 1f, 1f, 0f));
		}
		foreach (int activeSkill in mouseYear.ActiveSkillList)
		{
			_viewModel.SetSkillColor(activeSkill, new Color(1f, 1f, 1f, 1f));
		}
		for (int j = 0; j < _skillTreeLines.Count; j++)
		{
			_skillTreeLines[j].LineObj.SetObjectActive(isactive: false);
			if (mouseYear.ActiveSkillList.Contains(_skillTreeLines[j].ToIndex))
			{
				_skillTreeLines[j].LineObj.SetObjectActive(isactive: true);
			}
		}
	}

	private void ShowSkillPoint(int arg1, int arg2)
	{
		ShowSkillPoint();
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

	private void ShowSkillPoint()
	{
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		_viewModel.SkillCountString = StringCache.IntToString(mouseYear.SkillPoint);
	}

	private void ShowSkillTree(bool arg1, bool arg2)
	{
		_viewModel.PanelShow = arg2;
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		for (int i = 1; i <= 3; i++)
		{
			_viewModel.SetSkillParentShow(i, i == mouseYear.SkillTreeType);
			_viewModel.SetskillBackImageShow(i, i == mouseYear.SkillTreeType);
		}
		_viewModel.DesShow = false;
		ShowSkillPoint();
		ShowSkillActive();
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
