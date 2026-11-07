using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class RpgMoneyModel : AbstractModel, IPlaybackSystem
{
	private RpgMoneyViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgMoneyViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_rpgSkillStateData_Money, UpdatePrice, _viewModel.RpgMoneyObj);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.Remove(_viewModel.RpgMoneyObj);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	[GameTestFloatRange(new object[] { 1, -10000000, 10000000 })]
	[GameUiTestMethod]
	private void UpdatePrice(int old, int newprice)
	{
		newprice = Mathf.Abs(newprice);
		_viewModel.priceString = newprice.ToString();
	}
}
