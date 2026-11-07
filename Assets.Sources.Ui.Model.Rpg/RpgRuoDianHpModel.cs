using Assets.Sources.Components.GameRule.rpg;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgRuoDianHpModel : AbstractModel, IPlaybackSystem
{
	private RpgRuoDianHpViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgRuoDianHpViewModel();
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
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_hpProgressData_BossRuoDian);
		for (int i = 0; i < 5; i++)
		{
			listNotify.AddEvent<HpProgressDataComponent.RuoDian, float>("HpPercent", UiIEventCondition.Get_hpProgressData_BossRuoDian_HpPercent, SetHpPercent, i);
			listNotify.AddEvent<HpProgressDataComponent.RuoDian, string>("Texture", UiIEventCondition.Get_hpProgressData_BossRuoDian_Texture, SetTexture, i);
		}
		listNotify.ForceInvoke();
	}

	private void SetHpPercent(HpProgressDataComponent.RuoDian val, int idx, float oldfs, float newfs, ElementStatus status)
	{
		_viewModel.SetProgressFillamount(idx + 1, newfs);
	}

	private void SetTexture(HpProgressDataComponent.RuoDian val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		int index = idx + 1;
		if (string.IsNullOrEmpty(newfs))
		{
			_viewModel.SetCellShow(index, value: false);
			return;
		}
		_viewModel.SetCellShow(index, value: true);
		_viewModel.SetIconSprite(index, base.Loader.RetriveSprite("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/ruodian/" + newfs + ".png", delegate(Sprite sprite)
		{
			_viewModel.SetIconSprite(index, sprite);
		}));
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
