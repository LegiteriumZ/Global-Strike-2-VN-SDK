using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class SparyTextures : MonoBehaviour
{
	public static Font font;

	public Texture2D Texture;

	public int ResId;

	private static int renderQueueValue = 2001;

	private static Color[] nameTexPixels;

	private static Dictionary<string, Texture2D> nameTexCache;

	public bool HasName;

	public int colorId;

	public string Name;

	public Mesh mesh;

	private MeshRenderer meshRenderer;

	private MeshFilter meshFilter;

	protected int nameTexSize = 256;

	private Material material;

	private MeshRenderer nameMeshRenderer;

	private MeshFilter nameMeshFilter;

	private Material nameMaterial;

	public Color[] NameColors = new Color[4]
	{
		new Color(1f, 1f, 1f),
		new Color(1f, 1f, 0f),
		new Color(0.445f, 0.16f, 0.0234f),
		new Color(1f, 0.8f, 0f)
	};

	private void BuildTextureWithName(string str)
	{
		if (font == null)
		{
			return;
		}
		font.RequestCharactersInTexture($"{str}.", 20);
		Texture2D readableTexture2D = GetReadableTexture2D((Texture2D)font.material.mainTexture);
		CharacterInfo info = default(CharacterInfo);
		int num = 0;
		for (int i = 0; i < str.Length; i++)
		{
			font.GetCharacterInfo(str[i], out info);
			if (num + info.advance > 150)
			{
				str = str.Substring(0, i) + "...";
				font.GetCharacterInfo('.', out info);
				num += info.advance * 3;
				break;
			}
			num += info.advance;
		}
		if (nameTexCache.ContainsKey(str))
		{
			material.SetTexture("_SecTex", nameTexCache[str]);
			nameMaterial.SetTexture("_SecTex", nameTexCache[str]);
			return;
		}
		Texture2D texture2D = new Texture2D(nameTexSize, nameTexSize);
		for (int j = 0; j < nameTexSize * nameTexSize; j++)
		{
			nameTexPixels[j] = Color.clear;
		}
		int num2 = (nameTexSize - num) / 2;
		int num3 = 11;
		for (int k = 0; k < str.Length; k++)
		{
			font.GetCharacterInfo(str[k], out info);
			for (int l = info.minX; l <= info.maxX; l++)
			{
				for (int m = info.minY; m <= info.maxY; m++)
				{
					int num4 = num2 + l;
					int num5 = (num3 + m) * texture2D.width + num4;
					Vector2 vector = info.uvBottomLeft + 1f * (float)(l - info.minX) / (float)info.glyphWidth * (info.uvBottomRight - info.uvBottomLeft) + 1f * (float)(m - info.minY) / (float)info.glyphHeight * (info.uvTopLeft - info.uvBottomLeft);
					if ((double)Mathf.Abs(info.uvTopLeft.x - info.uvBottomLeft.x) < 0.01 && info.uvTopLeft.y > info.uvBottomLeft.y)
					{
						vector.y -= 1f / (float)readableTexture2D.height;
					}
					if ((double)Mathf.Abs(info.uvTopLeft.y - info.uvBottomLeft.y) < 0.01 && info.uvTopLeft.x > info.uvBottomLeft.x)
					{
						vector.x -= 1f / (float)readableTexture2D.width;
					}
					if (!((double)nameTexPixels[num5].a > 0.001))
					{
						nameTexPixels[num5] = readableTexture2D.GetPixelBilinear(vector.x, vector.y);
					}
				}
			}
			num2 += info.advance;
		}
		texture2D.SetPixels(nameTexPixels);
		texture2D.Apply();
		material.SetTexture("_SecTex", texture2D);
		nameMaterial.SetTexture("_SecTex", texture2D);
		nameTexCache.Add(str, texture2D);
	}

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		meshFilter = GetComponent<MeshFilter>();
		if (font == null)
		{
			font = Font.CreateDynamicFontFromOSFont(new string[2] { "微软雅黑", "宋体" }, 20);
		}
		if (nameTexPixels == null)
		{
			nameTexPixels = new Color[nameTexSize * nameTexSize];
		}
		if (nameTexCache == null)
		{
			nameTexCache = new Dictionary<string, Texture2D>();
		}
		material = meshRenderer.material;
		material.renderQueue = renderQueueValue++;
	}

	private void Update()
	{
		meshFilter.mesh = mesh;
		material.SetTexture("_MainTex", Texture);
		if (!string.IsNullOrEmpty(Name) && HasName)
		{
			if (nameMaterial == null)
			{
				GameObject gameObject = new GameObject("Name");
				gameObject.transform.SetParent(meshRenderer.transform, worldPositionStays: false);
				gameObject.transform.localPosition = Vector3.zero;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localScale = Vector3.one;
				nameMeshRenderer = gameObject.AddComponent<MeshRenderer>();
				nameMeshFilter = gameObject.AddComponent<MeshFilter>();
				nameMaterial = Object.Instantiate(material);
				nameMaterial.shader = Shader.Find("SSJJ/SparyDecalName");
				nameMeshRenderer.sharedMaterial = nameMaterial;
				nameMaterial.renderQueue = material.renderQueue + 1;
			}
			nameMeshRenderer.gameObject.SetObjectActive(isactive: true);
			nameMeshFilter.mesh = mesh;
			if (nameMaterial.GetTexture("_SecTex") == null)
			{
				BuildTextureWithName(Name);
			}
		}
		else if (nameMeshRenderer != null)
		{
			nameMeshRenderer.gameObject.SetObjectActive(isactive: false);
		}
		if (colorId < NameColors.Length)
		{
			material.SetColor("_Color", NameColors[colorId]);
			if (nameMaterial != null)
			{
				nameMaterial.SetColor("_Color", NameColors[colorId]);
			}
		}
	}

	private Texture2D ReadTexture2PNG(string path, Texture2D tex)
	{
		byte[] data = File.ReadAllBytes(path);
		Texture2D texture2D = new Texture2D(tex.width, tex.height);
		texture2D.LoadImage(data);
		return texture2D;
	}

	private void DestoryFile(string path)
	{
		File.Delete(path);
	}

	private void SaveTexture2PNG(string path, Texture2D tex)
	{
		byte[] bytes = tex.EncodeToPNG();
		File.WriteAllBytes(path, bytes);
	}

	private Texture2D GetReadableTexture2D(Texture2D unreadableTex)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(unreadableTex.width, unreadableTex.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
		Graphics.Blit(unreadableTex, temporary);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = temporary;
		Texture2D texture2D = new Texture2D(unreadableTex.width, unreadableTex.height);
		texture2D.ReadPixels(new Rect(0f, 0f, temporary.width, temporary.height), 0, 0);
		texture2D.Apply();
		RenderTexture.active = active;
		RenderTexture.ReleaseTemporary(temporary);
		return texture2D;
	}

	private void OnEnable()
	{
		mesh = null;
		meshFilter.mesh = null;
		if (nameMeshFilter != null)
		{
			nameMeshFilter.mesh = null;
		}
		if (nameMeshRenderer != null)
		{
			nameMeshRenderer.gameObject.SetObjectActive(isactive: false);
		}
	}
}
