using System;
using System.Xml;
using SSJJAsset.AssetLoader.Xml;
using UnityEngine;

namespace Assets.Sources.Info.Accessory;

public class BackWeaponXmlConfig : AbstractXmlAsset
{
	public Matrix4x4 FemaleConfig;

	public Matrix4x4 MaleConfig;

	public static Matrix4x4 Compose(float x, float y, float z, float rotationX, float rotationY, float rotationZ, float scaleX, float scaleY, float scaleZ)
	{
		Matrix4x4 result = default(Matrix4x4);
		float num = Mathf.Cos((float)Math.PI / 180f * rotationX);
		float num2 = Mathf.Sin((float)Math.PI / 180f * rotationX);
		float num3 = Mathf.Cos((float)Math.PI / 180f * rotationY);
		float num4 = Mathf.Sin((float)Math.PI / 180f * rotationY);
		float num5 = Mathf.Cos((float)Math.PI / 180f * rotationZ);
		float num6 = Mathf.Sin((float)Math.PI / 180f * rotationZ);
		float num7 = num5 * num4;
		float num8 = num6 * num4;
		float num9 = num3 * scaleX;
		float num10 = num2 * scaleY;
		float num11 = num * scaleY;
		float num12 = num * scaleZ;
		float num13 = num2 * scaleZ;
		result.m00 = num5 * num9;
		result.m01 = num7 * num10 - num6 * num11;
		result.m02 = num7 * num12 + num6 * num13;
		result.m03 = x;
		result.m10 = num6 * num9;
		result.m11 = num8 * num10 + num5 * num11;
		result.m12 = num8 * num12 - num5 * num13;
		result.m13 = y;
		result.m20 = (0f - num4) * scaleX;
		result.m21 = num3 * num10;
		result.m22 = num3 * num12;
		result.m23 = z;
		result.m30 = 0f;
		result.m31 = 0f;
		result.m32 = 0f;
		result.m33 = 1f;
		return result;
	}

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement == null)
		{
			return;
		}
		foreach (XmlNode item in documentElement)
		{
			if (item.Name.Equals("matrix"))
			{
				string value = item.Attributes["name"].Value;
				string[] array = item.FirstChild.Value.Split(' ');
				float[] array2 = new float[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = float.Parse(array[i]);
				}
				if (value.Equals("woman"))
				{
					FemaleConfig = GetBackWeaponTransform(array2);
				}
				else if (value.Equals("man"))
				{
					MaleConfig = GetBackWeaponTransform(array2);
				}
			}
		}
	}

	public static Matrix4x4 GetBackWeaponTransform(float[] mat)
	{
		for (int i = 3; i < 6; i++)
		{
			while (mat[i] < -180f)
			{
				mat[i] += 360f;
			}
			while (mat[i] > 180f)
			{
				mat[i] -= 360f;
			}
		}
		for (int j = 6; j < 9; j++)
		{
			if (mat[j] > 10f)
			{
				mat[j] /= 100f;
			}
		}
		return Compose(0f - mat[0], mat[1], mat[2], mat[3], 0f - mat[4], 0f - mat[5], mat[6], mat[7], mat[8]);
	}
}
