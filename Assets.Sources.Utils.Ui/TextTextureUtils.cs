using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Utils.Ui;

public static class TextTextureUtils
{
	private static Dictionary<string, TextTexture> _fontRes = new Dictionary<string, TextTexture>();

	public static TextTexture GetTextTexture(string name)
	{
		if (!_fontRes.ContainsKey(name))
		{
			TextTexture textTexture = new TextTexture();
			textTexture.Name = name;
			Font font = Font.CreateDynamicFontFromOSFont("SimSun", 16);
			font.RequestCharactersInTexture(name);
			textTexture.Font = font;
			Material material = font.material.CreateInstance();
			material.color = new Color(0f, 1f, 0f, 1f);
			textTexture.TextMat = material;
			material = font.material.CreateInstance();
			material.color = new Color(3f / 85f, 0.4862745f, 0f, 38f / 51f);
			textTexture.OutlineMat = material;
			Mesh mesh = new Mesh();
			textTexture.Size = RebuildMesh(mesh, name, font);
			textTexture.Mesh = mesh;
			_fontRes[name] = textTexture;
		}
		return _fontRes[name];
	}

	public static Vector3 RebuildMesh(Mesh mesh, string str, Font font)
	{
		Vector3[] array = new Vector3[str.Length * 4];
		int[] array2 = new int[str.Length * 6];
		Vector2[] array3 = new Vector2[str.Length * 4];
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < str.Length; i++)
		{
			font.GetCharacterInfo(str[i], out var info);
			array[4 * i] = zero + new Vector3(info.minX, info.maxY, 0f);
			array[4 * i + 1] = zero + new Vector3(info.maxX, info.maxY, 0f);
			array[4 * i + 2] = zero + new Vector3(info.maxX, info.minY, 0f);
			array[4 * i + 3] = zero + new Vector3(info.minX, info.minY, 0f);
			array3[4 * i] = info.uvTopLeft;
			array3[4 * i + 1] = info.uvTopRight;
			array3[4 * i + 2] = info.uvBottomRight;
			array3[4 * i + 3] = info.uvBottomLeft;
			array2[6 * i] = 4 * i;
			array2[6 * i + 1] = 4 * i + 1;
			array2[6 * i + 2] = 4 * i + 2;
			array2[6 * i + 3] = 4 * i;
			array2[6 * i + 4] = 4 * i + 2;
			array2[6 * i + 5] = 4 * i + 3;
			zero += new Vector3(info.advance, 0f, 0f);
		}
		mesh.vertices = array;
		mesh.triangles = array2;
		mesh.uv = array3;
		return zero;
	}
}
