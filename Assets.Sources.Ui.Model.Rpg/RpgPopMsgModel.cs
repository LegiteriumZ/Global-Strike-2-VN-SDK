using System;
using System.Collections.Generic;
using Assets.Sources.Components.Message.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class RpgPopMsgModel : AbstractModel, IPlaybackSystem, ISetMessageContext
{
	private struct CellUiInfo : IEquatable<CellUiInfo>
	{
		public UiReferences Ui;

		public string StrInfo;

		public bool SameTeam;

		public int LastTime;

		public bool IsRunning;

		public int Step;

		public float AddY;

		public bool SetNextStep()
		{
			if (Step <= 1)
			{
				Step++;
				return true;
			}
			return false;
		}

		public bool Equals(CellUiInfo other)
		{
			if (Ui == other.Ui && StrInfo.Equals(other.StrInfo) && Step != other.Step && Mathf.Abs(AddY - other.AddY) < 0.001f && SameTeam == other.SameTeam && LastTime == other.LastTime)
			{
				return IsRunning == other.IsRunning;
			}
			return false;
		}
	}

	private RpgPopMsgViewModel _viewModel;

	private List<CellUiInfo> _uicells = new List<CellUiInfo>();

	private Vector3 _baseposition;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgPopMsgViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		CellUiInfo item = default(CellUiInfo);
		Transform comp = _viewModel.UI.Get("cell");
		item.Ui = comp.TryAddComponent<UiReferences>();
		_uicells.Add(item);
		_baseposition = item.Ui.transform.localPosition;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgPopMsg_MsgQueueCount, SetRpgPopMsgCnt);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.RemoveUnused();
	}

	private void SetRpgPopMsgCnt(int old, int newcnt)
	{
		if (newcnt > 0)
		{
			while (UiIEventCondition.Get_rpgPopMsg_MsgQueueCount() > 0)
			{
				RpgPopMsgComponent.PopMsg msg = _messageContext.rpgPopMsg.MsgQueue.Dequeue();
				ControlPopMsgTip(ref msg);
			}
		}
	}

	private void ControlPopMsgTip(ref RpgPopMsgComponent.PopMsg msg)
	{
		if (msg.IsRightDown)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < _uicells.Count; i++)
		{
			CellUiInfo value = _uicells[i];
			if (value.IsRunning)
			{
				num++;
				if (value.SetNextStep())
				{
					_uicells[i] = value;
				}
			}
		}
		_uicells[num] = ShowCellUi(num, msg.Text, msg.SameTeam);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		for (int i = 0; i < _uicells.Count; i++)
		{
			CellUiInfo info = _uicells[i];
			if (info.Ui != null && info.IsRunning)
			{
				UpdateCellMsg(ref info);
				_uicells[i] = info;
			}
			else if (info.Ui != null)
			{
				info.Ui.SetObjectActive(isactive: false);
			}
		}
	}

	private void UpdateCellMsg(ref CellUiInfo info)
	{
		int num = info.Step;
		switch (num)
		{
		case 0:
			if (Contexts.sharedInstance.time.time.ServerTime - info.LastTime > 2000)
			{
				num = 1;
			}
			break;
		case 1:
		{
			info.AddY -= 0.5f;
			if (info.AddY < -32f)
			{
				info.AddY = -32f;
				num = 2;
			}
			Text text2 = info.Ui.Get<Text>("Tipmsg");
			Vector2 anchoredPosition2 = text2.rectTransform.anchoredPosition;
			text2.rectTransform.anchoredPosition = new Vector2(anchoredPosition2.x, info.AddY);
			break;
		}
		case 2:
		{
			info.AddY -= 0.5f;
			Text text = info.Ui.Get<Text>("Tipmsg");
			Color color = text.color;
			color.a -= 0.01f;
			text.color = color;
			if (color.a < 0f)
			{
				info.IsRunning = false;
			}
			Vector2 anchoredPosition = text.rectTransform.anchoredPosition;
			text.rectTransform.anchoredPosition = new Vector2(anchoredPosition.x, info.AddY);
			break;
		}
		}
		info.Step = num;
	}

	[GameUiTestMethod]
	private CellUiInfo ShowCellUi(int index, string msgtext, bool team)
	{
		CellUiInfo cellMsg = GetCellMsg(index);
		cellMsg.SameTeam = team;
		cellMsg.StrInfo = msgtext;
		cellMsg.IsRunning = true;
		cellMsg.Step = 0;
		cellMsg.AddY = 0f;
		cellMsg.Ui.SetObjectActive(isactive: true);
		if (team)
		{
			Color color = new Color(0.08f, 0.7f, 9.3f, 1f);
			Text text = cellMsg.Ui.Get<Text>("Tipmsg");
			text.color = color;
			text.text = msgtext;
		}
		else
		{
			Color color2 = new Color(0.7f, 0.03f, 1f);
			Text text2 = cellMsg.Ui.Get<Text>("Tipmsg");
			text2.color = color2;
			text2.text = msgtext;
		}
		return cellMsg;
	}

	private CellUiInfo GetCellMsg(int index)
	{
		if (index < _uicells.Count)
		{
			return _uicells[index];
		}
		CellUiInfo cellUiInfo = _uicells[0];
		GameObject gameObject = cellUiInfo.Ui.gameObject.CreateInstance();
		gameObject.transform.SetParent(cellUiInfo.Ui.transform.parent);
		gameObject.transform.SetObjectActive(isactive: true);
		gameObject.transform.localPosition = _baseposition;
		CellUiInfo cellUiInfo2 = default(CellUiInfo);
		cellUiInfo2.Ui = gameObject.GetComponent<UiReferences>();
		cellUiInfo2.LastTime = Contexts.sharedInstance.time.time.ServerTime;
		_uicells.Add(cellUiInfo2);
		return cellUiInfo2;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
