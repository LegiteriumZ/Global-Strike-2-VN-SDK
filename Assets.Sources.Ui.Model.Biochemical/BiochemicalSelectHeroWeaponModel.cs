using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalSelectHeroWeaponModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ISetGameRuleContext
{
	private BiochemicalselectheroweaponViewModel _viewModel = new BiochemicalselectheroweaponViewModel();

	private static AssetInfo _selectbackmanAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/selectheroweapon/selectbackman.png");

	private static AssetInfo _selectbackwomanAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/selectheroweapon/selectbackwoman.png");

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bioSelectAvatarData_SelectTime, SetSelectTime, null, initinvoke: true);
	}

	private void SetSelectTime(int ov, int time)
	{
		int bioSelectAvatarData_SelectType = UiIEventCondition.Get_bioSelectAvatarData_SelectType();
		if ((bioSelectAvatarData_SelectType == 2 || bioSelectAvatarData_SelectType == 3) && time > 0)
		{
			_viewModel.BottomShow = true;
			if (bioSelectAvatarData_SelectType == 2)
			{
				_viewModel.BackImageSprite = this.GetLoader().RetriveSprite(_selectbackmanAsset);
			}
			else
			{
				_viewModel.BackImageSprite = this.GetLoader().RetriveSprite(_selectbackwomanAsset);
			}
			_viewModel.TimeTextString = StringCache.IntToString(time / 1000);
		}
		else
		{
			_viewModel.BottomShow = false;
		}
	}

	public void OnPlayback()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		bool flag = false;
		if (_viewModel.BottomShow)
		{
			if (key.CheckEqualKeyCode(KeyCode.Alpha1) || key.CheckEqualKeyCode(KeyCode.Alpha2))
			{
				flag = true;
			}
			if (flag)
			{
				_viewModel.BottomShow = false;
				_gameRuleContext.bioSelectAvatarData.SelectTime = 0;
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

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
