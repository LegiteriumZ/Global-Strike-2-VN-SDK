using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class PveplayerstateModel : AbstractModel, IPlaybackSystem
{
	private PveplayerstateViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveplayerstateViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Hp, SetHp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_MaxHp, SetMaxHp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_SkinName, SetSkinName, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Level, SetLevel, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Money, SetMoney, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_TitleId, Settitle, null, initinvoke: true, isFrameSeparation: true);
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType != 1100)
		{
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/playerState/back.png", delegate(Sprite sprite)
			{
				_viewModel.BackSprite = sprite;
			});
		}
		else
		{
			base.Loader.RetriveSprite("ui/towerdefensemodel", "Assets/Res/Assets/ui/GameGUIRes/towerDefenseModel/playerState/backg.png", delegate(Sprite sprite)
			{
				_viewModel.BackSprite = sprite;
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void Settitle(float arg1, float arg2)
	{
		if (arg2 != 0f)
		{
			_viewModel.playerTitleShow = true;
			base.Loader.RetriveSprite("ui/halfLoadedRes/playerHononary", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerHononary/{arg2}.png", delegate(Sprite sprite)
			{
				_viewModel.playerTitleSprite = sprite;
			});
		}
	}

	private void SetLevel(int ov, int lv)
	{
		_viewModel.lvtxtString = lv.ToString();
	}

	private void SetMoney(int ov, int val)
	{
		_viewModel.goldtxtString = val.ToString();
	}

	private void SetCareer(string ov, string newname)
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 7 && PlayerCareerConstantUtility.IsEmpress(newname))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{newname}.png", _viewModel.playerCareerImage);
		}
		else if (!string.IsNullOrEmpty(newname) && string.IsNullOrEmpty(UiIEventCondition.Get_cameraOwnerData_SkinName()))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{newname}.png", _viewModel.playerCareerImage);
		}
	}

	private void SetSkinName(string ov, string newname)
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 7 && PlayerCareerConstantUtility.IsEmpress(newname))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{newname}.png", _viewModel.playerCareerImage);
		}
		else if (!string.IsNullOrEmpty(newname))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{newname}.png", _viewModel.playerCareerImage);
		}
	}

	private void SetHp(long ov, long val)
	{
		_viewModel.hptxtString = val.ToString();
		SetHpProgress((float)((double)val / (double)UiIEventCondition.Get_cameraOwnerData_MaxHp()));
	}

	private void SetMaxHp(long ov, long val)
	{
		SetHpProgress((float)((double)UiIEventCondition.Get_cameraOwnerData_Hp() / (double)val));
	}

	private void SetHpProgress(float perencent)
	{
		_viewModel.playerHPProgressBarFillamount = perencent;
	}
}
