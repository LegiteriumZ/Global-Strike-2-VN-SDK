using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Res.Assets.Scripts.PrefabInstance;
using UnityEngine;

namespace Assets.Scripts.Asset;

public class WeaponGameObject : ReusableGameObjectBase
{
	private Dictionary<Renderer, Material[]> _materials = new Dictionary<Renderer, Material[]>();

	public List<RenderTexture> DynamicSkinTexture;

	public override void OnCreated()
	{
		Queue<Transform> queue = new Queue<Transform>();
		queue.Enqueue(GetGameObject().transform);
		while (queue.Count > 0)
		{
			Transform transform = queue.Dequeue();
			for (int i = 0; i < transform.childCount; i++)
			{
				if (!(transform.GetChild(i).GetComponent<PaticlePrefabInstancecs>() != null))
				{
					queue.Enqueue(transform.GetChild(i));
				}
			}
			GameObject gameObject = transform.gameObject;
			Renderer component = gameObject.GetComponent<Renderer>();
			if ((component is SkinnedMeshRenderer || component is MeshRenderer) && !(gameObject.GetComponent<ModelTextureSheetAnimation>() != null) && !(gameObject.GetComponent<GroupModelTextureSheetAnimation>() != null) && !(gameObject.GetComponent<PaticlePrefabInstancecs>() != null) && !(gameObject.GetComponent<FireModelMeshEffect>() != null) && (!(gameObject.transform.parent != null) || !(transform.transform.parent.GetComponent<ParticleSystem>() != null)))
			{
				_materials[component] = component.sharedMaterials;
			}
		}
	}

	public override void OnRecycle()
	{
		foreach (KeyValuePair<Renderer, Material[]> material in _materials)
		{
			material.Key.sharedMaterials = material.Value;
		}
	}

	public ICollection<Renderer> GetSkinRenderers()
	{
		return _materials.Keys;
	}

	private void OnDestroy()
	{
		if (DynamicSkinTexture != null)
		{
			for (int i = 0; i < DynamicSkinTexture.Count; i++)
			{
				DynamicSkinTexture[i].Release();
			}
		}
	}
}
