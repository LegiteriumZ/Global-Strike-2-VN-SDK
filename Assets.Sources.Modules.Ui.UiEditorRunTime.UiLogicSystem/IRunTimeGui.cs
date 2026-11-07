using SSJJUIEditor.UI;
using UnityEngine;

namespace Assets.Sources.Modules.Ui.UiEditorRunTime.UiLogicSystem;

public interface IRunTimeGui
{
	string Key { get; set; }

	GameObject BindingGameObject { get; set; }

	bool IsBinding { get; set; }

	void Binding(UiEditorLayoutAsset asset);

	void PlayBack();
}
