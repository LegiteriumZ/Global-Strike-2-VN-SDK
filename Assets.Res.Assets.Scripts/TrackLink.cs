using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class TrackLink : MonoBehaviour
{
	private class TrackMiddlePoint
	{
		public Vector3 start;

		public Vector3 end;

		public float length;

		public TrackMiddlePoint(Vector3 s, Vector3 e, float len)
		{
			start = s;
			end = e;
			length = len;
		}
	}

	private float meshMaxLength = 50f;

	public float singleMeshLength = 50f;

	public float meshHalfWidth = 40f;

	public float interval = 0.02f;

	public Vector3 start;

	public Vector3 end;

	public Vector3 playerForward;

	private float timer;

	private void Start()
	{
		timer = 0f;
	}

	private void Update()
	{
		updateMesh();
	}

	private void updateMesh()
	{
		MeshFilter meshFilter = GetComponent<MeshFilter>();
		if (meshFilter == null)
		{
			meshFilter = base.transform.gameObject.AddComponent<MeshFilter>();
		}
		Mesh mesh = meshFilter.sharedMesh;
		if (mesh == null)
		{
			mesh = (meshFilter.sharedMesh = createMesh());
		}
		updateMeshVertex(mesh);
	}

	private Mesh createMesh()
	{
		return new Mesh();
	}

	private void updateMeshVertex(Mesh mesh)
	{
		mesh.Clear();
		Vector3 vector = base.transform.InverseTransformPoint(start);
		Vector3 vector2 = base.transform.InverseTransformPoint(end);
		Vector3 rhs = vector2 - vector;
		rhs.Normalize();
		Vector3 lhs = new Vector3(0f, 1f, 0f);
		if (Camera.main != null)
		{
			Vector3 position = Camera.main.transform.position;
			position = base.transform.InverseTransformPoint(position);
			lhs = position - vector;
			lhs.Normalize();
		}
		Vector3 vector3 = Vector3.Cross(lhs, rhs);
		vector3.Normalize();
		lhs = Vector3.Cross(vector3, rhs);
		lhs.Normalize();
		Vector3 vector4 = base.transform.InverseTransformDirection(playerForward);
		Vector3 vector5 = vector;
		float num = 0f;
		float num2 = Vector3.Distance(vector, vector2) / 2f;
		List<TrackMiddlePoint> list = new List<TrackMiddlePoint>();
		singleMeshLength = Math.Min(Math.Max(num2 * 2f / 5f, 1f), meshMaxLength);
		float num3;
		while (true)
		{
			num3 = Vector3.Distance(vector5, vector2);
			if (num3 <= singleMeshLength)
			{
				break;
			}
			Vector3 vector6 = vector2 - vector5;
			vector6.Normalize();
			if (num <= num2)
			{
				vector6 /= 5f;
			}
			vector4 += vector6;
			vector4.Normalize();
			Vector3 vector7 = vector5 + vector4 * singleMeshLength;
			list.Add(new TrackMiddlePoint(vector5, vector7, num3));
			vector5 = vector7;
			num += singleMeshLength;
		}
		list.Add(new TrackMiddlePoint(vector5, vector2, num3));
		num += num3;
		List<Vector3> list2 = new List<Vector3>();
		List<Vector2> list3 = new List<Vector2>();
		List<int> list4 = new List<int>();
		int num4 = 0;
		float num5 = 0f;
		for (int i = 0; i < list.Count; i++)
		{
			TrackMiddlePoint trackMiddlePoint = list[i];
			float num6 = num5 + trackMiddlePoint.length / num;
			createMeshForPoints(trackMiddlePoint.start, trackMiddlePoint.end, vector3, lhs, num4, num5, num6, list2, list3, list4);
			num4 += 8;
			num5 = num6;
		}
		mesh.vertices = list2.ToArray();
		mesh.uv = list3.ToArray();
		mesh.triangles = list4.ToArray();
	}

	private void createMeshForPoints(Vector3 start, Vector3 end, Vector3 right, Vector3 up, int vertexOff, float uvStart, float uvEnd, List<Vector3> vertices, List<Vector2> uvs, List<int> triangles)
	{
		Vector3 vector = default(Vector3);
		vector.Set(right.x, right.y, right.z);
		vector *= meshHalfWidth;
		Vector3 item = start - vector;
		Vector3 item2 = start + vector;
		Vector3 item3 = end + vector;
		Vector3 item4 = end - vector;
		vertices.Add(item);
		vertices.Add(item2);
		vertices.Add(item3);
		vertices.Add(item4);
		uvs.Add(new Vector2(uvStart, 0f));
		uvs.Add(new Vector2(uvStart, 1f));
		uvs.Add(new Vector2(uvEnd, 1f));
		uvs.Add(new Vector2(uvEnd, 0f));
		triangles.Add(vertexOff);
		triangles.Add(vertexOff + 2);
		triangles.Add(vertexOff + 1);
		triangles.Add(vertexOff);
		triangles.Add(vertexOff + 3);
		triangles.Add(vertexOff + 2);
		vector.Set(up.x, up.y, up.z);
		vector *= meshHalfWidth;
		item = start - vector;
		item2 = start + vector;
		item3 = end + vector;
		item4 = end - vector;
		vertices.Add(item);
		vertices.Add(item2);
		vertices.Add(item3);
		vertices.Add(item4);
		uvs.Add(new Vector2(uvStart, 0f));
		uvs.Add(new Vector2(uvStart, 1f));
		uvs.Add(new Vector2(uvEnd, 1f));
		uvs.Add(new Vector2(uvEnd, 0f));
		vertexOff += 4;
		triangles.Add(vertexOff);
		triangles.Add(vertexOff + 2);
		triangles.Add(vertexOff + 1);
		triangles.Add(vertexOff);
		triangles.Add(vertexOff + 3);
		triangles.Add(vertexOff + 2);
	}
}
