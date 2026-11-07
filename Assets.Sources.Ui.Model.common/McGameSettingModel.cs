using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Generated.Table;
using Assets.Sources.Config;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.Logger;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Common;

public class McGameSettingModel : AbstractModel, IPlaybackSystem, ICursorControl, IKeyboardResponder
{
	private McgamesettingViewModel _viewModel;

	private GameSettingItemModel[] _itemModels;

	private bool _uiInited;

	private List<GameSettingTable.Row> _itemList = new List<GameSettingTable.Row>();

	private ConfigData _config;

	private List<int> _sepratorPos = new List<int>();

	private int _totalHeight;

	private int _isSettingUi;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new McgamesettingViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
		CloseDelay--;
		if (_uiInited || _itemModels == null)
		{
			return;
		}
		GameSettingItemModel[] itemModels = _itemModels;
		for (int i = 0; i < itemModels.Length; i++)
		{
			if (!itemModels[i].GetViewModel().IsInited)
			{
				return;
			}
		}
		_uiInited = true;
		InitUi();
	}

	protected override CanvasScaler.ScaleMode GetScaleModel()
	{
		return CanvasScaler.ScaleMode.ConstantPixelSize;
	}

	protected override void DoSubscribe()
	{
		_viewModel.AlertShow = false;
		_viewModel.TipsBackShow = false;
		_viewModel.CenterShow = false;
		CreateCells();
		NotifyManager.MakeNotify(39, UiIEventCondition.Get_gameSetting_VisibleChanged, SetVisibleChanged);
	}

	private void CreateCells()
	{
		_itemModels = new GameSettingItemModel[GameSettingLoader.Instance.Table.NumRows() + 1];
		for (int i = 0; i < _itemModels.Length; i++)
		{
			_itemModels[i] = new GameSettingItemModel();
			_itemModels[i].Container = _viewModel.ContentObj;
			_itemModels[i].Initialize();
		}
	}

	private void SetVisibleChanged(bool ov, bool visible)
	{
		if (visible)
		{
			_viewModel.CenterShow = true;
			GameSetting.Copy(_config, GameSetting.Config);
			SetUi();
		}
	}

	private void InitUi()
	{
		_config = GameSetting.CreateNewConfig();
		GameSetting.InitGameSizeConfig();
		_itemList = GameSettingLoader.Instance.Table.GetRowList();
		Type typeFromHandle = typeof(ConfigData);
		for (int i = 0; i < _itemList.Count; i++)
		{
			GameSettingTable.Row row = _itemList[i];
			GameSettingItemViewModel itemView = _itemModels[i].GetViewModel();
			itemView.ItemTitleString = row.Name;
			if (!string.IsNullOrEmpty(row.Descript))
			{
				itemView.CreateTriggerEntry(itemView.ItemBackTriggers, EventTriggerType.PointerEnter, delegate
				{
					_viewModel.TipsBackShow = true;
					_viewModel.TipsString = row.Descript;
					_viewModel.TipsBackGposition = Input.mousePosition + new Vector3(5f, 5f);
				});
				itemView.CreateTriggerEntry(itemView.ItemBackTriggers, EventTriggerType.PointerExit, delegate
				{
					_viewModel.TipsBackShow = false;
				});
			}
			itemView.NotOpenedShow = false;
			itemView.DropdownShow = false;
			itemView.ItemBackShow = false;
			itemView.SliderShow = false;
			itemView.SepratorShow = false;
			itemView.ColorShow = false;
			itemView.CrossShow = false;
			itemView.ItemTextString = "";
			if (!row.IsOpened)
			{
				itemView.NotOpenedShow = true;
				itemView.ItemBackShow = true;
				itemView.NotOpendTextString = ScriptLocalization.Get("waittext");
				itemView.GameSettingItemSize = new Vector2(500f, 50f);
				continue;
			}
			FieldInfo field = typeFromHandle.GetField(row.Property);
			switch (row.Type)
			{
			case GameSettingTable.ControlType.Dropdown:
			{
				itemView.DropdownShow = true;
				itemView.ItemBackShow = true;
				itemView.GameSettingItemSize = new Vector2(500f, 50f);
				List<Dropdown.OptionData> list = new List<Dropdown.OptionData>();
				string[] select = row.Select;
				foreach (string text in select)
				{
					list.Add(new Dropdown.OptionData(text));
				}
				itemView.DropdownOptions = list;
				itemView.DropdownDropdownchanged.AddListener(delegate(int v)
				{
					object oldValue = field.GetValue(_config);
					field.SetValue(_config, v);
					SetUi();
					ResetDepedent(row.Name);
					SetUi();
					if (_viewModel.CenterShow && row.Alert != null && !_viewModel.AlertShow)
					{
						_viewModel.AlertShow = true;
						_viewModel.AlertTextString = row.Alert[v];
						_viewModel.AlertCancelClicked.AddListener(delegate
						{
							field.SetValue(_config, oldValue);
							SetUi();
							ResetDepedent(row.Name);
							SetUi();
							_viewModel.AlertShow = false;
						});
					}
				});
				break;
			}
			case GameSettingTable.ControlType.Slider:
				itemView.SliderShow = true;
				itemView.ItemBackShow = true;
				itemView.GameSettingItemSize = new Vector2(500f, 50f);
				itemView.MaxString = row.Select[1];
				itemView.MinString = row.Select[0];
				itemView.SliderSliderchanged.AddListener(delegate(float v)
				{
					float num = (float)int.Parse(row.Select[0]) + (float)(int.Parse(row.Select[1]) - int.Parse(row.Select[0])) * v;
					int num2 = (int)num;
					this.InfoFormat("field.Name {0}, v {1},rate {2},rateInt {3}", field.Name, v.ToString(), num.ToString(), num2.ToString());
					field.SetValue(_config, num2);
					if (CustomQualityLevel())
					{
						SetUi();
					}
					itemView.ValueTextString = field.GetValue(_config).ToString();
				});
				break;
			case GameSettingTable.ControlType.Seperator:
				itemView.GameSettingItemSize = new Vector2(500f, 10f);
				itemView.SepratorShow = true;
				break;
			case GameSettingTable.ControlType.Text:
				itemView.ItemBackShow = true;
				itemView.ItemTextString = row.Select[0];
				itemView.GameSettingItemSize = new Vector2(500f, 50f);
				break;
			case GameSettingTable.ControlType.Color:
				itemView.ColorShow = true;
				itemView.ItemBackShow = true;
				itemView.GameSettingItemSize = new Vector2(500f, 50f);
				itemView.ColorDropdownchanged.AddListener(delegate(int v)
				{
					_config.CrossColorIndex = v;
					if (CustomQualityLevel())
					{
						SetUi();
					}
				});
				break;
			case GameSettingTable.ControlType.Cross:
				itemView.CrossShow = true;
				itemView.ItemBackShow = true;
				itemView.GameSettingItemSize = new Vector2(500f, 50f);
				itemView.CrossDropdownchanged.AddListener(delegate(int v)
				{
					_config.CrossTypeIndex = v;
					if (CustomQualityLevel())
					{
						SetUi();
					}
				});
				break;
			}
		}
		for (int k = _itemList.Count; k < _itemModels.Length; k++)
		{
			_itemModels[k].GetViewModel().GameSettingItemShow = false;
		}
		_viewModel.ToggleLabelString1 = ScriptLocalization.Get("imagebutton");
		_viewModel.ToggleTogglechanged1.AddListener(delegate(bool v)
		{
			if (v)
			{
				_viewModel.ScrollbarVerticalScrollvalue = 1f;
			}
		});
		_viewModel.ToggleOn1 = true;
		_viewModel.ToggleLabelString2 = ScriptLocalization.Get("soundbutton");
		_viewModel.ToggleTogglechanged2.AddListener(delegate(bool v)
		{
			if (v && _totalHeight > 512)
			{
				_viewModel.ScrollbarVerticalScrollvalue = 1f - (float)_sepratorPos[0] / (float)(_totalHeight - 496);
			}
		});
		_viewModel.ToggleLabelString3 = ScriptLocalization.Get("gamebutton");
		_viewModel.ToggleTogglechanged3.AddListener(delegate(bool v)
		{
			if (v && _totalHeight > 512)
			{
				_viewModel.ScrollbarVerticalScrollvalue = 1f - (float)_sepratorPos[1] / (float)(_totalHeight - 496);
			}
		});
		_viewModel.ExitTextString = ScriptLocalization.Get("quitbutton");
		_viewModel.ExitButtonClicked.AddListener(delegate
		{
			SetUi();
			GameSetting.Copy(_config, GameSetting.Config);
			_viewModel.CenterShow = false;
			CloseDelay = 1;
		});
		_viewModel.ResetTextString = ScriptLocalization.Get("recoverbutton");
		_viewModel.ResetButtonClicked.AddListener(delegate
		{
			SetUi();
			GameSetting.ResetToDefaultValue(_config);
			SetUi();
		});
		_viewModel.SaveTextString = ScriptLocalization.Get("okbutton");
		_viewModel.SaveButtonClicked.AddListener(delegate
		{
			GameSetting.Save(_config);
			GameSetting.Apply();
			_viewModel.CenterShow = false;
			CloseDelay = 1;
		});
		_viewModel.CheckTextString = ScriptLocalization.Get("checkprintscreen");
		_viewModel.CheckButtonClicked.AddListener(delegate
		{
			Application.OpenURL(ScreenShotManager.DirPath);
		});
		_viewModel.AlertOkTextString = ScriptLocalization.Get("alertok");
		_viewModel.AlertCancelTextString = ScriptLocalization.Get("alertcancel");
		_viewModel.AlertOkClicked.AddListener(delegate
		{
			_viewModel.AlertShow = false;
		});
		SetUi();
	}

	private void ResetDepedent(string depName)
	{
		Type typeFromHandle = typeof(ConfigData);
		List<GameSettingTable.Row> list = GameSettingLoader.Instance.Table.FindAll_Dependent(depName);
		GameSettingTable.Row row = GameSettingLoader.Instance.Table.Find_Name(depName);
		FieldInfo field = typeFromHandle.GetField(row.Property);
		foreach (GameSettingTable.Row item in list)
		{
			Array.IndexOf(row.Select, item.DependentSelect);
			_ = (int)field.GetValue(_config);
		}
		if (row.Property == "QualityLevel" && _isSettingUi == 0)
		{
			FieldInfo field2 = typeof(GameSettingTable.Row).GetField("Level" + _config.QualityLevel);
			foreach (GameSettingTable.Row item2 in GameSettingLoader.Instance.Table.GetRowList().FindAll((GameSettingTable.Row r) => r.Property != "QualityLevel"))
			{
				string value = (string)field2.GetValue(item2);
				FieldInfo field3 = typeFromHandle.GetField(item2.Property);
				if (!string.IsNullOrEmpty(value))
				{
					field3.SetValue(_config, Array.IndexOf(item2.Select, value));
				}
			}
			if (_config.QualityLevel == 0)
			{
				CustomQualityLevel(row.Property);
			}
		}
		else if (row.Property != "QualityLevel")
		{
			CustomQualityLevel(row.Property);
		}
	}

	private bool CustomQualityLevel(string pro = "")
	{
		if (_isSettingUi == 0)
		{
			Type typeFromHandle = typeof(ConfigData);
			if (typeFromHandle.GetField("Custom" + pro) != null)
			{
				_config.QualityLevel = 0;
			}
			if (pro == "QualityLevel")
			{
				FieldInfo[] fields = typeFromHandle.GetFields();
				foreach (FieldInfo fieldInfo in fields)
				{
					if (fieldInfo.Name.StartsWith("Custom"))
					{
						string name = fieldInfo.Name.Substring(6);
						typeFromHandle.GetField(name).SetValue(_config, fieldInfo.GetValue(_config));
					}
				}
			}
			return true;
		}
		return false;
	}

	private void SetUi()
	{
		_isSettingUi++;
		_totalHeight = 0;
		_sepratorPos.Clear();
		Type typeFromHandle = typeof(ConfigData);
		for (int i = 0; i < _itemList.Count; i++)
		{
			GameSettingTable.Row row = _itemList[i];
			GameSettingItemViewModel viewModel = _itemModels[i].GetViewModel();
			FieldInfo field = typeFromHandle.GetField(row.Property);
			if (field == null && row.Type != GameSettingTable.ControlType.Seperator && row.Type != GameSettingTable.ControlType.Text)
			{
				this.LogError("field == null : " + row.Property);
				continue;
			}
			if (!string.IsNullOrEmpty(row.Dependent))
			{
				GameSettingTable.Row row2 = GameSettingLoader.Instance.Table.Find_Name(row.Dependent);
				if (row2 == null)
				{
					this.LogError("depRow == null : " + row.Dependent);
					continue;
				}
				FieldInfo field2 = typeFromHandle.GetField(row2.Property);
				if (field2 == null)
				{
					this.LogError("depField == null : " + row2.Property);
					continue;
				}
				if (row2.Select == null || row2.Select.Length == 0)
				{
					this.LogError("depRow.Select == null || depRow.Select.Length == 0 : " + row.Dependent);
					continue;
				}
				if ((int)field2.GetValue(_config) != Array.IndexOf(row2.Select, row.DependentSelect))
				{
					viewModel.GameSettingItemShow = false;
					continue;
				}
			}
			viewModel.GameSettingItemShow = true;
			_totalHeight += 50;
			if (!row.IsOpened)
			{
				continue;
			}
			switch (row.Type)
			{
			case GameSettingTable.ControlType.Dropdown:
			{
				object value2 = field.GetValue(_config);
				viewModel.DropdownDropdownvalue = (int)value2;
				break;
			}
			case GameSettingTable.ControlType.Slider:
			{
				object value = field.GetValue(_config);
				if (row.Select == null || row.Select.Length < 2)
				{
					this.LogError("row.Select == null || row.Select.Length < 2 : " + row.Property);
					break;
				}
				viewModel.SliderSlidervalue = ((float)(int)value - float.Parse(row.Select[0])) / (float.Parse(row.Select[1]) - float.Parse(row.Select[0]));
				viewModel.ValueTextString = value.ToString();
				break;
			}
			case GameSettingTable.ControlType.Seperator:
				_totalHeight -= 40;
				_sepratorPos.Add(_totalHeight - 10);
				break;
			case GameSettingTable.ControlType.Color:
				viewModel.ColorDropdownvalue = _config.CrossColorIndex;
				break;
			case GameSettingTable.ControlType.Cross:
				viewModel.CrossDropdownvalue = _config.CrossTypeIndex;
				break;
			}
		}
		_isSettingUi--;
	}

	public int GetCursorState()
	{
		if (!_viewModel.CenterShow && CloseDelay <= 0)
		{
			return 0;
		}
		return 128;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			_viewModel.CenterShow = false;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == KeyCode.Insert)
		{
			GameSetting.Config.SuggestFlag = (GameSetting.Config.SuggestFlag + 1) % ConfigConstant.GetSuggestTypeLength(UiIEventCondition.Get_uiRoomData_RaceType());
		}
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

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
