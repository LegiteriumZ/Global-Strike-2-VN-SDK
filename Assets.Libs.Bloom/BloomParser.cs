using System;
using System.IO;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Libs.Bloom;

public class BloomParser
{
	public void Parse(byte[] datas, IMapAssetLoader mapLoader)
	{
		BinaryReader binaryReader = new BinaryReader(new MemoryStream(datas)
		{
			Position = 0L
		});
		SelfBloom selfBloom = Camera.main.gameObject.AddComponent<SelfBloom>();
		int num = binaryReader.ReadInt32();
		Type type = selfBloom.GetType();
		for (int i = 0; i < num; i++)
		{
			string name = binaryReader.ReadString();
			type.GetField(name).SetValue(selfBloom, binaryReader.ReadSingle());
		}
		int num2 = binaryReader.ReadInt32();
		GameObject gameObject = new GameObject("BloomObject");
		for (int j = 0; j < num2; j++)
		{
			GameObject gameObject2 = new GameObject(binaryReader.ReadString());
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.transform.position = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			gameObject2.transform.eulerAngles = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			gameObject2.transform.localScale = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			string text = binaryReader.ReadString();
			Material material = new Material(Shader.Find(text));
			if (text.Equals("SSJJ/DiffuseBloom"))
			{
				material.SetTexture("_MainTex", mapLoader.GetTexture(binaryReader.ReadString()));
				material.SetInt("_AddColor", 5);
			}
			else if (text.Equals("Wooduan/Self-Illumin/DiffuseBloom"))
			{
				material.SetTexture("_MainTex", mapLoader.GetTexture(binaryReader.ReadString()));
				material.SetTexture("_LightMap", mapLoader.GetTexture(binaryReader.ReadString()));
				material.SetInt("_AddColor", 5);
			}
			else
			{
				Debug.LogError("Error ShaderName " + text);
			}
			gameObject2.AddComponent<MeshRenderer>().sharedMaterial = material;
			Mesh mesh = new Mesh();
			int num3 = binaryReader.ReadInt32();
			Vector3[] array = new Vector3[num3];
			for (int k = 0; k < num3; k++)
			{
				array[k] = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
			}
			Vector2[] array2 = new Vector2[binaryReader.ReadInt32()];
			for (int l = 0; l < array2.Length; l++)
			{
				array2[l] = new Vector2(binaryReader.ReadSingle(), binaryReader.ReadSingle());
			}
			Vector2[] array3 = new Vector2[binaryReader.ReadInt32()];
			for (int m = 0; m < array3.Length; m++)
			{
				array3[m] = new Vector2(binaryReader.ReadSingle(), binaryReader.ReadSingle());
			}
			int num4 = binaryReader.ReadInt32();
			int[] array4 = new int[num4];
			for (int n = 0; n < num4; n++)
			{
				array4[n] = binaryReader.ReadInt32();
			}
			mesh.vertices = array;
			mesh.uv = array2;
			mesh.uv2 = array3;
			mesh.triangles = array4;
			mesh.RecalculateNormals();
			gameObject2.AddComponent<MeshFilter>().sharedMesh = mesh;
		}
	}
}
