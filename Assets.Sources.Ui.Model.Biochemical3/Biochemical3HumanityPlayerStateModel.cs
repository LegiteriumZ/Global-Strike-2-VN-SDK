using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Biochemical3;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using SSJJBase.String;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Ui.Model.Biochemical3;

[GameUiTest]
public class Biochemical3HumanityPlayerStateModel : AbstractModel, IPlaybackSystem, ISetPlayerContext
{
	private Biochemical3HumanityPlayerStateViewModel _viewModel;

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
		_viewModel = new Biochemical3HumanityPlayerStateViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SimpleNotify.Add(GetVisible, SetVisible);
		SimpleNotify.Add(GetCareer, SetCareer);
		SimpleNotify.Add(GetHaveBh, SetHaveBh);
		SimpleNotify.Add(GetHaveBv, SetHaveBv);
		SimpleNotify.Add(GetBioClip, SetBioClip);
		SimpleNotify.Add(GetBioSerum, SetBioSerum);
		SimpleNotify.Add(GetHpPercent, SetHpPercent);
		SimpleNotify.Add(GetHp, SetHp);
		SimpleNotify.Add(GetElite, SetElite);
	}

	private void SetElite(bool arg1, int arg2)
	{
		_viewModel.EliteShow = arg1;
	}

	private bool GetElite(int arg1)
	{
		if (_playerContext.cameraOwnerEntity == null)
		{
			return false;
		}
		return _playerContext.myPlayerEntity.HasStatus(PlayerInfoStatusConstant.ELITE.ID);
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.PanelShow = arg1;
	}

	private bool GetVisible(int arg1)
	{
		if (_playerContext.isCameraOwner)
		{
			string career = _playerContext.cameraOwnerEntity.GetCareer();
			if (!PlayerCareerConstantUtility.IsHumanity(career))
			{
				return PlayerCareerConstantUtility.IsHero(career);
			}
			return true;
		}
		return false;
	}

	private void SetHp(long arg1, int arg2)
	{
		_viewModel.HpString = StringCache.LongToString(arg1);
	}

	private long GetHp(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			return cameraOwnerEntity.basicInfo.Current.Hp;
		}
		return 0L;
	}

	private void SetHpPercent(float arg1, int arg2)
	{
		_viewModel.HpProgressFillamount = arg1;
	}

	private float GetHpPercent(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			return 1f * (float)cameraOwnerEntity.basicInfo.Current.Hp / (float)cameraOwnerEntity.basicInfo.Current.MaxHp;
		}
		return 0f;
	}

	private void SetBioClip(bool arg1, int arg2)
	{
		_viewModel.BioClipShow = arg1;
	}

	private bool GetBioClip(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.BiochemicalMagazineFlag ?? false;
	}

	private void SetBioSerum(bool arg1, int arg2)
	{
		_viewModel.BioChemicalSerumShow = arg1;
	}

	private bool GetBioSerum(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.BiochemicalSerum ?? false;
	}

	private void SetHaveBv(bool arg1, int arg2)
	{
		_viewModel.HaveBvShow = arg1;
	}

	private bool GetHaveBv(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.ArmorBody ?? false;
	}

	private void SetHaveBh(bool arg1, int arg2)
	{
		_viewModel.HaveBhShow = arg1;
	}

	private bool GetHaveBh(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.ArmorHead ?? false;
	}

	private void SetCareer(string arg1, int arg2)
	{
		if (!string.IsNullOrEmpty(arg1))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{arg1}.png", delegate(Sprite sprite)
			{
				_viewModel.CareerSprite = sprite;
			});
		}
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

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
