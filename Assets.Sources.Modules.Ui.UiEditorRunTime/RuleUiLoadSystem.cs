using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.UiEditor;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Entitas;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJUIEditor.UI;

namespace Assets.Sources.Modules.Ui.UiEditorRunTime;

public class RuleUiLoadSystem : LoadAndInitResourceSystem<SceneObjectEntity>
{
	public delegate bool GetRule();

	internal class RuleContent
	{
		public string Name;

		public GetRule GetRule;

		public AssetInfo LayoutAssetInfo;

		public AssetInfo LogicAssetInfo;
	}

	private IGroup<SceneObjectEntity> _loadGroup;

	private IGroup<SceneObjectEntity> _initGroup;

	private List<RuleContent> _rules;

	public RuleUiLoadSystem(Contexts contexts)
	{
		_loadGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.RuleUiCompoent).NoneOf(SceneObjectMatcher.RuleUiUnityObjects, SceneObjectMatcher.LoadRuleUiResource, SceneObjectMatcher.RuleUiResource, SceneObjectMatcher.Destroy));
		_initGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.RuleUiCompoent, SceneObjectMatcher.RuleUiResource).NoneOf(SceneObjectMatcher.RuleUiUnityObjects, SceneObjectMatcher.Destroy));
		int raceType = contexts.battleRoom.roomData.Data.RaceType;
		_rules = new List<RuleContent>
		{
			new RuleContent
			{
				Name = "commonLayout",
				GetRule = () => true,
				LayoutAssetInfo = new AssetInfo("ui/common", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/common", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgLayout",
				GetRule = () => RuleUtilty.IsRpg(raceType),
				LayoutAssetInfo = new AssetInfo("ui/rpgModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "bigHeadLayout",
				GetRule = () => RuleUtilty.IsBigHeadModel(raceType),
				LayoutAssetInfo = new AssetInfo("ui/bigheadModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bigheadModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgmode",
				GetRule = () => RuleUtilty.IsRpg(raceType),
				LayoutAssetInfo = new AssetInfo("ui/rpgModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "bioLayout",
				GetRule = () => RuleUtilty.IsBioMode(raceType),
				LayoutAssetInfo = new AssetInfo("ui/bioModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bioModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "bladeFightLayout",
				GetRule = () => RuleUtilty.IsBladeFightModel(raceType),
				LayoutAssetInfo = new AssetInfo("ui/bladefightmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bladefightmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "explodewdLayout",
				GetRule = () => raceType == 18014,
				LayoutAssetInfo = new AssetInfo("ui/explodewdmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/explodewdmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "BioEvolution",
				GetRule = () => raceType == 119 || raceType == 122,
				LayoutAssetInfo = new AssetInfo("ui/bioEvolutionmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bioEvolutionmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "BigHeadP3",
				GetRule = () => raceType == 90,
				LayoutAssetInfo = new AssetInfo("ui/bigheadp3model", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bigheadp3model", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "protectBigHead",
				GetRule = () => raceType == 141,
				LayoutAssetInfo = new AssetInfo("ui/protectBigHeadModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/protectBigHeadModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgBaseRunModel",
				GetRule = () => RuleUtilty.IsBaseRun(raceType),
				LayoutAssetInfo = new AssetInfo("ui/rpgBaseRunModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgBaseRunModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgTanlanModel",
				GetRule = () => RuleUtilty.IsTanLanRun(raceType),
				LayoutAssetInfo = new AssetInfo("ui/rpgTanlanModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgTanlanModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgTanlanModel",
				GetRule = () => RuleUtilty.IsTanLanZhanShu(raceType),
				LayoutAssetInfo = new AssetInfo("ui/rpgTanlanModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgTanlanModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgStarWalkerModel",
				GetRule = () => RuleUtilty.IsStarWalker(raceType),
				LayoutAssetInfo = new AssetInfo("ui/rpgStarWalkerModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgStarWalkerModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "bioUnionBase",
				GetRule = () => RuleUtilty.IsBioUnion(raceType),
				LayoutAssetInfo = new AssetInfo("ui/bioUnionBase", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bioUnionBase", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgLootLayout",
				GetRule = () => raceType == 15008,
				LayoutAssetInfo = new AssetInfo("ui/rpglootmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpglootmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgLootMineModel",
				GetRule = () => raceType == 15009,
				LayoutAssetInfo = new AssetInfo("ui/rpglootminemodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpglootminemodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgStealExpertModel",
				GetRule = () => raceType == 15010,
				LayoutAssetInfo = new AssetInfo("ui/rpgstralexpertmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgstralexpertmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgArmamentModel",
				GetRule = () => raceType == 15013,
				LayoutAssetInfo = new AssetInfo("ui/rpgarmamentmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgarmamentmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "peekabooModel",
				GetRule = () => raceType == 25,
				LayoutAssetInfo = new AssetInfo("ui/peekabooModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/peekabooModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgMysteryNew",
				GetRule = () => raceType == 17000,
				LayoutAssetInfo = new AssetInfo("ui/freerpg_107000model", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/freerpg_107000model", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "bioEvolutionChallenge",
				GetRule = () => raceType == 122,
				LayoutAssetInfo = new AssetInfo("ui/bioEvolutionChallengeModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bioEvolutionChallengeModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgSplitSecond",
				GetRule = () => raceType == 15011,
				LayoutAssetInfo = new AssetInfo("ui/rpgsplitsecond", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgsplitsecond", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgDanrenMineModel",
				GetRule = () => raceType == 18017,
				LayoutAssetInfo = new AssetInfo("ui/rpgdanrenminemodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgdanrenminemodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "BroadSwordModel",
				GetRule = () => raceType == 123,
				LayoutAssetInfo = new AssetInfo("ui/BroadSwordModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/BroadSwordModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "MeshKingModel",
				GetRule = () => raceType == 124,
				LayoutAssetInfo = new AssetInfo("ui/mechkingmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/mechkingmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgHolidayModel",
				GetRule = () => raceType == 18018,
				LayoutAssetInfo = new AssetInfo("ui/rpgholidaymodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgholidaymodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "GunFightModel",
				GetRule = () => raceType == 125,
				LayoutAssetInfo = new AssetInfo("ui/gunfightmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/gunfightmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "GunFightModel",
				GetRule = () => raceType == 130,
				LayoutAssetInfo = new AssetInfo("ui/goldrankmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/goldrankmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "GunFightModel",
				GetRule = () => raceType == 131,
				LayoutAssetInfo = new AssetInfo("ui/knifefightmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/knifefightmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "BigHeadKnife2Model",
				GetRule = () => raceType == 126,
				LayoutAssetInfo = new AssetInfo("ui/bigHeadKnife2Model", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bigHeadKnife2Model", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "CompeteKingModel",
				GetRule = () => raceType == 128,
				LayoutAssetInfo = new AssetInfo("ui/CompeteKingModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/CompeteKingModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "AllRoundSinglesModel",
				GetRule = () => raceType == 160,
				LayoutAssetInfo = new AssetInfo("ui/AllRoundSinglesModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/AllRoundSinglesModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "highSpeedGroupModel",
				GetRule = () => raceType == 91,
				LayoutAssetInfo = new AssetInfo("ui/highSpeedGroupModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/highSpeedGroupModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "bladeStrongholdNewModel",
				GetRule = () => raceType == 140,
				LayoutAssetInfo = new AssetInfo("ui/bladeStrongholdNewModel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/bladeStrongholdNewModel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			},
			new RuleContent
			{
				Name = "rpgtreasurebossmodel",
				GetRule = () => raceType == 121003,
				LayoutAssetInfo = new AssetInfo("ui/rpgtreasurebossmodel", "ui_layout.xml", typeof(UiEditorLayoutAsset), optional: true),
				LogicAssetInfo = new AssetInfo("ui/rpgtreasurebossmodel", "ui_logic.xml", typeof(UiEditorLogicAsset), optional: true)
			}
		};
	}

	protected override IGroup<SceneObjectEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<SceneObjectEntity> GetInitGroup()
	{
		return _initGroup;
	}

	protected override void OnLoadEntityResource(SceneObjectEntity entity)
	{
		if (!entity.ruleUiCompoent.IsLoad)
		{
			return;
		}
		LoadRequests loadRequests = new LoadRequests();
		foreach (RuleContent rule in _rules)
		{
			if (rule.GetRule())
			{
				loadRequests.Add(rule.Name + "_layout", new LoadRequest(rule.LayoutAssetInfo));
				loadRequests.Add(rule.Name + "_logic", new LoadRequest(rule.LogicAssetInfo));
			}
		}
		entity.AddLoadRuleUiResource(loadRequests, entity.ruleUiCompoent.GetHashCode());
	}

	protected override bool IsResourceMatch(SceneObjectEntity entity)
	{
		return true;
	}

	protected override void CleanResouceComponent(SceneObjectEntity entity)
	{
		entity.RemoveRuleUiResource();
	}

	protected override void OnInitEntityResource(SceneObjectEntity entity)
	{
		LoadResults loadResults = entity.ruleUiResource.LoadResults;
		List<IUiEditorLayoutAsset> list = new List<IUiEditorLayoutAsset>();
		List<IUiEditorLogicAsset> list2 = new List<IUiEditorLogicAsset>();
		foreach (RuleContent rule in _rules)
		{
			if (loadResults.ContainsKey(rule.Name + "_layout"))
			{
				UiEditorLayoutAsset uiEditorLayoutAsset = UiEditorLayoutAssetResultUtil.GetUiEditorLayoutAsset(loadResults[rule.Name + "_layout"]);
				uiEditorLayoutAsset.GetGameObject().transform.SetParent(MonoBehaviourSingleton<UiEditorParentManager>.Instance.Parent.transform, worldPositionStays: false);
				list.Add(uiEditorLayoutAsset);
			}
			if (loadResults.ContainsKey(rule.Name + "_logic"))
			{
				UiEditorLogicAsset item = loadResults[rule.Name + "_logic"].Object as UiEditorLogicAsset;
				list2.Add(item);
			}
		}
		entity.AddRuleUiUnityObjects(list, list2);
	}
}
