using System.Collections.Generic;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Utils;

public class UIResourceUtility
{
	private static HashSet<string> folderUiTexture = new HashSet<string>
	{
		"rocketModel", "rpgGroupModel", "robchickenGroupModel", "robchickenModel", "robchickenModel", "rpgSurviveModel", "weaponMasterModel", "rpgModel", "rpgRescueModel", "pvecommon",
		"common", "commonfree", "bio2Model", "bioModel", "intelligenceModel", "jumpModel", "escapeModel"
	};

	public static Dictionary<int, string> modelUrlDic = new Dictionary<int, string>
	{
		{ 6, "bioModel" },
		{ 117, "bioModel" },
		{ 7, "herocraftModel" },
		{ 14, "finalbioModel" },
		{ 118, "finalbioModel" },
		{ 16, "superbioModel" },
		{ 17, "ghostbioModel" },
		{ 2, "blastModel" },
		{ 23, "ghostExplodeModel" },
		{ 8, "blastModel" },
		{ 12, "deathMatchModel" },
		{ 15, "deathMatchModel" },
		{ 13, "deathMatchModel" },
		{ 5, "personalModel" },
		{ 32, "groupRechargeModel" },
		{ 11, "recreationGroupModel" },
		{ 22, "recreation2GroupModel" },
		{ 9, "gunkingModel" },
		{ 10, "groupGunkingModel" },
		{ 19, "bigheadModel" },
		{ 141, "protectBigHeadModel" },
		{ 90, "bigheadModel" },
		{ 20, "awakebioModel" },
		{ 1001, "towerDefenseModel" },
		{ 1002, "titanlaboratoryModel" },
		{ 24, "groupHeroModel" },
		{ 25, "peekabooModel" },
		{ 1003, "diestrikeModel" },
		{ 26, "bladestrongholdModel" },
		{ 27, "goldExplodeModel" },
		{ 28, "tidebioModel" },
		{ 29, "mechwarriorModel" },
		{ 30, "jumpModel" },
		{ 1004, "lostTempleModel" },
		{ 31, "biomechModel" },
		{ 33, "bio2Model" },
		{ 34, "robchickenModel" },
		{ 37, "robchickenGroupModel" },
		{ 1005, "lostGraveModel" },
		{ 38, "escapeModel" },
		{ 39, "intelligenceModel" },
		{ 2019, "bigheadModel" },
		{ 35, "bigheadModel" },
		{ 36, "bigheadModel" },
		{ 60, "rocketModel" },
		{ 10000, "rpgModel" },
		{ 61, "goldExplodeModel" },
		{ -3, "rpgModel" },
		{ 62, "blastModel" },
		{ 63, "deathMatchModel" },
		{ 64, "weaponMasterModel" },
		{ 15000, "rpgGroupModel" },
		{ 15002, "rpgGroupModel" },
		{ 15004, "rpgGroupModel" },
		{ 146, "bioUnionBase" },
		{ 145, "bioUnionBase" },
		{ 147, "bioUnionBase" }
	};

	public static AssetInfo GetWeaponUISelfKillTextureName(string weaponName, string selfName)
	{
		return new AssetInfo($"weapon/{weaponName}", $"Assets/Res/Assets/weapon/{weaponName}/ui/{selfName}.png");
	}

	public static AssetInfo GetCommonTextureName(string name)
	{
		return new AssetInfo("ui/common", $"Assets/Res/Assets/ui/GameGUIRes/common/{name}.png");
	}

	public static AssetInfo GetOtherModelTextureName(string name, int rule)
	{
		string otherModelUrl = GetOtherModelUrl(rule);
		if (folderUiTexture.Contains(name))
		{
			name = name.Replace("-", "/");
		}
		return new AssetInfo($"ui/{otherModelUrl}", $"Assets/Res/Assets/ui/GameGUIRes/{otherModelUrl}/{name}.png");
	}

	public static string GetModelUrlByRaceType(int raceType)
	{
		if (RuleUtilty.IsGeneralPve(raceType) && !RuleUtilty.IsRpg(raceType))
		{
			return modelUrlDic[10000];
		}
		if (modelUrlDic.ContainsKey(raceType))
		{
			return modelUrlDic[raceType];
		}
		return "common";
	}

	private static string GetOtherModelUrl(int raceType)
	{
		switch (raceType)
		{
		case 32:
			return "groupRechargeModel";
		case 12:
		case 63:
			return "deathMatchModel";
		default:
			return "common";
		}
	}

	public static AssetInfo GetModelTextureName(string name, int raceType)
	{
		string modelUrlByRaceType = GetModelUrlByRaceType(raceType);
		return new AssetInfo($"ui/{modelUrlByRaceType}", $"Assets/Res/Assets/ui/GameGUIRes/{modelUrlByRaceType}/{name}.png");
	}
}
