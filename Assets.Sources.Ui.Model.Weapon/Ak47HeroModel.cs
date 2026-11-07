using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class Ak47HeroModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetPlayerContext
{
	private Ak47heroViewModel _viewModel;

	private WeaponContext _weaponContext;

	private PlayerEntity _otherPlayer;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Ak47heroViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
		if (_viewModel.ShowShow1)
		{
			_viewModel.LineImageFillamount1 += (float)_timeComponent.FrameInterval / 200f;
			if (_viewModel.LineImageFillamount1 >= 1f)
			{
				_viewModel.InfoBackImageAlpha1 += (float)_timeComponent.FrameInterval / 200f;
			}
		}
		if (_viewModel.OtherShowShow2 && _otherPlayer != null && _otherPlayer.hasAk47Hero && _otherPlayer.hasAk47Hero)
		{
			Ak47HeroComponent ak47Hero = _otherPlayer.ak47Hero;
			UpdateOtherPosition(ak47Hero.ScreenPos);
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow1 = false;
		_viewModel.OtherShowShow2 = false;
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_ShowAk47, SetShowAk47, null, initinvoke: true);
		NotifyManager.MakeNotifyClass(4, UiIEventCondition.Get_weaponState_OtherShowAk47, SetOtherShowAk47, initinvoke: true);
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (!string.IsNullOrEmpty(weaponName))
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "ak47herokillinfoline"), delegate(Sprite sprite)
			{
				Ak47heroViewModel viewModel2 = _viewModel;
				Sprite lineImageSprite = (_viewModel.LineImageSprite2 = sprite);
				viewModel2.LineImageSprite1 = lineImageSprite;
			});
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "ak47herokillinfoback"), delegate(Sprite sprite)
			{
				Ak47heroViewModel viewModel = _viewModel;
				Sprite infoBackImageSprite = (_viewModel.InfoBackImageSprite2 = sprite);
				viewModel.InfoBackImageSprite1 = infoBackImageSprite;
			});
		}
	}

	private void UpdateOtherPosition(Vector3 pos)
	{
		_viewModel.OtherShowGposition2 = pos;
	}

	private void SetOtherShowAk47(PlayerEntity ov, PlayerEntity player)
	{
		if (player != null)
		{
			_otherPlayer = player;
			_viewModel.OtherShowShow2 = true;
			_viewModel.InfoBackImageAlpha2 = 1f;
			SetInfo(2, player.GetPlayerInfo().AkheroRecord);
		}
		else
		{
			_otherPlayer = null;
			_viewModel.OtherShowShow2 = false;
		}
	}

	private void SetShowAk47(bool ov, bool visible)
	{
		_viewModel.ShowShow1 = visible;
		if (visible)
		{
			_viewModel.LineImageFillamount1 = 0.1f;
			_viewModel.InfoBackImageAlpha1 = 0f;
			AKHeroRecord akHero = _weaponContext.currentWeaponEntity.basicInfo.Data.AkHero;
			SetInfo(1, akHero);
		}
	}

	private void SetInfo(int index, AKHeroRecord akHero, string weaponName = "ak47_hero")
	{
		if (akHero.Pvp != null)
		{
			_viewModel.SetKillTextString(index, akHero.Pvp.Kill.ToString());
			_viewModel.SetHeadKillTenTextString(index, (akHero.Pvp.Kill > 0) ? (akHero.Pvp.Headshot * 100 / akHero.Pvp.Kill).ToString("D2") : "00");
			_viewModel.SetHeadKillBitTextString(index, (akHero.Pvp.Kill > 0) ? (akHero.Pvp.Headshot * 10000 / akHero.Pvp.Kill % 100).ToString("D2") : "00");
			_viewModel.SetSecondKillTextString(index, akHero.Pvp.SecondaryKill.ToString());
		}
		else
		{
			_viewModel.SetKillTextString(index, "0");
			_viewModel.SetHeadKillTenTextString(index, "00");
			_viewModel.SetHeadKillBitTextString(index, "00");
			_viewModel.SetSecondKillTextString(index, "0");
		}
		if (akHero.Bio != null)
		{
			_viewModel.SetBioKillTextString(index, akHero.Bio.Kill.ToString());
			_viewModel.SetBioSecondKillTextString(index, akHero.Bio.SecondaryKill.ToString());
			if (akHero.Bio.Damage > 1000000000000000L)
			{
				_viewModel.SetBioDamageTextString(index, (akHero.Bio.Damage / 1000000000).ToString());
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "b"), delegate(Sprite sprite)
				{
					_viewModel.SetDamageImageSprite(index, sprite);
				});
			}
			else if (akHero.Bio.Damage > 1000000000000L)
			{
				_viewModel.SetBioDamageTextString(index, (akHero.Bio.Damage / 1000000).ToString());
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "m"), delegate(Sprite sprite)
				{
					_viewModel.SetDamageImageSprite(index, sprite);
				});
			}
			else if (akHero.Bio.Damage > 1000000000)
			{
				_viewModel.SetBioDamageTextString(index, (akHero.Bio.Damage / 1000).ToString());
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "k"), delegate(Sprite sprite)
				{
					_viewModel.SetDamageImageSprite(index, sprite);
				});
			}
			else
			{
				_viewModel.SetBioDamageTextString(index, akHero.Bio.Damage.ToString());
				_viewModel.SetDamageImageSprite(index, UiResourcesLoader.DefaultSprite);
			}
		}
		else
		{
			_viewModel.SetBioKillTextString(index, "0");
			_viewModel.SetBioSecondKillTextString(index, "0");
			_viewModel.SetBioDamageTextString(index, "0");
			_viewModel.SetDamageImageSprite(index, UiResourcesLoader.DefaultSprite);
		}
		if (akHero.Pve != null)
		{
			_viewModel.SetPveKillTextString(index, akHero.Pve.Kill.ToString());
			_viewModel.SetPveHeadKillTenTextString(index, (akHero.Pve.Kill > 0) ? (akHero.Pve.Headshot * 100 / akHero.Pve.Kill).ToString("D2") : "00");
			_viewModel.SetPveHeadKillBitTextString(index, (akHero.Pve.Kill > 0) ? (akHero.Pve.Headshot * 10000 / akHero.Pve.Kill % 100).ToString("D2") : "00");
			_viewModel.SetPveSecondKillTextString(index, akHero.Pve.SecondaryKill.ToString());
		}
		else
		{
			_viewModel.SetPveKillTextString(index, "0");
			_viewModel.SetPveHeadKillTenTextString(index, "00");
			_viewModel.SetPveHeadKillBitTextString(index, "00");
			_viewModel.SetPveSecondKillTextString(index, "0");
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
	}
}
