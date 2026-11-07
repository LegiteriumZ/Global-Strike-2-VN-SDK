using System.Collections.Generic;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PathGuide;

public class PathGuideRender
{
	private static float perUVLen = 100f;

	private static float lineWidth = 100f;

	private static float agreeGap = 10f;

	private static float lineLen;

	private static Vector3 originPos;

	public static void Render(GameObject obj, List<Vector3> paths, Texture texture)
	{
		obj.GetComponent<MeshRenderer>().material.mainTexture = texture;
		MeshFilter component = obj.GetComponent<MeshFilter>();
		Mesh mesh = component.sharedMesh;
		if (mesh == null)
		{
			mesh = new Mesh();
		}
		originPos = VectorCoordConverter.SsjjToUnity(paths[0]);
		mesh = GenerateMesh(mesh, paths);
		component.sharedMesh = mesh;
		obj.transform.position = originPos;
	}

	private static void CreateOtherTriangles(Vector3 cornerPoint, Vector3 leftPoint, Vector3 rightPoint, int dir, ref List<Vector3> vertices, ref List<int> triangles, ref List<Vector2> uvs)
	{
		Vector3 vector = rightPoint - cornerPoint;
		Vector3 vector2 = leftPoint - cornerPoint;
		float num = Vector3.Angle(vector2, vector);
		float num2 = (float)Mathf.CeilToInt(num / agreeGap) * agreeGap;
		Vector3 item = leftPoint;
		float num3 = Mathf.Min(agreeGap, num);
		while (num3 <= num2)
		{
			Vector3 vector3 = Vector3.Slerp(vector2, vector, Mathf.Min(num3 / num, 1f));
			Vector3 vector4 = cornerPoint + vector3;
			int count = vertices.Count;
			vertices.Add(cornerPoint);
			vertices.Add(item);
			vertices.Add(vector4);
			triangles.Add(count);
			if (dir > 0)
			{
				triangles.Add(count + 2);
				triangles.Add(count + 1);
				uvs.Add(new Vector2(lineLen / perUVLen, 1f));
				uvs.Add(new Vector2(lineLen / perUVLen, 0f));
				uvs.Add(new Vector2(lineLen / perUVLen, 0f));
			}
			else
			{
				triangles.Add(count + 1);
				triangles.Add(count + 2);
				uvs.Add(new Vector2(lineLen / perUVLen, 0f));
				uvs.Add(new Vector2(lineLen / perUVLen, 1f));
				uvs.Add(new Vector2(lineLen / perUVLen, 1f));
			}
			num3 += agreeGap;
			item = vector4;
		}
	}

	public static List<Vector3> GetCornerPoints(Vector3 nowPoint, Vector3 leftForward, Vector3 rightForward, Vector3 right, int dir)
	{
		List<Vector3> list = new List<Vector3>();
		leftForward.Normalize();
		rightForward.Normalize();
		Vector3 vector = Vector3.Slerp(-leftForward, rightForward, 0.5f);
		vector.Normalize();
		Vector3 vector2 = nowPoint + vector * lineWidth / 2f;
		Vector3 item = vector2 + right * lineWidth * dir;
		if (dir > 0)
		{
			list.Add(item);
			list.Add(vector2);
		}
		else
		{
			list.Add(vector2);
			list.Add(item);
		}
		return list;
	}

	private static Mesh GenerateMesh(Mesh mesh, List<Vector3> paths)
	{
		List<Vector3> vertices = new List<Vector3>();
		List<int> triangles = new List<int>();
		List<Vector2> uvs = new List<Vector2>();
		Vector3 zero = Vector3.zero;
		Vector3 vector = Vector3.zero;
		Vector3 vector2 = Vector3.zero;
		lineLen = 0f;
		for (int i = 0; i < paths.Count - 1; i++)
		{
			Vector3 vector3 = VectorCoordConverter.SsjjToUnity(paths[i]) - originPos;
			Vector3 vector4 = VectorCoordConverter.SsjjToUnity(paths[i + 1]) - originPos;
			Vector3 vector5 = vector4 - vector3;
			if (Vector3.Magnitude(vector5) < 0.0001f)
			{
				continue;
			}
			vector5.Normalize();
			Vector3 lhs = Vector3.up;
			if (Vector3.Dot(lhs, vector5) > 0.999999f)
			{
				lhs = -Vector3.right;
			}
			else if (Vector3.Dot(lhs, vector5) < -0.999999f)
			{
				lhs = Vector3.right;
			}
			Vector3 vector6 = Vector3.Cross(lhs, vector5);
			vector5.y = 0f;
			vector6.y = 0f;
			vector5.Normalize();
			vector6.Normalize();
			int count = vertices.Count;
			float num = lineLen;
			if (vertices.Count > 0)
			{
				int num2 = -1;
				zero = vertices[vertices.Count - 2];
				if (Mathf.Abs(Vector3.Dot(vector5, vector)) < 0.999999f)
				{
					num2 = 1;
					zero = vertices[vertices.Count - 1];
					if (Vector3.Dot(Vector3.Cross(vector5, vector), Vector3.up) < 0f)
					{
						num2 = -1;
						zero = vertices[vertices.Count - 2];
					}
					List<Vector3> cornerPoints = GetCornerPoints(vector3, vector, vector5, vector2, num2);
					vertices[vertices.Count - 2] = cornerPoints[0];
					vertices[vertices.Count - 1] = cornerPoints[1];
					zero = vertices[vertices.Count - 1];
					if (num2 < 0)
					{
						zero = vertices[vertices.Count - 2];
					}
					CreateOtherTriangles(zero, zero + vector2 * num2 * lineWidth, zero + vector6 * num2 * lineWidth, num2, ref vertices, ref triangles, ref uvs);
				}
				count = vertices.Count;
				if (num2 > 0)
				{
					vertices.Add(zero + vector6 * num2 * lineWidth);
					vertices.Add(zero);
				}
				else
				{
					vertices.Add(zero);
					vertices.Add(zero + vector6 * num2 * lineWidth);
				}
				vertices.Add(vector4 + vector6 * lineWidth * 0.5f);
				vertices.Add(vector4 - vector6 * lineWidth * 0.5f);
			}
			else
			{
				vertices.Add(vector3 + vector6 * lineWidth * 0.5f);
				vertices.Add(vector3 - vector6 * lineWidth * 0.5f);
				vertices.Add(vector4 + vector6 * lineWidth * 0.5f);
				vertices.Add(vector4 - vector6 * lineWidth * 0.5f);
			}
			lineLen += Vector3.Distance(vector3, vector4);
			triangles.Add(count);
			triangles.Add(count + 3);
			triangles.Add(count + 2);
			triangles.Add(count);
			triangles.Add(count + 1);
			triangles.Add(count + 3);
			uvs.Add(new Vector2(num / perUVLen, 0f));
			uvs.Add(new Vector2(num / perUVLen, 1f));
			uvs.Add(new Vector2(lineLen / perUVLen, 0f));
			uvs.Add(new Vector2(lineLen / perUVLen, 1f));
			vector = vector5;
			vector2 = vector6;
		}
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uvs.ToArray();
		mesh.RecalculateNormals();
		return mesh;
	}
}
