using Assets.Libs.UiEditor.RunTime;
using Assets.Libs.UiEditor.RunTime.RunTimeLogic.RunTimeNode;
using Assets.Sources.Framework;
using Entitas;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJUIEditor.UI;

namespace Assets.Sources.Modules.Ui.UiEditorRunTime;

public class UiEditorPlaybackSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _uis;

	private UserCommandContext _useCommand;

	public UiEditorPlaybackSystem(Contexts contexts)
	{
		_uis = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.WeaponUiUnityObjects).NoneOf(SceneObjectMatcher.Destroy));
		_useCommand = Contexts.sharedInstance.userCommand;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity ui in _uis)
		{
			PlayUiEditor(ui.weaponUiUnityObjects.LayoutAsset as UiEditorLayoutAsset, ui.weaponUiUnityObjects.LogicAsset as UiEditorLogicAsset);
		}
	}

	public void PlayUiEditor(UiEditorLayoutAsset layoutAsset, UiEditorLogicAsset logicAsset)
	{
		if (logicAsset != null && layoutAsset != null)
		{
			BattleSingletonInstance<DataProviderManager>.Instance.OnFrame();
			BattleSingletonInstance<DataProviderManager>.Instance.SetPlayerEntity(Contexts.sharedInstance.player.myPlayerEntity);
			logicAsset.OnFrame(layoutAsset, _useCommand.input.CursorControls, SingletonInstance<RunTimeDataArithmeticFunc>.Instance, BattleSingletonInstance<DataProviderManager>.Instance, RunTimeBindingManager.Instance);
		}
	}
}
