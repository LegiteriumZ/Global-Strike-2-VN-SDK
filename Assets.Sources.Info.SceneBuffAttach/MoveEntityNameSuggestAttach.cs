using Assets.Sources.Components.Interface.SceneBuffAttach;
using Assets.Sources.Constant;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.SceneBuffAttach;

public class MoveEntityNameSuggestAttach : ISceneBuffAttach
{
	public int SpriteIndex;

	private SpriteRenderer[] spriteRenderers;

	public void Init()
	{
	}

	public void Render(int frameTime, SceneObjectEntity entity, SceneObjectEntity attachedEntity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		if (spriteRenderers == null)
		{
			spriteRenderers = new SpriteRenderer[4];
			Transform child = gameObject.transform.GetChild(0);
			spriteRenderers[0] = child.Find("0").GetComponent<SpriteRenderer>();
			spriteRenderers[1] = child.Find("1").GetComponent<SpriteRenderer>();
			spriteRenderers[2] = child.Find("2").GetComponent<SpriteRenderer>();
			spriteRenderers[3] = child.Find("3").GetComponent<SpriteRenderer>();
		}
		VectorCoordConverter.SsjjToUnity(new Vector3(entity.sceneBuffAttach.MoveEntityData.X, entity.sceneBuffAttach.MoveEntityData.Y, entity.sceneBuffAttach.MoveEntityData.Z), out var dest);
		gameObject.transform.position = dest;
		if (entity.hasSceneBuffAttach && entity.sceneBuffAttach.MoveEntityData != null)
		{
			for (int i = 0; i < spriteRenderers.Length; i++)
			{
				spriteRenderers[i].enabled = ((i == entity.sceneBuffAttach.MoveEntityData.Team - 1) ? true : false);
			}
		}
	}

	public AssetInfo GetEffectAssetInfo()
	{
		return AssetBundleNameConstant.GetSceneEffectPrefabAssetInfo("MoveEntityNameSuggest");
	}

	public ISceneBuffAttach Clone()
	{
		return new MoveEntityNameSuggestAttach();
	}
}
