using UnityEngine;

namespace Assets.UiFramework.Libs;

public interface IUiViewModel
{
	string ResourceBundleName { get; }

	string ResourceAssetName { get; }

	string ConfigBundleName { get; }

	string ConfigAssetName { get; }

	void CreateBinding(GameObject obj);

	bool IsPropertyExist(string name);

	Transform GetParentLinkNode();

	Transform GetChildLinkNode();

	void Destory();

	void Visible(bool isVisible);
}
