using System.Collections.Generic;
using System.IO;
using Assets.Sources.Framework;
using Entitas;
using SSJJBase.Logger;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class LoadCustomWaterSystem : ReactiveSystem<SceneObjectEntity>, IPlaybackSystem
{
	private string foamStr = "";

	private string bumpStr = "";

	public LoadCustomWaterSystem(Contexts contexts)
		: base((IContext<SceneObjectEntity>)contexts.sceneObject)
	{
	}

	protected override ICollector<SceneObjectEntity> GetTrigger(IContext<SceneObjectEntity> context)
	{
		return context.CreateCollector(SceneObjectMatcher.UnityObjects.Added());
	}

	protected override bool Filter(SceneObjectEntity entity)
	{
		if (entity.hasCustomWater)
		{
			return entity.hasUnityObjects;
		}
		return false;
	}

	public void OnPlayback()
	{
		Execute();
	}

	protected override void Execute(List<SceneObjectEntity> entities)
	{
		foreach (SceneObjectEntity entity in entities)
		{
			Texture2D normal = null;
			Texture2D foam = null;
			if (entity.unityObjects.LoadResults.ContainsKey("BumpMap"))
			{
				normal = entity.unityObjects.LoadResults["BumpMap"].Object as Texture2D;
			}
			if (entity.unityObjects.LoadResults.ContainsKey("FoamMap"))
			{
				foam = entity.unityObjects.LoadResults["FoamMap"].Object as Texture2D;
			}
			byte[] datas = entity.customWater.Datas;
			InitWaterEffect(datas, normal, foam, entity);
			entity.RemoveCustomWater();
		}
	}

	private void InitWaterEffect(byte[] bytes, Texture2D normal, Texture2D foam, SceneObjectEntity entity)
	{
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(bytes)
		{
			Position = 0L
		});
		int num = binaryReader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			GameObject gameObject = new GameObject("water_" + (i + 1));
			Mesh mesh2 = (gameObject.AddComponent<MeshFilter>().sharedMesh = new Mesh());
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			Shader shader = null;
			shader = ((entity.customWater.WaterType != 0) ? Shader.Find("SSJJ/WaterCartoon") : Shader.Find("SSJJ/CustomWater"));
			Material material2 = (meshRenderer.sharedMaterial = new Material(shader));
			Vector3 vector = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			gameObject.transform.position = new Vector3(vector.z, vector.y, 0f - vector.x);
			Quaternion quaternion = Quaternion.Euler(VectorCoordConverter.SsjjRotationToUnity(new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle())));
			gameObject.transform.rotation = quaternion * Quaternion.Euler(0f, 90f, 0f);
			gameObject.transform.localScale = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			int num2 = binaryReader.ReadInt32();
			Vector3[] array = new Vector3[num2];
			for (int j = 0; j < num2; j++)
			{
				array[j] = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			}
			Vector2[] array2 = new Vector2[binaryReader.ReadInt32()];
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k] = new Vector2(binaryReader.ReadSingle(), binaryReader.ReadSingle());
			}
			int num3 = binaryReader.ReadInt32();
			int[] array3 = new int[num3];
			for (int l = 0; l < num3; l++)
			{
				array3[l] = binaryReader.ReadInt32();
			}
			mesh2.vertices = array;
			mesh2.uv = array2;
			mesh2.triangles = array3;
			mesh2.RecalculateNormals();
			int num4 = binaryReader.ReadInt32();
			for (int m = 0; m < num4; m++)
			{
				ReadPro(binaryReader, material2);
			}
			material2.SetTexture("_BumpMap", normal);
			if (foam != null)
			{
				if (foamStr.Equals("NormalBump"))
				{
					material2.SetTexture("_FoamMap", normal);
				}
				else
				{
					material2.SetTexture("_FoamMap", foam);
				}
			}
			if (entity.customWater.WaterType == 0)
			{
				FixPara(material2);
			}
		}
	}

	private void FixPara(Material mat)
	{
		Vector4 vector = mat.GetVector("_BumpDirection");
		float x = vector.x;
		vector.x = vector.y;
		vector.y = x;
		x = vector.z;
		vector.z = vector.w;
		vector.w = x;
		mat.SetVector("_BumpDirection", vector);
		vector = mat.GetVector("_BumpTiling");
		x = vector.x;
		vector.x = vector.y;
		vector.y = x;
		x = vector.z;
		vector.z = vector.w;
		vector.w = x;
		mat.SetVector("_BumpTiling", vector);
		Vector4 vector2 = mat.GetVector("_WorldLightDir");
		x = vector2.x;
		vector2.x = vector2.z;
		vector2.z = x;
		mat.SetVector("_WorldLightDir", vector2);
	}

	private void ReadPro(BinaryReader br, Material mat)
	{
		string text = br.ReadString();
		string text2 = br.ReadString();
		switch (text)
		{
		case "color":
		{
			Color value4 = new Color(br.ReadSingle(), br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
			mat.SetColor(text2, value4);
			break;
		}
		case "vector4":
		{
			Vector4 value3 = new Vector4(br.ReadSingle(), br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
			mat.SetVector(text2, value3);
			break;
		}
		case "float":
		{
			float value2 = br.ReadSingle();
			mat.SetFloat(text2, value2);
			break;
		}
		case "int":
		{
			int value = br.ReadInt32();
			mat.SetInt(text2, value);
			break;
		}
		case "string":
		{
			string text3 = br.ReadString();
			if (text2.Equals("_FoamMap"))
			{
				foamStr = text3;
			}
			else if (text2.Equals("_BumpMap"))
			{
				bumpStr = text3;
			}
			else
			{
				this.LogError("Error Sign " + text2);
			}
			break;
		}
		default:
			this.LogError("No Find Pro");
			break;
		}
	}
}
