using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioUnionBase;

[GameUiTest]
public class BioUnionBasePlayerInfoModel : AbstractModel, ISetPlayerContext, IPlaybackSystem
{
	private BioUnionBasePlayerInfoViewModel _viewModel;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioUnionBasePlayerInfoViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(GetCareer, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetHpPercent, SetHpPercent, null, initinvoke: true);
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	private string GetCareer()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null)
		{
			return cameraOwnerEntity.GetCareer();
		}
		return "";
	}

	private void SetCareer(string arg1, string arg2)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null)
		{
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{cameraOwnerEntity.GetCareer()}.png", delegate(Sprite sprite)
			{
				_viewModel.PIconSprite = sprite;
			});
		}
	}

	private void SetHpPercent(float arg1, float arg2)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			_viewModel.HP_String2 = cameraOwnerEntity.basicInfo.Current.Hp + "/" + cameraOwnerEntity.basicInfo.Current.MaxHp;
			_viewModel.HPFillamount = (float)cameraOwnerEntity.basicInfo.Current.Hp / (float)cameraOwnerEntity.basicInfo.Current.MaxHp;
		}
	}

	private float GetHpPercent()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			return 1f * (float)cameraOwnerEntity.basicInfo.Current.Hp;
		}
		return 0f;
	}

	private void InitChips()
	{
	}

	public void OnPlayback()
	{
	}
}
