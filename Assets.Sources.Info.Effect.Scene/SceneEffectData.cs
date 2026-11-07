using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public class SceneEffectData
{
	public string EffectType;

	public string EffectName;

	public string ModelName;

	public int RotationSpeed;

	public int Time;

	public Vector3 RotationNormal;

	public int SetDepthTest;

	public Vector3 Position;

	public Vector3 Rotation;

	public Vector3 Pos0;

	public Vector3 Pos1;

	public Vector3 Pos2;

	public Vector3 Pos3;

	public Vector3 EnvBoxMin;

	public Vector3 EnvBoxMax;

	public Vector3 EnvBoxPos;

	public float Scale = 1f;

	public int MustShow;

	public int VertexCount;

	public Vector3[] VertexData;

	public Vector3[] NormalData;

	public int UvCount;

	public Vector2[] UvData;

	public int IndexCount;

	public int[] IndexData;

	public Vector3 ReflectionProbeBoundMin;

	public Vector3 ReflectionProbeBoundMax;

	public float Alpha;

	public int Cull;

	public string SceneEventID;

	public string SoundName;

	public int Radius;
}
