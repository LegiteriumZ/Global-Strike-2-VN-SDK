using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZPlayerInfoModel : AbstractModel, ISetPlayerContext, IPlaybackSystem
{
	private BioChemical_ZPlayerInfoViewModel _viewModel;

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
		_viewModel = new BioChemical_ZPlayerInfoViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(128, GetSkillList, SetSkillList);
		SimpleNotify.Add(GetCareer, SetCareer);
		SimpleNotify.Add(GetHpPercent, SetHpPercent);
		SimpleNotify.Add(GetHdPercent, SetHdPercent);
		SimpleNotify.Add(Getlv, Setlv);
	}

	public NBioZDiffSkillData GetSkillList()
	{
		return Contexts.sharedInstance.message.bioZInit.nBioZDiffSkillData;
	}

	public void SetSkillList(NBioZDiffSkillData skill1, NBioZDiffSkillData skill2)
	{
		int count = skill2.SkillList.Count;
		for (int i = 0; i < count; i++)
		{
			int id = i + 1;
			base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/skill/skillid/{skill2.SkillList[i]}.png", delegate(Sprite sprite)
			{
				_viewModel.Setp_skillShow(id, value: true);
				_viewModel.Setp_skillSprite(id, sprite);
			});
		}
		for (int j = count; j < 5; j++)
		{
			_viewModel.Setp_skillShow(j + 1, value: false);
		}
	}

	public int Getlv(int arg1)
	{
		return Contexts.sharedInstance.message.bioZInit.Level;
	}

	public void Setlv(int arg1, int arg2)
	{
		_viewModel.LvString = "Lv." + Contexts.sharedInstance.message.bioZInit.Level;
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
			base.Loader.RetriveSprite("ui/halfloadedres/pveplayerstate", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveplayerstate/{arg1}.png", delegate(Sprite sprite)
			{
				_viewModel.PIconSprite = sprite;
			});
		}
	}

	private bool GetHaveBv(int arg1)
	{
		return _playerContext.cameraOwnerEntity?.basicInfo.Current.ArmorBody ?? false;
	}

	private void SetHpPercent(float arg1, int arg2)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			_viewModel.HP_String2 = cameraOwnerEntity.basicInfo.Current.Hp + "/" + cameraOwnerEntity.basicInfo.Current.MaxHp;
		}
		_viewModel.HPFillamount = 1f * arg1 / (float)cameraOwnerEntity.basicInfo.Current.MaxHp;
	}

	private float GetHpPercent(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.MaxHp > 0)
		{
			return 1f * (float)cameraOwnerEntity.basicInfo.Current.Hp;
		}
		return 0f;
	}

	private void SetHdPercent(float arg1, int arg2)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.BiozShieldMaxHp > 0)
		{
			_viewModel.HD_String2 = cameraOwnerEntity.basicInfo.Current.BiozShieldHp + "/" + cameraOwnerEntity.basicInfo.Current.BiozShieldMaxHp;
		}
		_viewModel.HDFillamount = 1f * arg1 / (float)cameraOwnerEntity.basicInfo.Current.BiozShieldMaxHp;
	}

	private float GetHdPercent(int arg1)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.basicInfo.Current.BiozShieldMaxHp > 0)
		{
			return 1f * (float)cameraOwnerEntity.basicInfo.Current.BiozShieldHp;
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
