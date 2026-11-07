using System.Collections.Generic;
using Assets.Libs.UiEditor.RunTime;
using Assets.Libs.UiEditor.RunTime.RunTimeLogic.RunTimeNode;
using Assets.Sources.Components.Interface.Info.UiEditor;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEditorRunTime.UiLogicSystem;
using Entitas;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJUIEditor.UI;

namespace Assets.Sources.Modules.Ui.UiEditorRunTime;

public class RuleUiPlaybackSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _uis;

	private List<IRunTimeGui> _runGuis;

	private UserCommandContext _useCommand;

	public RuleUiPlaybackSystem(Contexts contexts)
	{
		_uis = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.RuleUiUnityObjects).NoneOf(SceneObjectMatcher.Destroy));
		_runGuis = new List<IRunTimeGui>();
		_runGuis.Add(new SkatePress());
		_useCommand = Contexts.sharedInstance.userCommand;
	}

	public void OnPlayback()
	{
		BattleSingletonInstance<DataProviderManager>.Instance.OnFrame();
		foreach (SceneObjectEntity ui in _uis)
		{
			for (int i = 0; i < ui.ruleUiUnityObjects.LayoutAssets.Count; i++)
			{
				IUiEditorLayoutAsset uiEditorLayoutAsset = ui.ruleUiUnityObjects.LayoutAssets[i];
				IUiEditorLogicAsset uiEditorLogicAsset = null;
				if (ui.ruleUiUnityObjects.LogicAssets.Count > i)
				{
					uiEditorLogicAsset = ui.ruleUiUnityObjects.LogicAssets[i];
				}
				PlayUiEditor(uiEditorLayoutAsset as UiEditorLayoutAsset, uiEditorLogicAsset as UiEditorLogicAsset);
			}
		}
		RunTimeBindingManager.Instance.OnFrame();
	}

	public void PlayUiEditor(UiEditorLayoutAsset layoutAsset, UiEditorLogicAsset logicAsset)
	{
		if (logicAsset != null && layoutAsset != null)
		{
			BattleSingletonInstance<DataProviderManager>.Instance.SetPlayerEntity(Contexts.sharedInstance.player.myPlayerEntity);
			logicAsset.OnFrame(layoutAsset, _useCommand.input.CursorControls, SingletonInstance<RunTimeDataArithmeticFunc>.Instance, BattleSingletonInstance<DataProviderManager>.Instance, RunTimeBindingManager.Instance);
		}
	}
}
