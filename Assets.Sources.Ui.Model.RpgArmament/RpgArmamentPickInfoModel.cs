using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgArmament;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;

namespace Assets.Sources.Ui.Model.RpgArmament;

public class RpgArmamentPickInfoModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private RpgArmamentPickInfoViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private SimpleNotifyGroup group = new SimpleNotifyGroup();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgArmamentPickInfoViewModel();
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
		SimpleNotify.Add(GetVisible, SetVisible);
		group.Add(SimpleNotify.Add(GetPickInfo, SetPickInfo));
	}

	private void SetPickInfo(string arg1, int index)
	{
		_viewModel.pickInfoStr = arg1;
	}

	private string GetPickInfo(int index)
	{
		RpgTipsEventData tipsData = getTipsData();
		if (tipsData == null)
		{
			return "";
		}
		string weaponCnName = LanguageUtils.GetWeaponCnName(tipsData.Str1);
		return ScriptLocalization.Get("RPGARMAMENT_PICKWEAPON").Replace("s", weaponCnName);
	}

	private void SetVisible(bool arg1, int index)
	{
		_viewModel.ShowRootshow = false;
		_viewModel.ShowRootshow = arg1;
		group.SetSuspend(!arg1);
		if (arg1)
		{
			_viewModel.fixPos();
		}
	}

	private bool GetVisible(int index)
	{
		RpgTipsEventData tipsData = getTipsData();
		if (tipsData != null && canShow(tipsData))
		{
			return true;
		}
		return false;
	}

	private bool canShow(RpgTipsEventData rpgTipsEventData)
	{
		if (rpgTipsEventData.Time4Specified)
		{
			return rpgTipsEventData.Time4 > 0;
		}
		return rpgTipsEventData.Show;
	}

	private RpgTipsEventData getTipsData()
	{
		int key = -13350;
		Dictionary<int, RpgTipsEventData> eventDataDic = _gameRuleContext.rpgCommon.EventDataDic;
		RpgTipsEventData value = null;
		if (eventDataDic != null)
		{
			eventDataDic.TryGetValue(key, out value);
			if (value != null)
			{
				return value;
			}
		}
		return null;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
