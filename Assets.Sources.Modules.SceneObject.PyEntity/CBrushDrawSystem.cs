using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;
using physics.data;
using share;

namespace Assets.Sources.Modules.SceneObject.PyEntity;

public class CBrushDrawSystem : IRenderSystem
{
	private readonly IGroup<SceneObjectEntity> _sceneObjects;

	private readonly IGroup<PlayerEntity> _players;

	private static readonly Vector3D[] points = new Vector3D[8];

	private static readonly Vector3D[] points2 = new Vector3D[8];

	private static readonly Vector3[] upoints2 = new Vector3[8];

	public CBrushDrawSystem(Contexts contexts)
	{
		_sceneObjects = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneObjectPyhsics));
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Move, PlayerMatcher.BasicInfo));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity sceneObject in _sceneObjects)
		{
			foreach (CBrush brush2 in sceneObject.sceneObjectPyhsics.Brushs)
			{
				DrawBoundBox(brush2.mins, brush2.maxs, brush2.bmatrix);
			}
		}
		foreach (PlayerEntity player in _players)
		{
			CBrush brush = player.move.getBrush();
			DrawBoundBox(brush.mins, brush.maxs, brush.bmatrix);
		}
	}

	private static void SetAtVectorArray(Vector3D[] array, int idx, double x, double y, double z)
	{
		if (idx < array.Length)
		{
			Vector3D vector3D = array[idx];
			if (vector3D == null)
			{
				vector3D = new Vector3D(x, y, z);
				array[idx] = vector3D;
			}
			else
			{
				vector3D.x = x;
				vector3D.y = y;
				vector3D.z = z;
			}
		}
	}

	public static void DrawBoundBox(Vector3D min, Vector3D max, Matrix3D bmatrix)
	{
		SetAtVectorArray(points, 0, min.x, min.y, min.z);
		SetAtVectorArray(points, 1, max.x, min.y, min.z);
		SetAtVectorArray(points, 2, max.x, max.y, min.z);
		SetAtVectorArray(points, 3, min.x, max.y, min.z);
		SetAtVectorArray(points, 4, min.x, min.y, max.z);
		SetAtVectorArray(points, 5, max.x, min.y, max.z);
		SetAtVectorArray(points, 6, max.x, max.y, max.z);
		SetAtVectorArray(points, 7, min.x, max.y, max.z);
		for (int i = 0; i < 8; i++)
		{
			SetAtVectorArray(points2, i, 0.0, 0.0, 0.0);
			bmatrix.Transform(points[i], points2[i]);
			VectorCoordConverter.GetSsjjToUnity(points2[i], out var x, out var y, out var z);
			upoints2[i] = new Vector3(x, y, z);
		}
		Color red = Color.red;
		Debug.DrawLine(upoints2[0], upoints2[4], red);
		Debug.DrawLine(upoints2[1], upoints2[5], red);
		Debug.DrawLine(upoints2[2], upoints2[6], red);
		Debug.DrawLine(upoints2[3], upoints2[7], red);
		Debug.DrawLine(upoints2[0], upoints2[1], red);
		Debug.DrawLine(upoints2[4], upoints2[5], red);
		Debug.DrawLine(upoints2[3], upoints2[2], red);
		Debug.DrawLine(upoints2[6], upoints2[7], red);
		Debug.DrawLine(upoints2[0], upoints2[3], red);
		Debug.DrawLine(upoints2[1], upoints2[2], red);
		Debug.DrawLine(upoints2[4], upoints2[7], red);
		Debug.DrawLine(upoints2[5], upoints2[6], red);
	}
}
