using System.Collections.Generic;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.RpgStarwalker;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.RpgStarWalker;

public class RpgStarWalkerInfoModel : PveAllKillInfoModel
{
	private int mixtureBoxMax = 8;

	public override void CreateViewModel()
	{
		base.CreateViewModel();
		_viewModel.ResourceBundleName = "uiprefabs/rpgstarwalker";
		_viewModel.ResourceAssetName = "RpgStarWalkerAllKillInfo";
		TeamMember = 10;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_StarWalker_MixtureData, SetMixtureData, null, initinvoke: true);
	}

	private void SetMixtureData(List<HeJiTabKeyData> ov, List<HeJiTabKeyData> data)
	{
		if (!_viewModel.ViewGameObject.activeSelf)
		{
			return;
		}
		Transform transform = _viewModel.ViewGameObject.transform.Find("Show/MixturePanel/MixtureGrid");
		int childCount = transform.childCount;
		RpgStarWalkerMixtureBoxModel[] array = new RpgStarWalkerMixtureBoxModel[mixtureBoxMax];
		for (int i = 0; i < mixtureBoxMax; i++)
		{
			if (childCount == 0)
			{
				array[i] = new RpgStarWalkerMixtureBoxModel();
			}
			else
			{
				array[i].hide();
			}
		}
		for (int j = 0; j < data.Count; j++)
		{
			array[j].show();
			array[j].Initialize();
			array[j].updateData(transform, j, data[j]);
		}
	}
}
