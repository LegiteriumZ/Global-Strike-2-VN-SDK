using Assets.Sources.Constant;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalKillBroadModel : CommonKillBroadModel
{
	protected const int InsaneFulinfection = 0;

	protected const int InsaneKill = 1;

	protected const int KillHero = 2;

	protected const int KnifeKill = 3;

	protected const int TidePurification = 4;

	protected const int TideInfection = 5;

	protected const int SpecialKill = 6;

	private const int InsaneKillCount = 5;

	private static AssetInfo _insanefulinfectionstringAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killbroad/insanefulinfectionstring.png");

	private static AssetInfo _killherostringAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killbroad/killherostring.png");

	private static AssetInfo _knifekillstringAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killbroad/knifekillstring.png");

	private static AssetInfo _insanefulinfectionAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killbroad/insanefulinfection.png");

	private static AssetInfo _insanekillAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killbroad/insanekill.png");

	private static AssetInfo _killheroAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killbroad/killhero.png");

	private static AssetInfo _knifekillAsset = new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/killbroad/knifekill.png");

	protected override void UpdateKillInfoImage(KillPlayerInfoData info)
	{
		if (KillTypeConstant.GetKillType(info) == 5 && ShowSpecialKillBroad(info.WeaponName))
		{
			UpdateBroadImage(info.WeaponName, info.KillPlayerName, info.KillTeam, info.CurKillNum, 6);
		}
		else if (WeaponConstant.IsKnifeByName(info.WeaponName))
		{
			UpdateBroadImage(info.WeaponName, info.KillPlayerName, info.KillTeam, info.CurKillNum, 3);
		}
		else if (info.KillTeam == 1 && info.CurKillNum != 0 && info.CurKillNum % 5 == 0)
		{
			UpdateBroadImage(info.WeaponName, info.KillPlayerName, info.KillTeam, info.CurKillNum, 1);
		}
	}

	private bool ShowSpecialKillBroad(string weaponName)
	{
		if ("double_scythe" == weaponName || "double_fangs_g" == weaponName || "axe_g" == weaponName || "shovel_g" == weaponName || "nbr_knife_g" == weaponName)
		{
			return true;
		}
		return false;
	}

	protected void UpdateBroadImage(string weaponName, string name, int team, int killNum, int flag)
	{
		GetPanelActiveChip().Time = 6000;
		UpdateName(name, team, 0);
		UpdateKillTypeImage(weaponName, flag);
		if (flag == 1)
		{
			UpdateKillNumberImage(killNum);
		}
		else
		{
			UpdateKillNumberImage(weaponName, flag);
		}
	}

	protected void UpdateKillNumberImage(string weaponName, int flag)
	{
		CommonkillbroadViewModel viewModel = ViewModel as CommonkillbroadViewModel;
		if (viewModel == null)
		{
			return;
		}
		switch (flag)
		{
		case 0:
			viewModel.KillNumberSprite = this.GetLoader().RetriveSprite(_insanefulinfectionstringAsset, delegate(Sprite sprite)
			{
				viewModel.KillNumberSprite = sprite;
				viewModel.KillNumberNtvsize();
			});
			break;
		case 2:
			viewModel.KillNumberSprite = this.GetLoader().RetriveSprite(_killherostringAsset, delegate(Sprite sprite)
			{
				viewModel.KillNumberSprite = sprite;
				viewModel.KillNumberNtvsize();
			});
			break;
		case 3:
			viewModel.KillNumberSprite = this.GetLoader().RetriveSprite(_knifekillstringAsset, delegate(Sprite sprite)
			{
				viewModel.KillNumberSprite = sprite;
				viewModel.KillNumberNtvsize();
			});
			break;
		case 6:
			viewModel.KillNumberSprite = this.GetLoader().RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "killbroadspecialkillstring"), delegate(Sprite sprite)
			{
				viewModel.KillNumberSprite = sprite;
				viewModel.KillNumberNtvsize();
			});
			break;
		case 1:
		case 4:
		case 5:
			break;
		}
	}

	protected override void UpdateName(string name, int team, int id)
	{
		if (ViewModel is CommonkillbroadViewModel commonkillbroadViewModel)
		{
			commonkillbroadViewModel.PlayerNameString = name;
			commonkillbroadViewModel.PlayerNameTextcolor = ((team == 2) ? new Color(0.199f, 1f, 0f) : new Color(0.266f, 0.805f, 0.961f));
		}
	}

	protected void UpdateKillTypeImage(string weaponName, int flag)
	{
		CommonkillbroadViewModel viewModel = ViewModel as CommonkillbroadViewModel;
		if (viewModel == null)
		{
			return;
		}
		switch (flag)
		{
		case 0:
			this.GetLoader().RetriveSprite(_insanefulinfectionAsset, delegate(Sprite sprite)
			{
				viewModel.KillTypeSprite = sprite;
			});
			break;
		case 1:
			this.GetLoader().RetriveSprite(_insanekillAsset, delegate(Sprite sprite)
			{
				viewModel.KillTypeSprite = sprite;
			});
			break;
		case 2:
			this.GetLoader().RetriveSprite(_killheroAsset, delegate(Sprite sprite)
			{
				viewModel.KillTypeSprite = sprite;
			});
			break;
		case 3:
			this.GetLoader().RetriveSprite(_knifekillAsset, delegate(Sprite sprite)
			{
				viewModel.KillTypeSprite = sprite;
			});
			break;
		case 6:
			this.GetLoader().RetriveSprite("weapon/" + weaponName, "Assets/Res/Assets/weapon/" + weaponName + "/killboardspecialkill.png", delegate(Sprite sprite)
			{
				viewModel.KillTypeSprite = sprite;
			});
			break;
		case 4:
		case 5:
			break;
		}
	}
}
