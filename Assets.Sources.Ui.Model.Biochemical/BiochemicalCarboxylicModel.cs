using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalCarboxylicModel : AbstractModel, IPlaybackSystem
{
	private BiochemicalcarboxylicViewModel _viewModel;

	private bool _isObserver;

	private bool _isMetalman;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BiochemicalcarboxylicViewModel();
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_cameraOwnerData_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Observer, SetObserver, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_MetalmanSkillMp, SetMetalmanSkillMp, null, initinvoke: true);
	}

	private void SetObserver(int ov, int observer)
	{
		_isObserver = observer > 0;
		UpdateVisible();
	}

	private void SetCareer(string ov, string career)
	{
		_isMetalman = career == "metalman";
		UpdateVisible();
	}

	private void UpdateVisible()
	{
		_viewModel.CenterShow = _isMetalman && !_isObserver;
	}

	private void SetMetalmanSkillMp(float ov, float mp)
	{
		if (mp > 20f)
		{
			_viewModel.MaskImageShow2 = true;
			_viewModel.StateImageRotation2 = Quaternion.Euler(new Vector3(0f, 0f, -92f + 92f * mp * 0.01f));
			_viewModel.MaskImageShow1 = false;
		}
		else
		{
			_viewModel.MaskImageShow1 = true;
			_viewModel.StateImageRotation1 = Quaternion.Euler(new Vector3(0f, 0f, -92f + 92f * mp * 0.01f));
			_viewModel.MaskImageShow2 = false;
		}
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
