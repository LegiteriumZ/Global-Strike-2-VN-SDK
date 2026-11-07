using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class PlayerBufferModel : AbstractModel, IPlaybackSystem
{
	private PlayerBufferViewModel _viewModel;

	private HashSet<string> _buffers = new HashSet<string>();

	private PingPongChip _panelPingPongChip = new PingPongChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PlayerBufferViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited && _buffers.Count > 0)
		{
			UpdateChips();
			_viewModel.PanelAlpha = _panelPingPongChip.Value;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_SubHp, SetSubHp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_InFear, SetInFear, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_InChaos, SetInChaos, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_InHuoYanXianJi, SetInHuoYanXianJi, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_CommonState_NezhaSubmp, SetNezhaSubmp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Red, SetRed, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Yellow, SetYellow, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Blue, SetBlue, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Black, SetBlack, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Green, SetGreen, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_White, SetWhite, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_AddHp, SetAddHp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_AddShield, SetAddShield, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetWhite(bool arg1, bool arg2)
	{
		UpdateBuff("White", arg2);
	}

	private void SetGreen(bool arg1, bool arg2)
	{
		UpdateBuff("Green", arg2);
	}

	private void SetBlack(bool arg1, bool arg2)
	{
		UpdateBuff("Black", arg2);
	}

	private void SetBlue(bool arg1, bool arg2)
	{
		UpdateBuff("Blue", arg2);
	}

	private void SetYellow(bool arg1, bool arg2)
	{
		UpdateBuff("Yellow", arg2);
	}

	private void SetRed(bool arg1, bool arg2)
	{
		UpdateBuff("Red", arg2);
	}

	private void SetAddShield(bool arg1, bool arg2)
	{
		UpdateBuff("AddShield", arg2);
	}

	private void SetAddHp(bool arg1, bool arg2)
	{
		UpdateBuff("AddHp", arg2);
	}

	private void SetInHuoYanXianJi(bool arg1, bool arg2)
	{
		UpdateBuff("InHuoYanXianJi", arg2);
	}

	private void SetNezhaSubmp(bool arg1, bool arg2)
	{
		UpdateBuff("NezhaSubmp", arg2);
	}

	private void SetInChaos(bool arg1, bool arg2)
	{
		UpdateBuff("InChaos", arg2);
	}

	private void SetInFear(bool arg1, bool arg2)
	{
		UpdateBuff("InFear", arg2);
	}

	private void SetSubHp(bool arg1, bool arg2)
	{
		UpdateBuff("SubHp", arg2);
	}

	private void UpdateBuff(string name, bool flag)
	{
		if (flag && !_buffers.Contains(name))
		{
			_buffers.Add(name);
		}
		else if (!flag && _buffers.Contains(name))
		{
			_buffers.Remove(name);
		}
		AddUpdateHandler(UpdateBufferImage);
	}

	private void UpdateBufferImage(int idx)
	{
		int j = 1;
		int k = 11;
		foreach (string buffer in _buffers)
		{
			string text = "";
			string text2 = "common";
			int i3 = -1;
			switch (buffer)
			{
			case "SubHp":
				text = "subhp";
				i3 = k++;
				break;
			case "InFear":
				text = "fear";
				i3 = k++;
				break;
			case "InChaos":
				text = "fear";
				i3 = k++;
				break;
			case "InHuoYanXianJi":
				text = "fire";
				i3 = k++;
				break;
			case "NezhaSubmp":
				text = "nezha_submp";
				i3 = k++;
				break;
			case "Red":
				text = "red";
				i3 = j++;
				break;
			case "Yellow":
				text = "yellow";
				i3 = j++;
				break;
			case "Blue":
				text = "blue";
				i3 = j++;
				break;
			case "Black":
				text = "black";
				i3 = j++;
				break;
			case "Green":
				text = "green";
				i3 = j++;
				break;
			case "White":
				text = "white";
				i3 = j++;
				break;
			case "AddHp":
				text = "addhp";
				text2 = "rpgGroupModel";
				_viewModel.SetNumString(i3, UiIEventCondition.Get_pveState_AddHpNum().ToString());
				i3 = j++;
				break;
			case "AddShield":
				text = "addshiled";
				text2 = "rpgGroupModel";
				_viewModel.SetNumString(i3, UiIEventCondition.Get_pveState_AddShieldNum().ToString());
				i3 = j++;
				break;
			}
			_viewModel.SetBuffShow(i3, value: true);
			_viewModel.SetNumString(i3, "");
			base.Loader.RetriveSprite("ui/" + text2, "Assets/Res/Assets/ui/GameGUIRes/" + text2 + "/playerbuffer/" + text + ".png", delegate(Sprite sprite)
			{
				_viewModel.SetBuffSprite(i3, sprite);
			});
		}
		for (; j <= 4; j++)
		{
			_viewModel.SetBuffShow(j, value: false);
		}
		for (; k <= 14; k++)
		{
			_viewModel.SetBuffShow(k, value: false);
		}
	}

	private void InitChips()
	{
		_panelPingPongChip.From = 1f;
		_panelPingPongChip.To = 0.3f;
		_panelPingPongChip.Time = 1000;
	}

	private void UpdateChips()
	{
		_panelPingPongChip.Update(_timeComponent);
	}
}
