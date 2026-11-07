using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class PlayerStateModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private const string HalfLoadBundlePveName = "ui/halfloadedres/pveplayerstate";

	private const string HalfLoadBundlePvpName = "ui/halfloadedres/pvpplayerstate";

	private const string HalfLoadAssetPath = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/{1}/{0}.png";

	private const string CommonFreeBundleName = "ui/commonfree";

	private const string CommonFreeAssetPath = "Assets/Res/Assets/ui/GameGUIRes/commonfree/{1}/{0}.png";

	private PlayerstateViewModel _viewModel = new PlayerstateViewModel();

	private string _currCarrer;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void OnPlayback()
	{
		_ = _viewModel.IsInited;
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Hp, SetHp, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_MaxHp, SetMaxHp, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_SkinName, SetSkinName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_ArmorHead, SetArmorHead, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_ArmorBody, SetArmorBody, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_TitleId, SetTitle, null, initinvoke: true);
	}

	private void SetTitle(float arg1, float arg2)
	{
		if (arg2 <= 0f)
		{
			_viewModel.TitleShow = false;
			return;
		}
		_viewModel.TitleShow = true;
		base.Loader.RetriveSprite("ui/halfLoadedRes/playerHononary", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerHononary/{arg2}.png", delegate(Sprite sprite)
		{
			_viewModel.TitleSprite = sprite;
		});
	}

	private void SetArmorBody(bool arg1, bool arg2)
	{
		_viewModel.BulletProofSprite = base.Loader.RetriveSprite("ui/commonfree", string.Format("Assets/Res/Assets/ui/GameGUIRes/commonfree/{1}/{0}.png", arg2 ? "havebv" : "nobv", "playerState"), delegate(Sprite sprite)
		{
			_viewModel.BulletProofSprite = sprite;
		});
	}

	private void SetArmorHead(bool arg1, bool arg2)
	{
		_viewModel.HelmetSprite = base.Loader.RetriveSprite("ui/commonfree", string.Format("Assets/Res/Assets/ui/GameGUIRes/commonfree/{1}/{0}.png", arg2 ? "havebh" : "nobh", "playerState"), delegate(Sprite sprite)
		{
			_viewModel.HelmetSprite = sprite;
		});
	}

	private void SetSkinName(string arg1, string arg2)
	{
		AddUpdateHandler(UpdateCareer);
	}

	private void SetCareer(string arg1, string arg2)
	{
		AddUpdateHandler(UpdateCareer);
	}

	private void SetMaxHp(long arg1, long arg2)
	{
		AddUpdateHandler(SetHpProgress);
	}

	private void SetHp(long arg1, long arg2)
	{
		AddUpdateHandler(SetHpProgress);
	}

	private string ConvertHeadIcon()
	{
		switch (_currCarrer)
		{
		case "rpg_10004108":
		case "rpg_10004109":
		case "rpg_10004110":
			return "rpg_default_career";
		default:
			return _currCarrer;
		}
	}

	private void UpdateCareer(int idx)
	{
		string cameraOwnerData_SkinName = UiIEventCondition.Get_cameraOwnerData_SkinName();
		string cameraOwnerData_Career = UiIEventCondition.Get_cameraOwnerData_Career();
		if (string.IsNullOrEmpty(cameraOwnerData_SkinName) && string.IsNullOrEmpty(cameraOwnerData_Career))
		{
			return;
		}
		string assetInfoCareer;
		cameraOwnerData_Career = (assetInfoCareer = (_currCarrer = ((!string.IsNullOrEmpty(cameraOwnerData_SkinName)) ? cameraOwnerData_SkinName : cameraOwnerData_Career)));
		bool flag = _gameRuleContext.currentRule.Rule.IsRpg();
		if (!flag && cameraOwnerData_Career == "snowman")
		{
			if (UiIEventCondition.Get_cameraOwnerData_Team() == 1)
			{
				assetInfoCareer = cameraOwnerData_Career + "_ct";
			}
			else
			{
				assetInfoCareer = cameraOwnerData_Career + "_t";
			}
		}
		string bundleName = (flag ? "ui/halfloadedres/pveplayerstate" : "ui/halfloadedres/pvpplayerstate");
		_viewModel.CareerSprite = base.Loader.RetriveSprite(bundleName, string.Format("Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/{1}/{0}.png", assetInfoCareer, flag ? "pveplayerstate" : "pvpplayerstate"), delegate(Sprite sprite)
		{
			if (_currCarrer == assetInfoCareer)
			{
				_viewModel.CareerSprite = sprite;
				_viewModel.CareerNtvsize();
			}
		});
	}

	private void SetHpProgress(int idx)
	{
		if (UiIEventCondition.Get_cameraOwnerData_MaxHp() > 0 && UiIEventCondition.Get_cameraOwnerData_Hp() > 0)
		{
			_viewModel.HealthNumberString = StringCache.LongToString(UiIEventCondition.Get_cameraOwnerData_Hp());
			_viewModel.HealthProgressFillamount = (float)UiIEventCondition.Get_cameraOwnerData_Hp() / (float)UiIEventCondition.Get_cameraOwnerData_MaxHp();
		}
		else
		{
			_viewModel.HealthNumberString = "0";
			_viewModel.HealthProgressFillamount = 0f;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
