using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJNetworking.BattleServer;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZPlayerSelectModel : AbstractModel, IKeyboardResponder, IPlaybackSystem
{
	private BioChemical_ZPlayerSelectViewModel _viewModel;

	private int pageNum;

	private int maxPage;

	private Color c1 = Color.white;

	private Color c2 = new Color(1f, 1f, 1f, 0.3f);

	private ActiveChip _tSkillDes = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZPlayerSelectViewModel();
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
		NotifyManager.MakeNotifyClass(124, UiIEventCondition.Get_gameBioZ_TipsEvent, SetBioZEvent, initinvoke: true);
		NotifyManager.MakeNotifyClass(125, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		SimpleNotify.Add(GetShow, SetShow);
		SimpleNotify.Add(Getlv, Setlv);
	}

	public int Getlv(int arg1)
	{
		return Contexts.sharedInstance.message.bioZInit.Level;
	}

	public void Setlv(int arg1, int arg2)
	{
		UpdatePlayerList();
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -13532)
			{
				Contexts.sharedInstance.message.bioZInit.playerSelectShow = tipsEvent[i].Show;
				pageNum = 0;
				_viewModel.lbtnShow = false;
				if (tipsEvent[i].Show)
				{
					_tSkillDes.Time = tipsEvent[i].Time1;
					UpdatePlayerList();
				}
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	public bool GetShow(int b1)
	{
		return Contexts.sharedInstance.message.bioZInit.playerSelectShow;
	}

	public void SetShow(bool b1, int b2)
	{
		_viewModel.playerSelectShow = b1;
		pageNum = 0;
		_viewModel.lbtnShow = false;
		if (b1)
		{
			_tSkillDes.Time = 10000;
			UpdatePlayerList();
		}
	}

	protected virtual void SetBioZEvent(NBioZInitData ov, NBioZInitData biozData)
	{
		List<NBioZCareerData> careerList = biozData.CareerList;
		careerList.Sort(delegate(NBioZCareerData a, NBioZCareerData b)
		{
			if (a.Lv >= Contexts.sharedInstance.message.bioZInit.Level && b.Lv >= Contexts.sharedInstance.message.bioZInit.Level)
			{
				if (a.Lv < b.Lv)
				{
					return -1;
				}
				return 1;
			}
			if (a.Lv <= Contexts.sharedInstance.message.bioZInit.Level && b.Lv <= Contexts.sharedInstance.message.bioZInit.Level)
			{
				if (a.Lv <= b.Lv)
				{
					return 1;
				}
				return -1;
			}
			return (a.Lv >= Contexts.sharedInstance.message.bioZInit.Level) ? 1 : (-1);
		});
		int num = pageNum * 9;
		int num2 = Mathf.Min(num + 9, careerList.Count);
		int num3 = 0;
		int num4 = num;
		while (num4 < num2)
		{
			int headid = num3 + 1;
			_viewModel.SetPlayerbgShow(num3, value: true);
			base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/head/{careerList[num4].Career}.png", delegate(Sprite sprite)
			{
				_viewModel.SetPlayerIconSprite(headid, sprite);
			});
			_viewModel.SetLockShow(headid, SetLockShow(careerList[num4].Lv));
			_viewModel.SetPlayerIconColor(headid, _viewModel.GetLockShow(headid) ? c2 : c1);
			_viewModel.SetLvString(headid, $"Lv.{careerList[num4].Lv}");
			num4++;
			num3++;
		}
		for (int i = num3; i < 9; i++)
		{
			_viewModel.SetPlayerbgShow(i, value: false);
		}
		maxPage = biozData.CareerList.Count / 9;
	}

	private void UpdatePlayerList()
	{
		List<NBioZCareerData> careerList = Contexts.sharedInstance.message.bioZInit.BioZInitData.CareerList;
		careerList.Sort(delegate(NBioZCareerData a, NBioZCareerData b)
		{
			if (a.Lv >= Contexts.sharedInstance.message.bioZInit.Level && b.Lv >= Contexts.sharedInstance.message.bioZInit.Level)
			{
				if (a.Lv < b.Lv)
				{
					return -1;
				}
				return 1;
			}
			if (a.Lv <= Contexts.sharedInstance.message.bioZInit.Level && b.Lv <= Contexts.sharedInstance.message.bioZInit.Level)
			{
				if (a.Lv <= b.Lv)
				{
					return 1;
				}
				return -1;
			}
			return (a.Lv >= Contexts.sharedInstance.message.bioZInit.Level) ? 1 : (-1);
		});
		int num = pageNum * 9;
		int num2 = Mathf.Min(num + 9, careerList.Count);
		int num3 = 0;
		int num4 = num;
		while (num4 < num2)
		{
			int headid = num3 + 1;
			_viewModel.SetPlayerbgShow(num3, value: true);
			base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/head/{careerList[num4].Career}.png", delegate(Sprite sprite)
			{
				_viewModel.SetPlayerIconSprite(headid, sprite);
			});
			_viewModel.SetLockShow(headid, SetLockShow(careerList[num4].Lv));
			_viewModel.SetPlayerIconColor(headid, _viewModel.GetLockShow(headid) ? c2 : c1);
			_viewModel.SetLvString(headid, $"Lv{careerList[num4].Lv}");
			num4++;
			num3++;
		}
		for (int i = num3; i < 9; i++)
		{
			_viewModel.SetPlayerbgShow(i, value: false);
		}
		maxPage = Contexts.sharedInstance.message.bioZInit.BioZInitData.CareerList.Count / 9;
	}

	private bool SetLockShow(int lv)
	{
		if (Contexts.sharedInstance.message.bioZInit.Level >= lv)
		{
			return false;
		}
		return true;
	}

	private void InitChips()
	{
		_tSkillDes.Time = 0;
	}

	private void UpdateChips(TimeComponent time)
	{
		if (!_tSkillDes.Update(time) && _viewModel.playerSelectShow)
		{
			Contexts.sharedInstance.message.bioZInit.playerSelectShow = false;
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_viewModel.playerSelectShow)
		{
			if (key == KeyCode.Comma)
			{
				pageNum = Mathf.Max(0, pageNum - 1);
				SetBioZEvent(null, UiIEventCondition.Get_gameBioZ_TipsEvent());
			}
			if (key == KeyCode.Period)
			{
				pageNum = Mathf.Min(maxPage, pageNum + 1);
				SetBioZEvent(null, UiIEventCondition.Get_gameBioZ_TipsEvent());
			}
			_viewModel.lbtnShow = pageNum != 0;
			_viewModel.rbtnShow = pageNum != maxPage;
			int num = -1;
			if (key - 48 > KeyCode.None && key - 48 < (KeyCode)10)
			{
				num = (int)(key - 48 + pageNum * 9);
			}
			if (key - 256 > KeyCode.None && key - 256 < (KeyCode)10)
			{
				num = (int)(key - 256 + pageNum * 9);
			}
			num--;
			if (num >= 0 && num < UiIEventCondition.Get_gameBioZ_TipsEvent().CareerList.Count)
			{
				IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
				StringData message = new StringData
				{
					Data = UiIEventCondition.Get_gameBioZ_TipsEvent().CareerList[num].Career
				};
				server.SendTcpMessage(141, message);
				Contexts.sharedInstance.message.bioZInit.playerSelectShow = false;
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
}
