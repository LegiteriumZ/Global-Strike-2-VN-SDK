using Assets.Sources.Components.Interface.SceneBuffAttach;
using Assets.Sources.Constant;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.SceneBuffAttach;

public class RpgAnnihilationBufferSceneBuffAttach : ISceneBuffAttach
{
	public void Init()
	{
	}

	public void Render(int frameTime, SceneObjectEntity entity, SceneObjectEntity attachedEntity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		gameObject.transform.position = dest + new Vector3(0f, 0f, 0f);
		gameObject.transform.localScale = entity.scale.Scale;
	}

	public AssetInfo GetEffectAssetInfo()
	{
		return AssetBundleNameConstant.GetSceneEffectPrefabAssetInfo("RpgAnnihilationBuffer");
	}

	public ISceneBuffAttach Clone()
	{
		return new RpgAnnihilationBufferSceneBuffAttach();
	}
}
