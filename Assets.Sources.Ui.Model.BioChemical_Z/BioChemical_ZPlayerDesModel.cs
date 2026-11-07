using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZPlayerDesModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private BioChemical_ZPlayerDesViewModel _viewModel;

	private PlayerContext _playerContext;

	private ActiveChip _tPlayerDes = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_ZPlayerDesViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SimpleNotify.Add(GetCareer, SetCareer);
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	private string GetCareer(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null)
		{
			return cameraOwnerEntity.GetCareer();
		}
		return "";
	}

	private void SetCareer(string arg1, int arg2)
	{
		if (!string.IsNullOrEmpty(arg1))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/bio3SelectVariant", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/bio3SelectVariant/{arg1}.png", delegate(Sprite sprite)
			{
				_viewModel.playerDesSprite = sprite;
				_tPlayerDes.Time = 3000;
			});
		}
	}

	private void InitChips()
	{
		_tPlayerDes = new ActiveChip();
	}

	private void UpdateChips(TimeComponent time)
	{
		_viewModel.playerDesShow = _tPlayerDes.Update(time);
	}
}
