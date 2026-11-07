using Assets.Sources.Components.Interface.SceneBuffAttach;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.SceneBuffAttach;

public class EnergyPrepareBuffAttach : ISceneBuffAttach
{
	public void Init()
	{
	}

	public void Render(int frameTime, SceneObjectEntity entity, SceneObjectEntity attachedEntity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		gameObject.transform.position = dest + new Vector3(0f, 160f, 0f);
		gameObject.transform.localScale = entity.scale.Scale;
		if (gameObject.GetComponentInChildren<TextMesh>() != null)
		{
			TextMesh componentInChildren = gameObject.GetComponentInChildren<TextMesh>();
			int num = (attachedEntity.hasSceneBuff ? (attachedEntity.sceneBuff.Data.AttachData / 1000) : 0);
			componentInChildren.text = num.ToString();
			if (num == 0)
			{
				gameObject.SetActive(value: false);
			}
			else
			{
				gameObject.SetActive(value: true);
			}
		}
	}

	public AssetInfo GetEffectAssetInfo()
	{
		return new AssetInfo("sceneeffectprefab/energyprepareattach", "EnergyPrepareAttach", typeof(GameObject), optional: true);
	}

	public ISceneBuffAttach Clone()
	{
		return new EnergyPrepareBuffAttach();
	}
}
