using SSJJUIEditor.UI;
using UnityEngine;

namespace Assets.Sources.Modules.Ui.UiEditorRunTime.UiLogicSystem;

public class DefaultRunTimeGui : IRunTimeGui
{
	public string Key { get; set; }

	public GameObject BindingGameObject { get; set; }

	public bool IsBinding { get; set; }

	public virtual void Binding(UiEditorLayoutAsset asset)
	{
		foreach (GameObject gameObject in asset.GameObjects)
		{
			if (gameObject.name.Equals(Key))
			{
				BindingGameObject = gameObject;
				break;
			}
		}
		if (BindingGameObject != null)
		{
			BindingGameObject.SetObjectActive(isactive: false);
		}
	}

	public virtual void PlayBack()
	{
	}
}
