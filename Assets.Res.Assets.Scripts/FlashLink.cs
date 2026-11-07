using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class FlashLink : MonoBehaviour
{
	private class LightningSegment
	{
		public Vector3 start;

		public Vector3 end;

		public Vector3 middle;

		public GameObject model;

		public LightningSegment lChild;

		public LightningSegment rChild;

		public LightningSegment(Vector3 s, Vector3 e)
		{
			start = s;
			end = e;
			lChild = null;
			rChild = null;
			model = null;
		}
	}

	public int maxSegLength = 100;

	public int height = 64;

	public float interval = 0.02f;

	public Vector3 start;

	public Vector3 end;

	private LightningSegment lightning;

	private float timer;

	private void Start()
	{
		lightning = CreateLightning(start, end);
		timer = 0f;
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer > interval)
		{
			UpdateLightning(lightning, start, end);
			timer = 0f;
		}
		DrawLightning(lightning);
	}

	private LightningSegment CreateLightning(Vector3 start, Vector3 end)
	{
		LightningSegment lightningSegment = new LightningSegment(start, end);
		lightningSegment.middle = new Vector3(start.x / 2f + end.x / 2f + Random.Range(-25f, 25f), start.y / 2f + end.y / 2f + Random.Range(-25f, 25f), start.z / 2f + end.z / 2f + Random.Range(-25f, 25f));
		if (Vector3.Distance(start, end) > (float)maxSegLength)
		{
			lightningSegment.lChild = CreateLightning(start, lightningSegment.middle);
			lightningSegment.rChild = CreateLightning(lightningSegment.middle, end);
		}
		return lightningSegment;
	}

	private void UpdateLightning(LightningSegment lightning, Vector3 start, Vector3 end)
	{
		if (lightning != null)
		{
			lightning.start = start;
			lightning.end = end;
			lightning.middle = new Vector3(lightning.start.x / 2f + lightning.end.x / 2f + Random.Range(-25f, 25f), lightning.start.y / 2f + lightning.end.y / 2f + Random.Range(-25f, 25f), lightning.start.z / 2f + lightning.end.z / 2f + Random.Range(-25f, 25f));
			UpdateLightning(lightning.lChild, lightning.start, lightning.middle);
			UpdateLightning(lightning.rChild, lightning.middle, lightning.end);
		}
	}

	private void DisableLightning(LightningSegment lightning)
	{
		if (lightning != null && !(lightning.model == null))
		{
			lightning.model.SetObjectActive(isactive: false);
			DisableLightning(lightning.lChild);
			DisableLightning(lightning.rChild);
		}
	}

	private void DrawLightning(LightningSegment lightning)
	{
		if (lightning == null)
		{
			return;
		}
		if (lightning.lChild == null && lightning.rChild == null)
		{
			if (lightning.model == null)
			{
				lightning.model = new GameObject();
				lightning.model.name = "LightningSegment";
				lightning.model.transform.parent = base.gameObject.transform;
				lightning.model.transform.position = Vector3.zero;
			}
			if (lightning.model.GetComponent<MeshRenderer>() == null)
			{
				MeshRenderer meshRenderer = lightning.model.AddComponent<MeshRenderer>();
				Material sharedMaterial = base.transform.GetComponent<MeshRenderer>().sharedMaterial;
				sharedMaterial.renderQueue = 3001;
				meshRenderer.sharedMaterial = sharedMaterial;
			}
			MeshFilter meshFilter = lightning.model.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = lightning.model.AddComponent<MeshFilter>();
			}
			Vector3 normalized = Vector3.Cross(lightning.start - lightning.end, Camera.main.transform.forward).normalized;
			meshFilter.mesh.Clear();
			meshFilter.mesh.vertices = new Vector3[4]
			{
				lightning.start + normalized * maxSegLength * 0.125f,
				lightning.end + normalized * maxSegLength * 0.125f,
				lightning.end - normalized * maxSegLength * 0.125f,
				lightning.start - normalized * maxSegLength * 0.125f
			};
			meshFilter.mesh.triangles = new int[6] { 0, 1, 3, 1, 2, 3 };
			meshFilter.mesh.uv = new Vector2[4]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(1f, 1f),
				new Vector2(0f, 1f)
			};
			meshFilter.mesh.RecalculateBounds();
			meshFilter.mesh.RecalculateNormals();
			if (lightning.model.GetComponent<ModelTextureSheetAnimation>() == null)
			{
				ModelTextureSheetAnimation component = base.gameObject.GetComponent<ModelTextureSheetAnimation>();
				ModelTextureSheetAnimation modelTextureSheetAnimation = lightning.model.AddComponent<ModelTextureSheetAnimation>();
				modelTextureSheetAnimation.Textures = component.Textures;
				modelTextureSheetAnimation.Speed = component.Speed;
				modelTextureSheetAnimation.MinMap = component.MinMap;
				modelTextureSheetAnimation.IsLoop = component.IsLoop;
				modelTextureSheetAnimation.ShareMaterial = true;
			}
		}
		else
		{
			DrawLightning(lightning.lChild);
			DrawLightning(lightning.rChild);
		}
	}
}
