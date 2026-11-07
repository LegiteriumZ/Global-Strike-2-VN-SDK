using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.Common;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical3;

public class Biochemical3WeaponStateModel : WeaponStateModel
{
	public override void CreateViewModel()
	{
		_viewModel = new WeaponstateViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		base.Loader.RetriveSprite("ui/bio3model", "Assets/Res/Assets/ui/GameGUIRes/bio3Model/weaponstate/weaponstateback.png", delegate(Sprite sprite)
		{
			_viewModel.BackSprite = sprite;
			_viewModel.BackNtvsize();
		});
	}
}
