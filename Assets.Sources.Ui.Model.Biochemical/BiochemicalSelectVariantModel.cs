using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalSelectVariantModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ISetGameRuleContext
{
	private BiochemicalselectvariantViewModel _viewModel = new BiochemicalselectvariantViewModel();

	private bool _isDoun;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.BottomShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bioSelectAvatarData_SelectTime, SetSelectTime, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true);
	}

	private void SetCareer(string ov, string career)
	{
		_isDoun = PlayerCareerConstantUtility.IsDoun(career);
	}

	private void SetSelectTime(int ov, int time)
	{
		if (_isDoun && UiIEventCondition.Get_bioSelectAvatarData_SelectType() == 1 && time > 0)
		{
			_viewModel.BottomShow = true;
			_viewModel.NoHaveImageShow1 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel1();
			_viewModel.NoHaveImageShow2 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel2();
			_viewModel.NoHaveImageShow3 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel3();
			_viewModel.NoHaveImageShow4 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel4();
			_viewModel.NoHaveImageShow5 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel5();
			_viewModel.NoHaveImageShow6 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel6();
			_viewModel.NoHaveImageShow7 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel7();
			_viewModel.NoHaveImageShow8 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel8();
			_viewModel.NoHaveImageShow9 = !UiIEventCondition.Get_bioSelectAvatarData_HasModel9();
			for (int i = 1; i < 10; i++)
			{
				_viewModel.SetCheckedImageShow(i, i == UiIEventCondition.Get_bioSelectAvatarData_CheckedModel() + 1);
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
			if (key.CheckEqualKeyCode(KeyCode.Alpha1))
			{
				flag = true;
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha2))
			{
				if (UiIEventCondition.Get_bioSelectAvatarData_HasModel2())
				{
					flag = true;
				}
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha3))
			{
				if (UiIEventCondition.Get_bioSelectAvatarData_HasModel3())
				{
					flag = true;
				}
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha4))
			{
				if (UiIEventCondition.Get_bioSelectAvatarData_HasModel4())
				{
					flag = true;
				}
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha5))
			{
				if (UiIEventCondition.Get_bioSelectAvatarData_HasModel5())
				{
					flag = true;
				}
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha6))
			{
				if (UiIEventCondition.Get_bioSelectAvatarData_HasModel6())
				{
					flag = true;
				}
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha7))
			{
				if (UiIEventCondition.Get_bioSelectAvatarData_HasModel7())
				{
					flag = true;
				}
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha8))
			{
				if (UiIEventCondition.Get_bioSelectAvatarData_HasModel8())
				{
					flag = true;
				}
			}
			else if (key.CheckEqualKeyCode(KeyCode.Alpha9) && UiIEventCondition.Get_bioSelectAvatarData_HasModel9())
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
