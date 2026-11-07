using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace OrbCreationExtensions;

public static class GameObjectExtensions
{
	public static Bounds GetWorldBounds(this GameObject go)
	{
		if (go.transform == null)
		{
			return default(Bounds);
		}
		Bounds result = new Bounds(go.transform.position, Vector3.zero);
		Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>(includeInactive: true);
		if (componentsInChildren != null && componentsInChildren.Length != 0)
		{
			result = componentsInChildren[0].bounds;
		}
		Renderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Bounds bounds = array[i].bounds;
			result.Encapsulate(bounds);
		}
		return result;
	}

	public static Vector3[] GetBoundsCorners(this Bounds bounds)
	{
		Vector3[] array = new Vector3[8];
		for (int i = 0; i < 8; i++)
		{
			array[i] = bounds.min;
			if ((i & 1) > 0)
			{
				array[i].x += bounds.size.x;
			}
			if ((i & 2) > 0)
			{
				array[i].y += bounds.size.y;
			}
			if ((i & 4) > 0)
			{
				array[i].z += bounds.size.z;
			}
		}
		return array;
	}

	public static Vector3[] GetBoundsCenterAndCorners(this Bounds bounds)
	{
		Vector3[] array = new Vector3[9]
		{
			bounds.center,
			default(Vector3),
			default(Vector3),
			default(Vector3),
			default(Vector3),
			default(Vector3),
			default(Vector3),
			default(Vector3),
			default(Vector3)
		};
		for (int i = 1; i < 9; i++)
		{
			array[i] = bounds.min;
			if ((i & 1) > 0)
			{
				array[i].x += bounds.size.x;
			}
			if ((i & 2) > 0)
			{
				array[i].y += bounds.size.y;
			}
			if ((i & 4) > 0)
			{
				array[i].z += bounds.size.z;
			}
		}
		return array;
	}

	public static Vector3[] GetWorldBoundsCorners(this GameObject go)
	{
		return go.GetWorldBounds().GetBoundsCorners();
	}

	public static Vector3[] GetWorldBoundsCenterAndCorners(this GameObject go)
	{
		return go.GetWorldBounds().GetBoundsCenterAndCorners();
	}

	public static float GetModelComplexity(this GameObject go)
	{
		float num = 0f;
		MeshFilter[] componentsInChildren = go.GetComponentsInChildren<MeshFilter>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Mesh sharedMesh = componentsInChildren[i].sharedMesh;
			float num2 = 1f;
			for (int j = 0; j < sharedMesh.subMeshCount; j++)
			{
				num += num2 * (float)sharedMesh.GetTriangles(j).Length / 3f / 65536f;
				num2 *= 1.1f;
			}
		}
		return num;
	}

	public static string GetModelInfoString(this GameObject go)
	{
		string text = "";
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Bounds worldBounds = go.GetWorldBounds();
		MeshFilter[] componentsInChildren = go.GetComponentsInChildren<MeshFilter>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Mesh sharedMesh = componentsInChildren[i].sharedMesh;
			num++;
			num2 += sharedMesh.subMeshCount;
			num3 += sharedMesh.vertices.Length;
			num4 += sharedMesh.triangles.Length / 3;
		}
		text = text + num + " meshes\n";
		text = text + num2 + " submeshes\n";
		text = text + num3 + " vertices\n";
		text = text + num4 + " triangles\n";
		return string.Concat(text, worldBounds.size, " meters");
	}

	public static GameObject TopParent(this GameObject go)
	{
		Transform parent = go.transform.parent;
		if (parent == null)
		{
			return go;
		}
		return parent.gameObject.TopParent();
	}

	public static GameObject FindParentWithName(this GameObject go, string parentName)
	{
		if (go.name == parentName)
		{
			return go;
		}
		Transform parent = go.transform.parent;
		if (parent == null)
		{
			return null;
		}
		return parent.gameObject.FindParentWithName(parentName);
	}

	public static GameObject FindMutualParent(this GameObject go1, GameObject go2)
	{
		if (go2 == null || go1 == go2)
		{
			return null;
		}
		Transform transform = go2.transform;
		while (transform != null)
		{
			if (go1 == transform.gameObject)
			{
				return go1;
			}
			transform = transform.parent;
		}
		Transform parent = go1.transform.parent;
		if (parent == null)
		{
			return null;
		}
		return parent.gameObject.FindMutualParent(go2);
	}

	public static GameObject FindFirstChildWithName(this GameObject go, string childName)
	{
		if (go.name == childName)
		{
			return go;
		}
		foreach (Transform item in go.transform)
		{
			GameObject gameObject = item.gameObject.FindFirstChildWithName(childName);
			if (gameObject != null)
			{
				return gameObject;
			}
		}
		return null;
	}

	public static bool IsChildWithNameUnique(this GameObject go, string childName)
	{
		int total = 0;
		go.CountChildrenWithName(childName, ref total);
		return total <= 1;
	}

	public static void CountChildrenWithName(this GameObject go, string childName, ref int total)
	{
		if (go.name == childName)
		{
			total++;
		}
		foreach (Transform item in go.transform)
		{
			item.gameObject.CountChildrenWithName(childName, ref total);
		}
	}

	public static void DestroyChildren(this GameObject go, bool disabledOnly)
	{
		List<Transform> list = new List<Transform>();
		foreach (Transform item in go.transform)
		{
			if (!item.gameObject.activeSelf || !disabledOnly)
			{
				list.Add(item);
			}
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			list[num].SetParent(null);
			UnityEngine.Object.Destroy(list[num].gameObject);
		}
	}

	public static T GetFirstComponentInParents<T>(this GameObject go) where T : Component
	{
		T component = go.GetComponent<T>();
		if (component != null)
		{
			return component;
		}
		if (go.transform.parent != null && go.transform.parent.gameObject != go)
		{
			return go.transform.parent.gameObject.GetFirstComponentInParents<T>();
		}
		return null;
	}

	public static T GetFirstComponentInChildren<T>(this GameObject go) where T : Component
	{
		T[] componentsInChildren = go.GetComponentsInChildren<T>();
		if (componentsInChildren != null && componentsInChildren.Length != 0)
		{
			return componentsInChildren[0];
		}
		return null;
	}

	public static Mesh[] GetMeshes(this GameObject aGo)
	{
		return aGo.GetMeshes(includeDisabled: true);
	}

	public static Mesh[] GetMeshes(this GameObject aGo, bool includeDisabled)
	{
		MeshFilter[] componentsInChildren = aGo.GetComponentsInChildren<MeshFilter>(includeDisabled);
		SkinnedMeshRenderer[] componentsInChildren2 = aGo.GetComponentsInChildren<SkinnedMeshRenderer>(includeDisabled);
		int num = 0;
		if (componentsInChildren != null)
		{
			num += componentsInChildren.Length;
		}
		if (componentsInChildren2 != null)
		{
			num += componentsInChildren2.Length;
		}
		if (num == 0)
		{
			return null;
		}
		Mesh[] array = new Mesh[num];
		int num2 = 0;
		while (componentsInChildren != null && num2 < componentsInChildren.Length)
		{
			array[num2] = componentsInChildren[num2].sharedMesh;
			num2++;
		}
		int num3 = num2;
		num2 = 0;
		while (componentsInChildren2 != null && num2 < componentsInChildren2.Length)
		{
			array[num2 + num3] = componentsInChildren2[num2].sharedMesh;
			num2++;
		}
		return array;
	}

	public static int GetTotalVertexCount(this GameObject aGo)
	{
		MeshFilter[] componentsInChildren = aGo.GetComponentsInChildren<MeshFilter>(includeInactive: false);
		SkinnedMeshRenderer[] componentsInChildren2 = aGo.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		int num = 0;
		int num2 = 0;
		while (componentsInChildren != null && num2 < componentsInChildren.Length)
		{
			Mesh sharedMesh = componentsInChildren[num2].sharedMesh;
			if (sharedMesh != null)
			{
				num += sharedMesh.vertexCount;
			}
			num2++;
		}
		int num3 = 0;
		while (componentsInChildren2 != null && num3 < componentsInChildren2.Length)
		{
			Mesh sharedMesh2 = componentsInChildren2[num3].sharedMesh;
			if (sharedMesh2 != null)
			{
				num += sharedMesh2.vertexCount;
			}
			num3++;
		}
		return num;
	}

	public static Mesh Get1stSharedMesh(this GameObject aGo)
	{
		MeshFilter[] componentsInChildren = aGo.GetComponentsInChildren<MeshFilter>(includeInactive: false);
		int num = 0;
		while (componentsInChildren != null && num < componentsInChildren.Length)
		{
			if (componentsInChildren[num].sharedMesh != null)
			{
				return componentsInChildren[num].sharedMesh;
			}
			num++;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = aGo.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		int num2 = 0;
		while (componentsInChildren2 != null && num2 < componentsInChildren2.Length)
		{
			if (componentsInChildren2[num2].sharedMesh != null)
			{
				return componentsInChildren2[num2].sharedMesh;
			}
			num2++;
		}
		return null;
	}

	public static void SetMeshes(this GameObject aGo, Mesh[] meshes)
	{
		aGo.SetMeshes(meshes, includeDisabled: true, 0);
	}

	public static void SetMeshes(this GameObject aGo, Mesh[] meshes, int lodLevel)
	{
		aGo.SetMeshes(meshes, includeDisabled: true, lodLevel);
	}

	public static void SetMeshes(this GameObject aGo, Mesh[] meshes, bool includeDisabled, int lodLevel)
	{
		MeshFilter[] componentsInChildren = aGo.GetComponentsInChildren<MeshFilter>(includeDisabled);
		SkinnedMeshRenderer[] componentsInChildren2 = aGo.GetComponentsInChildren<SkinnedMeshRenderer>(includeDisabled);
		int num = 0;
		if (componentsInChildren != null)
		{
			num += componentsInChildren.Length;
		}
		if (componentsInChildren2 != null)
		{
			num += componentsInChildren2.Length;
		}
		if (num == 0)
		{
			return;
		}
		int num2 = 0;
		while (componentsInChildren != null && num2 < componentsInChildren.Length)
		{
			LODSwitcher component = componentsInChildren[num2].gameObject.GetComponent<LODSwitcher>();
			if (meshes != null && meshes.Length > num2)
			{
				if (lodLevel == 0)
				{
					componentsInChildren[num2].sharedMesh = meshes[num2];
				}
				if (component == null && lodLevel > 0)
				{
					component = componentsInChildren[num2].gameObject.AddComponent<LODSwitcher>();
				}
			}
			else if (lodLevel == 0)
			{
				componentsInChildren[num2].sharedMesh = null;
			}
			num2++;
		}
		int num3 = num2;
		num2 = 0;
		while (componentsInChildren2 != null && num2 < componentsInChildren2.Length)
		{
			LODSwitcher component2 = componentsInChildren2[num2].gameObject.GetComponent<LODSwitcher>();
			if (meshes != null && meshes.Length > num2 + num3)
			{
				if (lodLevel == 0)
				{
					componentsInChildren2[num2].sharedMesh = meshes[num2 + num3];
				}
				if (component2 == null && lodLevel > 0)
				{
					component2 = componentsInChildren2[num2].gameObject.AddComponent<LODSwitcher>();
				}
			}
			else if (lodLevel == 0)
			{
				componentsInChildren2[num2].sharedMesh = null;
			}
			num2++;
		}
	}

	public static Material[] GetMaterials(this GameObject aGo, bool includeDisabled)
	{
		List<Material> list = new List<Material>();
		MeshRenderer[] componentsInChildren = aGo.GetComponentsInChildren<MeshRenderer>(includeDisabled);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			list.AddRange(componentsInChildren[i].sharedMaterials);
		}
		SkinnedMeshRenderer[] componentsInChildren2 = aGo.GetComponentsInChildren<SkinnedMeshRenderer>(includeDisabled);
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			list.AddRange(componentsInChildren2[j].sharedMaterials);
		}
		return list.ToArray();
	}

	public static Mesh[] CombineMeshes(this GameObject aGO)
	{
		return aGO.CombineMeshes(new string[0]);
	}

	public static Mesh[] CombineMeshes(this GameObject aGO, string[] skipSubmeshNames, bool makeNewGameObjectWhenRendererPresent = true)
	{
		List<Mesh> list = new List<Mesh>();
		MeshRenderer[] componentsInChildren = aGO.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
		SkinnedMeshRenderer[] componentsInChildren2 = aGO.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = -999;
		bool flag = false;
		if (aGO.GetComponent<SkinnedMeshRenderer>() != null || aGO.GetComponent<MeshRenderer>() != null)
		{
			flag = makeNewGameObjectWhenRendererPresent;
		}
		if (componentsInChildren2 != null && componentsInChildren2.Length != 0)
		{
			SkinnedMeshRenderer[] array = componentsInChildren2;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				if (skinnedMeshRenderer.sharedMesh != null)
				{
					num += skinnedMeshRenderer.sharedMesh.vertexCount;
					num2++;
					num3++;
				}
			}
		}
		if (componentsInChildren != null && componentsInChildren.Length != 0)
		{
			MeshRenderer[] array2 = componentsInChildren;
			foreach (MeshRenderer meshRenderer in array2)
			{
				MeshFilter component = meshRenderer.gameObject.GetComponent<MeshFilter>();
				if (component != null && component.sharedMesh != null)
				{
					if (num4 == -999 && meshRenderer.lightmapIndex >= 0 && meshRenderer.lightmapIndex <= 253)
					{
						num4 = meshRenderer.lightmapIndex;
					}
					if (num4 < 0 || meshRenderer.lightmapIndex < 0 || meshRenderer.lightmapIndex > 253 || num4 == meshRenderer.lightmapIndex)
					{
						num += component.sharedMesh.vertexCount;
						num2++;
					}
				}
				num3++;
			}
		}
		if (num2 == 0)
		{
			throw new ApplicationException("No meshes found in children. There's nothing to combine.");
		}
		if (flag)
		{
			GameObject gameObject = new GameObject();
			string text = aGO.name + "_Merged";
			string name = text;
			int num5 = 0;
			while (GameObject.Find(name) != null)
			{
				name = text + "_" + num5;
				num5++;
			}
			gameObject.name = name;
			gameObject.transform.SetParent(aGO.transform.parent);
			gameObject.transform.localPosition = aGO.transform.localPosition;
			gameObject.transform.localRotation = aGO.transform.localRotation;
			gameObject.transform.localScale = aGO.transform.localScale;
			aGO = gameObject;
		}
		int num6 = 1;
		int num7 = -1;
		int num8 = 0;
		while (num8 < num2 && num7 != num8)
		{
			num7 = num8;
			GameObject gameObject2 = aGO;
			if (num > 65534)
			{
				gameObject2 = new GameObject();
				gameObject2.name = "Merged part " + num6++;
				gameObject2.transform.SetParent(aGO.transform);
				gameObject2.transform.localPosition = Vector3.zero;
				gameObject2.transform.localRotation = Quaternion.identity;
				gameObject2.transform.localScale = Vector3.one;
			}
			Mesh mesh = null;
			List<Vector3> list2 = new List<Vector3>();
			List<Vector3> list3 = new List<Vector3>();
			List<Vector2> list4 = new List<Vector2>();
			List<Vector2> list5 = new List<Vector2>();
			List<Vector2> list6 = new List<Vector2>();
			List<Vector2> list7 = new List<Vector2>();
			List<Color32> list8 = new List<Color32>();
			List<Transform> list9 = new List<Transform>();
			List<Matrix4x4> list10 = new List<Matrix4x4>();
			List<BoneWeight> list11 = new List<BoneWeight>();
			Dictionary<Material, List<int>> dictionary = new Dictionary<Material, List<int>>();
			if (componentsInChildren2 != null && componentsInChildren2.Length != 0)
			{
				bool flag2 = false;
				bool flag3 = false;
				int num9 = 0;
				int num10 = -1;
				int num11 = 0;
				SkinnedMeshRenderer[] array = componentsInChildren2;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in array)
				{
					if (!(skinnedMeshRenderer2.sharedMesh != null))
					{
						continue;
					}
					if (list2.Count + skinnedMeshRenderer2.sharedMesh.vertexCount > 65534)
					{
						flag2 = true;
					}
					if (mesh == null && skinnedMeshRenderer2.sharedMesh.blendShapeCount > 0 && num8 <= num9 && !flag2)
					{
						mesh = UnityEngine.Object.Instantiate(skinnedMeshRenderer2.sharedMesh);
						mesh.uv4 = null;
						mesh.uv3 = null;
						mesh.uv2 = null;
						mesh.uv2 = null;
						mesh.boneWeights = null;
						mesh.colors32 = null;
						mesh.triangles = null;
						mesh.tangents = null;
						mesh.normals = null;
						mesh.vertices = null;
						if (MergeMeshInto(skinnedMeshRenderer2.sharedMesh, skinnedMeshRenderer2.bones, skinnedMeshRenderer2.sharedMaterials, list2, list3, list4, list5, list6, list7, list8, list11, list9, list10, dictionary, skinnedMeshRenderer2.transform.localScale.x * skinnedMeshRenderer2.transform.localScale.y * skinnedMeshRenderer2.transform.localScale.z < 0f, new Vector4(1f, 1f, 0f, 0f), skinnedMeshRenderer2.transform, gameObject2.transform, skinnedMeshRenderer2.gameObject.name + "_" + skinnedMeshRenderer2.sharedMesh.name, skipSubmeshNames) && skinnedMeshRenderer2.gameObject != gameObject2)
						{
							skinnedMeshRenderer2.gameObject.SetActive(value: false);
						}
						num10 = num11;
					}
					num11++;
				}
				array = componentsInChildren2;
				foreach (SkinnedMeshRenderer skinnedMeshRenderer3 in array)
				{
					if (!(skinnedMeshRenderer3.sharedMesh != null))
					{
						continue;
					}
					if (list2.Count + skinnedMeshRenderer3.sharedMesh.vertexCount > 65534)
					{
						flag2 = true;
					}
					if (num8 <= num9 && !flag2)
					{
						if (num9 != num10 && MergeMeshInto(skinnedMeshRenderer3.sharedMesh, skinnedMeshRenderer3.bones, skinnedMeshRenderer3.sharedMaterials, list2, list3, list4, list5, list6, list7, list8, list11, list9, list10, dictionary, skinnedMeshRenderer3.transform.localScale.x * skinnedMeshRenderer3.transform.localScale.y * skinnedMeshRenderer3.transform.localScale.z < 0f, new Vector4(1f, 1f, 0f, 0f), skinnedMeshRenderer3.transform, gameObject2.transform, skinnedMeshRenderer3.gameObject.name + "_" + skinnedMeshRenderer3.sharedMesh.name, skipSubmeshNames) && skinnedMeshRenderer3.gameObject != gameObject2)
						{
							skinnedMeshRenderer3.gameObject.SetActive(value: false);
						}
						flag3 = true;
						num8++;
					}
					num9++;
				}
				if (componentsInChildren != null && componentsInChildren.Length != 0 && flag3)
				{
					MeshRenderer[] array2 = componentsInChildren;
					foreach (MeshRenderer meshRenderer2 in array2)
					{
						MeshFilter component2 = meshRenderer2.gameObject.GetComponent<MeshFilter>();
						if (!(component2 != null) || !(component2.sharedMesh != null) || !(component2.gameObject != gameObject2))
						{
							continue;
						}
						if (list2.Count + component2.sharedMesh.vertexCount > 65534)
						{
							flag2 = true;
						}
						if (num8 <= num9 && !flag2)
						{
							if (MergeMeshInto(component2.sharedMesh, null, meshRenderer2.sharedMaterials, list2, list3, list4, list5, list6, list7, list8, list11, list9, list10, dictionary, component2.transform.localScale.x * component2.transform.localScale.y * component2.transform.localScale.z < 0f, meshRenderer2.lightmapScaleOffset, component2.transform, gameObject2.transform, component2.gameObject.name + "_" + component2.sharedMesh.name, skipSubmeshNames))
							{
								meshRenderer2.enabled = false;
							}
							num8++;
						}
						num9++;
					}
				}
			}
			else if (componentsInChildren != null && componentsInChildren.Length != 0)
			{
				int num12 = 0;
				MeshRenderer[] array2 = componentsInChildren;
				foreach (MeshRenderer meshRenderer3 in array2)
				{
					if (num4 >= 0 && meshRenderer3.lightmapIndex >= 0 && meshRenderer3.lightmapIndex <= 253 && num4 != meshRenderer3.lightmapIndex)
					{
						continue;
					}
					MeshFilter component3 = meshRenderer3.gameObject.GetComponent<MeshFilter>();
					if (!(component3 != null) || !(component3.sharedMesh != null))
					{
						continue;
					}
					if (num8 <= num12 && list2.Count + component3.sharedMesh.vertexCount <= 65534)
					{
						if (MergeMeshInto(component3.sharedMesh, null, meshRenderer3.sharedMaterials, list2, list3, list4, list5, list6, list7, list8, list11, list9, list10, dictionary, component3.transform.localScale.x * component3.transform.localScale.y * component3.transform.localScale.z < 0f, meshRenderer3.lightmapScaleOffset, component3.transform, gameObject2.transform, component3.gameObject.name + "_" + component3.sharedMesh.name, skipSubmeshNames) && component3.gameObject != gameObject2)
						{
							component3.gameObject.SetActive(value: false);
							Transform parent = component3.gameObject.transform.parent;
							if (parent != null && parent.gameObject != gameObject2)
							{
								parent.gameObject.SetActive(value: false);
							}
						}
						num8++;
					}
					num12++;
				}
			}
			LODMaker.RemoveUnusedVertices(list2, list3, list4, list5, list6, list7, list8, list11, dictionary);
			if (mesh == null)
			{
				mesh = new Mesh();
			}
			mesh.vertices = list2.ToArray();
			bool flag4 = false;
			if (list3.Count > 0)
			{
				mesh.normals = list3.ToArray();
			}
			flag4 = false;
			for (int j = 0; j < list4.Count; j++)
			{
				if (list4[j].x != 0f || list4[j].y != 0f)
				{
					flag4 = true;
					break;
				}
			}
			if (flag4)
			{
				mesh.uv = list4.ToArray();
			}
			flag4 = false;
			for (int k = 0; k < list5.Count; k++)
			{
				if (list5[k].x != 0f || list5[k].y != 0f)
				{
					flag4 = true;
					break;
				}
			}
			if (flag4)
			{
				mesh.uv2 = list5.ToArray();
			}
			flag4 = false;
			for (int l = 0; l < list6.Count; l++)
			{
				if (list6[l].x != 0f || list6[l].y != 0f)
				{
					flag4 = true;
					break;
				}
			}
			if (flag4)
			{
				mesh.uv3 = list6.ToArray();
			}
			flag4 = false;
			for (int m = 0; m < list7.Count; m++)
			{
				if (list7[m].x != 0f || list7[m].y != 0f)
				{
					flag4 = true;
					break;
				}
			}
			if (flag4)
			{
				mesh.uv4 = list7.ToArray();
			}
			flag4 = false;
			for (int n = 0; n < list8.Count; n++)
			{
				if (list8[n].r > 0 || list8[n].g > 0 || list8[n].b > 0)
				{
					flag4 = true;
					break;
				}
			}
			if (flag4)
			{
				mesh.colors32 = list8.ToArray();
			}
			if (list10.Count > 0)
			{
				mesh.bindposes = list10.ToArray();
			}
			if (list11.Count > 0)
			{
				if (list11.Count == list2.Count)
				{
					mesh.boneWeights = list11.ToArray();
				}
				else
				{
					Debug.LogWarning("Nr of bone weights not equal to nr of vertices.");
				}
			}
			mesh.subMeshCount = dictionary.Keys.Count;
			Material[] array3 = new Material[dictionary.Keys.Count];
			int num13 = 0;
			using (Dictionary<Material, List<int>>.KeyCollection.Enumerator enumerator = dictionary.Keys.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					mesh.SetTriangles(dictionary[array3[num13] = enumerator.Current].ToArray(), num13++);
				}
			}
			if (list3 == null || list3.Count <= 0)
			{
				mesh.RecalculateNormals();
			}
			mesh.RecalculateTangents();
			mesh.RecalculateBounds();
			if (componentsInChildren2 != null && componentsInChildren2.Length != 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer4 = gameObject2.GetComponent<SkinnedMeshRenderer>();
				if (skinnedMeshRenderer4 == null)
				{
					skinnedMeshRenderer4 = gameObject2.AddComponent<SkinnedMeshRenderer>();
				}
				skinnedMeshRenderer4.quality = componentsInChildren2[0].quality;
				skinnedMeshRenderer4.sharedMesh = mesh;
				skinnedMeshRenderer4.sharedMaterials = array3;
				skinnedMeshRenderer4.bones = list9.ToArray();
			}
			else if (componentsInChildren != null && componentsInChildren.Length != 0)
			{
				MeshRenderer meshRenderer4 = gameObject2.GetComponent<MeshRenderer>();
				if (meshRenderer4 == null)
				{
					meshRenderer4 = gameObject2.AddComponent<MeshRenderer>();
				}
				if (num4 >= 0 && num4 <= 253)
				{
					meshRenderer4.lightmapIndex = num4;
				}
				meshRenderer4.sharedMaterials = array3;
				MeshFilter meshFilter = gameObject2.GetComponent<MeshFilter>();
				if (meshFilter == null)
				{
					meshFilter = gameObject2.AddComponent<MeshFilter>();
				}
				meshFilter.sharedMesh = mesh;
			}
			list.Add(mesh);
		}
		return list.ToArray();
	}

	private static int GiveUniqueNameIfNeeded(GameObject aGo, GameObject topGO, int uniqueId)
	{
		if (topGO.IsChildWithNameUnique(aGo.name))
		{
			return uniqueId;
		}
		aGo.name = aGo.name + "_simpleLod" + ++uniqueId;
		return uniqueId;
	}

	public static void SetUpLODLevels(this GameObject go)
	{
		go.SetUpLODLevels(1f);
	}

	public static void SetUpLODLevels(this GameObject go, float maxWeight)
	{
		go.SetUpLODLevels(new float[3] { 0.6f, 0.3f, 0.15f }, new float[3]
		{
			maxWeight * 0.65f,
			maxWeight,
			maxWeight * 1.5f
		});
	}

	public static void SetUpLODLevels(this GameObject go, float[] lodScreenSizes, float[] maxWeights)
	{
		MeshFilter[] componentsInChildren = go.GetComponentsInChildren<MeshFilter>(includeInactive: false);
		if (componentsInChildren != null && componentsInChildren.Length != 0)
		{
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.SetUpLODLevelsWithLODSwitcher(lodScreenSizes, maxWeights, recalcNormals: true, new float[2] { 1f, 1f });
			}
		}
	}

	public static Mesh[] SetUpLODLevelsWithLODSwitcher(this GameObject go, float[] lodScreenSizes, float[] maxWeights, bool recalcNormals, float[] removeSmallParts, float protectNormals = 1f, float protectUvs = 1f, float protectSubMeshesAndSharpEdges = 1f, float smallTrianglesFirst = 1f, int nrOfSteps = 1)
	{
		Mesh mesh = null;
		LODSwitcher lODSwitcher = go.GetComponent<LODSwitcher>();
		_ = lODSwitcher != null;
		SkinnedMeshRenderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (component != null)
		{
			mesh = component.sharedMesh;
		}
		else if (go.GetComponent<MeshFilter>() != null)
		{
			MeshFilter component2 = go.GetComponent<MeshFilter>();
			if (component2 != null)
			{
				mesh = component2.sharedMesh;
			}
		}
		else if (go.GetComponent<ParticleSystemRenderer>() != null)
		{
			ParticleSystemRenderer component3 = go.GetComponent<ParticleSystemRenderer>();
			if (component3.renderMode == ParticleSystemRenderMode.Mesh)
			{
				mesh = component3.mesh;
			}
		}
		if (mesh == null)
		{
			throw new ApplicationException("No mesh found in " + go.name + ". Maybe you need to select a child object?");
		}
		for (int i = 0; i < maxWeights.Length; i++)
		{
			if (maxWeights[i] <= 0f)
			{
				throw new ApplicationException("MaxWeight should be more that 0 or else this operation will have no effect");
			}
		}
		Mesh[] array = mesh.MakeLODMeshes(maxWeights, recalcNormals, removeSmallParts, protectNormals, protectUvs, protectSubMeshesAndSharpEdges, smallTrianglesFirst, nrOfSteps);
		if (array == null)
		{
			return null;
		}
		if (lODSwitcher == null)
		{
			lODSwitcher = go.AddComponent<LODSwitcher>();
		}
		Array.Resize(ref array, maxWeights.Length + 1);
		for (int num = maxWeights.Length; num > 0; num--)
		{
			array[num] = array[num - 1];
		}
		array[0] = mesh;
		lODSwitcher.lodMeshes = array;
		lODSwitcher.enabled = true;
		return array;
	}

	public static Mesh[] SetUpLODLevelsWithLODSwitcherSelfUpdate(this GameObject go, float[] lodScreenSizes, float[] maxWeights, bool recalcNormals, float[] removeSmallParts, float protectNormals = 1f, float protectUvs = 1f, float protectSubMeshesAndSharpEdges = 1f, float smallTrianglesFirst = 1f, int nrOfSteps = 1)
	{
		Mesh mesh = null;
		LODSwitcherSelf component = go.GetComponent<LODSwitcherSelf>();
		if (component != null)
		{
			component.ReleaseFixedLODLevel();
			component.SetLODLevel(0);
		}
		SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
		if (component2 != null)
		{
			mesh = component2.sharedMesh;
		}
		else if (go.GetComponent<MeshFilter>() != null)
		{
			MeshFilter component3 = go.GetComponent<MeshFilter>();
			if (component3 != null)
			{
				mesh = component3.sharedMesh;
			}
		}
		else if (go.GetComponent<ParticleSystemRenderer>() != null)
		{
			ParticleSystemRenderer component4 = go.GetComponent<ParticleSystemRenderer>();
			if (component4.renderMode == ParticleSystemRenderMode.Mesh)
			{
				mesh = component4.mesh;
			}
		}
		if (mesh == null)
		{
			throw new ApplicationException("No mesh found in " + go.name + ". Maybe you need to select a child object?");
		}
		for (int i = 0; i < maxWeights.Length; i++)
		{
			if (maxWeights[i] <= 0f)
			{
				throw new ApplicationException("MaxWeight should be more that 0 or else this operation will have no effect");
			}
		}
		Mesh[] array = mesh.MakeLODMeshes(maxWeights, recalcNormals, removeSmallParts, protectNormals, protectUvs, protectSubMeshesAndSharpEdges, smallTrianglesFirst, nrOfSteps);
		if (array == null)
		{
			return null;
		}
		if (component == null)
		{
			component = go.AddComponent<LODSwitcherSelf>();
		}
		Array.Resize(ref array, maxWeights.Length + 1);
		for (int num = maxWeights.Length; num > 0; num--)
		{
			array[num] = array[num - 1];
		}
		array[0] = mesh;
		return array;
	}

	public static IEnumerator SetUpLODLevelsWithLODSwitcherInBackground(this GameObject go, float[] lodScreenSizes, float[] maxWeights, bool recalcNormals, float removeSmallParts = 1f, float protectNormals = 1f, float protectUvs = 1f, float protectSubMeshesAndSharpEdges = 1f, float smallTrianglesFirst = 1f)
	{
		yield return null;
		Mesh mesh = null;
		LODSwitcher lodSwitcher = go.GetComponent<LODSwitcher>();
		_ = lodSwitcher != null;
		SkinnedMeshRenderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (component != null)
		{
			mesh = component.sharedMesh;
		}
		else
		{
			MeshFilter component2 = go.GetComponent<MeshFilter>();
			if (component2 != null)
			{
				mesh = component2.sharedMesh;
			}
		}
		if (mesh == null)
		{
			throw new ApplicationException("No mesh found in " + go.name + ". Maybe you need to select a child object?");
		}
		for (int j = 0; j < maxWeights.Length; j++)
		{
			if (maxWeights[j] <= 0f)
			{
				throw new ApplicationException("MaxWeight should be more that 0 or else this operation will have no effect");
			}
		}
		Mesh mesh2 = mesh;
		Mesh[] lodMeshes = new Mesh[maxWeights.Length];
		for (int i = 0; i < maxWeights.Length; i++)
		{
			yield return null;
			Hashtable lodInfo = new Hashtable
			{
				["maxWeight"] = maxWeights[i],
				["removeSmallParts"] = removeSmallParts
			};
			Vector3[] vertices = mesh.vertices;
			if (vertices.Length == 0)
			{
				throw new ApplicationException("Mesh was empty");
			}
			Vector3[] normals = mesh.normals;
			if (normals.Length == 0)
			{
				mesh.RecalculateNormals();
				normals = mesh.normals;
			}
			Vector2[] uv = mesh.uv;
			Vector2[] uv2 = mesh.uv2;
			Vector2[] uv3 = mesh.uv3;
			Vector2[] uv4 = mesh.uv4;
			Color32[] colors = mesh.colors32;
			int[] triangles = mesh.triangles;
			Matrix4x4[] bindposes = mesh.bindposes;
			BoneWeight[] boneWeights = mesh.boneWeights;
			int[] array = new int[mesh.subMeshCount];
			if (mesh.subMeshCount > 1)
			{
				for (int k = 0; k < mesh.subMeshCount; k++)
				{
					int[] triangles2 = mesh.GetTriangles(k);
					int l;
					for (l = 0; l < triangles2.Length; l++)
					{
						triangles[array[k] + l] = triangles2[l];
					}
					if (k + 1 < mesh.subMeshCount)
					{
						array[k + 1] = array[k] + l;
					}
				}
			}
			Bounds bounds = mesh.bounds;
			lodInfo["vertices"] = vertices;
			lodInfo["normals"] = normals;
			lodInfo["uv1s"] = uv;
			lodInfo["uv2s"] = uv2;
			lodInfo["uv3s"] = uv3;
			lodInfo["uv4s"] = uv4;
			lodInfo["colors32"] = colors;
			lodInfo["triangles"] = triangles;
			lodInfo["bindposes"] = bindposes;
			lodInfo["boneWeights"] = boneWeights;
			lodInfo["subMeshOffsets"] = array;
			lodInfo["meshBounds"] = bounds;
			new Thread(LODMaker.MakeLODMeshInBackground).Start(lodInfo);
			while (!lodInfo.ContainsKey("ready"))
			{
				yield return new WaitForSeconds(0.2f);
			}
			lodMeshes[i] = LODMaker.CreateNewMesh((Vector3[])lodInfo["vertices"], (Vector3[])lodInfo["normals"], (Vector2[])lodInfo["uv1s"], (Vector2[])lodInfo["uv2s"], (Vector2[])lodInfo["uv3s"], (Vector2[])lodInfo["uv4s"], (Color32[])lodInfo["colors32"], (int[])lodInfo["triangles"], (BoneWeight[])lodInfo["boneWeights"], (Matrix4x4[])lodInfo["bindposes"], (int[])lodInfo["subMeshOffsets"], recalcNormals);
			mesh = lodMeshes[i];
			go.transform.parent.gameObject.BroadcastMessage("LOD" + (i + 1) + "IsReady", go, SendMessageOptions.DontRequireReceiver);
		}
		yield return null;
		if (lodMeshes != null)
		{
			if (lodSwitcher == null)
			{
				lodSwitcher = go.AddComponent<LODSwitcher>();
			}
			Array.Resize(ref lodMeshes, maxWeights.Length + 1);
			for (int num = maxWeights.Length; num > 0; num--)
			{
				lodMeshes[num] = lodMeshes[num - 1];
			}
			lodMeshes[0] = mesh2;
			lodSwitcher.lodMeshes = lodMeshes;
			lodSwitcher.enabled = true;
		}
		go.transform.parent.gameObject.BroadcastMessage("LODsAreReady", go, SendMessageOptions.DontRequireReceiver);
	}

	public static Mesh[] SetUpLODLevelsAndChildrenWithLODSwitcher(this GameObject go, float[] lodScreenSizes, float[] maxWeights, bool recalcNormals, float[] removeSmallParts, float protectNormals = 1f, float protectUvs = 1f, float protectSubMeshesAndSharpEdges = 1f, float smallTrianglesFirst = 1f, int nrOfSteps = 1)
	{
		Mesh mesh = null;
		Material[] array = null;
		LODSwitcher lODSwitcher = go.GetComponent<LODSwitcher>();
		_ = lODSwitcher != null;
		SkinnedMeshRenderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (component != null)
		{
			mesh = component.sharedMesh;
			array = component.sharedMaterials;
			component.enabled = false;
		}
		else
		{
			MeshFilter component2 = go.GetComponent<MeshFilter>();
			if (component2 != null)
			{
				mesh = component2.sharedMesh;
			}
			MeshRenderer component3 = go.GetComponent<MeshRenderer>();
			if (component3 == null)
			{
				throw new ApplicationException("No MeshRenderer found");
			}
			array = component3.sharedMaterials;
			component3.enabled = false;
		}
		if (mesh == null)
		{
			throw new ApplicationException("No mesh found in " + go.name + ". Maybe you need to select a child object?");
		}
		for (int i = 0; i < maxWeights.Length; i++)
		{
			if (maxWeights[i] <= 0f)
			{
				throw new ApplicationException("MaxWeight should be more that 0 or else this operation will have no effect");
			}
		}
		Mesh[] array2 = mesh.MakeLODMeshes(maxWeights, recalcNormals, removeSmallParts, protectNormals, protectUvs, protectSubMeshesAndSharpEdges, smallTrianglesFirst, nrOfSteps);
		if (array2 == null)
		{
			return null;
		}
		Mesh[] array3 = new Mesh[array2.Length + 1];
		array3[0] = mesh;
		for (int j = 0; j < array2.Length; j++)
		{
			array3[j + 1] = array2[j];
		}
		if (lODSwitcher == null)
		{
			lODSwitcher = go.AddComponent<LODSwitcher>();
		}
		GameObject[] array4 = new GameObject[array3.Length];
		for (int k = 0; k < array3.Length; k++)
		{
			Transform transform = go.transform.FindFirstChildWithName(go.name + "_LOD" + k);
			if (transform != null)
			{
				array4[k] = transform.gameObject;
				array4[k].SetActive(value: true);
			}
			if (array4[k] == null)
			{
				array4[k] = new GameObject(go.name + "_LOD" + k);
				array4[k].transform.SetParent(go.transform);
				array4[k].transform.localPosition = Vector3.zero;
				array4[k].transform.localRotation = Quaternion.identity;
				array4[k].transform.localScale = Vector3.one;
			}
			if (component != null)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array4[k].GetComponent<SkinnedMeshRenderer>();
				if (skinnedMeshRenderer == null)
				{
					skinnedMeshRenderer = array4[k].AddComponent<SkinnedMeshRenderer>();
				}
				skinnedMeshRenderer.sharedMesh = array3[k];
				skinnedMeshRenderer.sharedMaterials = array;
			}
			else
			{
				MeshFilter meshFilter = array4[k].GetComponent<MeshFilter>();
				if (meshFilter == null)
				{
					meshFilter = array4[k].AddComponent<MeshFilter>();
				}
				meshFilter.sharedMesh = array3[k];
				MeshRenderer meshRenderer = array4[k].GetComponent<MeshRenderer>();
				if (meshRenderer == null)
				{
					meshRenderer = array4[k].AddComponent<MeshRenderer>();
				}
				meshRenderer.sharedMaterials = array;
			}
			array4[k].SetActive(k == 0);
		}
		lODSwitcher.enabled = true;
		return array3;
	}

	public static Mesh[] SetUpLODLevelsAndChildrenWithLODGroup(this GameObject go, float[] relativeTransitionHeights, float[] maxWeights, bool recalcNormals, float removeSmallParts, float protectNormals = 1f, float protectUvs = 1f, float protectSubMeshesAndSharpEdges = 1f, float smallTrianglesFirst = 1f, int nrOfSteps = 1)
	{
		GameObject gameObject = null;
		LODGroup lODGroup = null;
		if (relativeTransitionHeights.Length < 0 || relativeTransitionHeights.Length != maxWeights.Length)
		{
			throw new ApplicationException("relativeTransitionHeights and maxWeights arrays need to have equal length and be longer than 0. Example: SetUpLODLevelsWithLODGroup(go, new float[2] {0.6f, 0.4f}, new float[2] {1f, 1.75f})");
		}
		for (int i = 0; i < maxWeights.Length; i++)
		{
			if (maxWeights[i] <= 0f)
			{
				throw new ApplicationException("MaxWeight should be more that 0 or else this operation will have no effect");
			}
		}
		gameObject = new GameObject(go.name + "_$LodGrp");
		gameObject.transform.position = go.transform.position;
		gameObject.transform.rotation = go.transform.rotation;
		gameObject.transform.localScale = go.transform.localScale;
		go.transform.SetParent(gameObject.transform);
		if (lODGroup == null)
		{
			lODGroup = gameObject.AddComponent<LODGroup>();
		}
		else
		{
			Transform transform = gameObject.transform.FindFirstChildWhereNameContains(go.name + "_$Lod:");
			int num = 0;
			while (transform != null && num++ < 10)
			{
				transform.SetParent(null);
				UnityEngine.Object.Destroy(transform.gameObject);
				transform = gameObject.transform.FindFirstChildWhereNameContains(go.name + "_$Lod:");
			}
		}
		LOD[] array = new LOD[maxWeights.Length + 1];
		float screenRelativeTransitionHeight = relativeTransitionHeights[0];
		Renderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
		array[0] = new LOD(screenRelativeTransitionHeight, componentsInChildren);
		List<Mesh> list = new List<Mesh>();
		Mesh[] array2 = go.GetMeshes(includeDisabled: false);
		float num2 = 0f;
		for (int j = 1; j < array.Length; j++)
		{
			Mesh[] array3 = new Mesh[array2.Length];
			for (int k = 0; k < array2.Length; k++)
			{
				Mesh mesh = array2[k];
				if (nrOfSteps < 1)
				{
					nrOfSteps = 1;
				}
				for (int l = 0; l < nrOfSteps; l++)
				{
					float num3 = maxWeights[j - 1] - num2;
					mesh = mesh.MakeLODMesh((float)(l + 1) * (num3 / (float)nrOfSteps) + num2, recalcNormals, removeSmallParts, protectNormals, protectUvs, protectSubMeshesAndSharpEdges, smallTrianglesFirst);
				}
				num2 = maxWeights[j - 1];
				array3[k] = mesh;
				mesh.name = go.name + "_" + k + "_LOD" + j;
				list.Add(mesh);
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate(go);
			gameObject2.name = go.name + "_$Lod:" + j;
			gameObject2.transform.SetParent(gameObject.transform);
			gameObject2.transform.localPosition = go.transform.localPosition;
			gameObject2.transform.localRotation = go.transform.localRotation;
			gameObject2.transform.localScale = go.transform.localScale;
			gameObject2.SetMeshes(array3);
			float screenRelativeTransitionHeight2 = ((j < relativeTransitionHeights.Length) ? relativeTransitionHeights[j] : 0f);
			int num4 = j;
			componentsInChildren = gameObject2.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
			array[num4] = new LOD(screenRelativeTransitionHeight2, componentsInChildren);
			array2 = array3;
		}
		lODGroup.SetLODS(array);
		lODGroup.RecalculateBounds();
		lODGroup.ForceLOD(-1);
		return list.ToArray();
	}

	public static Mesh GetSimplifiedMesh(this GameObject go, float maxWeight, bool recalcNormals, float removeSmallParts, float protectNormals = 1f, float protectUvs = 1f, float protectSubMeshesAndSharpEdges = 1f, float smallTrianglesFirst = 1f, int nrOfSteps = 1)
	{
		Mesh mesh = null;
		_ = go.GetComponent<LODSwitcher>() != null;
		MeshFilter meshFilter = null;
		SkinnedMeshRenderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (maxWeight <= 0f)
		{
			throw new ApplicationException("MaxWeight should be more that 0 or else this operation will have no effect");
		}
		if (component != null)
		{
			mesh = component.sharedMesh;
		}
		else
		{
			meshFilter = go.GetComponent<MeshFilter>();
			if (meshFilter != null)
			{
				mesh = meshFilter.sharedMesh;
			}
		}
		if (mesh == null)
		{
			throw new ApplicationException("No mesh found. Maybe you need to select a child object?");
		}
		Mesh mesh2 = mesh;
		if (nrOfSteps < 1)
		{
			nrOfSteps = 1;
		}
		for (int i = 0; i < nrOfSteps; i++)
		{
			mesh2 = mesh2.MakeLODMesh((float)(i + 1) * (maxWeight / (float)nrOfSteps), recalcNormals, removeSmallParts, protectNormals, protectUvs, protectSubMeshesAndSharpEdges, smallTrianglesFirst);
		}
		if (component != null)
		{
			component.sharedMesh = mesh2;
		}
		else if (meshFilter != null)
		{
			meshFilter.sharedMesh = mesh2;
		}
		return mesh2;
	}

	public static IEnumerator GetSimplifiedMeshInBackground(this GameObject go, float maxWeight, bool recalcNormals, float removeSmallParts, Action<Mesh> result)
	{
		Mesh mesh = null;
		_ = go.GetComponent<LODSwitcher>() != null;
		SkinnedMeshRenderer component = go.GetComponent<SkinnedMeshRenderer>();
		if (maxWeight <= 0f)
		{
			throw new ApplicationException("MaxWeight should be more that 0 or else this operation will have no effect");
		}
		if (component != null)
		{
			mesh = component.sharedMesh;
		}
		else
		{
			MeshFilter component2 = go.GetComponent<MeshFilter>();
			if (component2 != null)
			{
				mesh = component2.sharedMesh;
			}
		}
		if (mesh == null)
		{
			throw new ApplicationException("No mesh found. Maybe you need to select a child object?");
		}
		Hashtable lodInfo = new Hashtable
		{
			["maxWeight"] = maxWeight,
			["removeSmallParts"] = removeSmallParts
		};
		Vector3[] vertices = mesh.vertices;
		if (vertices.Length == 0)
		{
			throw new ApplicationException("Mesh was empty");
		}
		Vector3[] normals = mesh.normals;
		if (normals.Length == 0)
		{
			mesh.RecalculateNormals();
			normals = mesh.normals;
		}
		Vector2[] uv = mesh.uv;
		Vector2[] uv2 = mesh.uv2;
		Vector2[] uv3 = mesh.uv3;
		Vector2[] uv4 = mesh.uv4;
		Color32[] colors = mesh.colors32;
		int[] triangles = mesh.triangles;
		Matrix4x4[] bindposes = mesh.bindposes;
		BoneWeight[] boneWeights = mesh.boneWeights;
		int[] array = new int[mesh.subMeshCount];
		if (mesh.subMeshCount > 1)
		{
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				int[] triangles2 = mesh.GetTriangles(i);
				int j;
				for (j = 0; j < triangles2.Length; j++)
				{
					triangles[array[i] + j] = triangles2[j];
				}
				if (i + 1 < mesh.subMeshCount)
				{
					array[i + 1] = array[i] + j;
				}
			}
		}
		Bounds bounds = mesh.bounds;
		lodInfo["vertices"] = vertices;
		lodInfo["normals"] = normals;
		lodInfo["uv1s"] = uv;
		lodInfo["uv2s"] = uv2;
		lodInfo["uv3s"] = uv3;
		lodInfo["uv4s"] = uv4;
		lodInfo["colors32"] = colors;
		lodInfo["triangles"] = triangles;
		lodInfo["bindposes"] = bindposes;
		lodInfo["boneWeights"] = boneWeights;
		lodInfo["subMeshOffsets"] = array;
		lodInfo["meshBounds"] = bounds;
		new Thread(LODMaker.MakeLODMeshInBackground).Start(lodInfo);
		while (!lodInfo.ContainsKey("ready"))
		{
			yield return new WaitForSeconds(0.2f);
		}
		result(LODMaker.CreateNewMesh((Vector3[])lodInfo["vertices"], (Vector3[])lodInfo["normals"], (Vector2[])lodInfo["uv1s"], (Vector2[])lodInfo["uv2s"], (Vector2[])lodInfo["uv3s"], (Vector2[])lodInfo["uv4s"], (Color32[])lodInfo["colors32"], (int[])lodInfo["triangles"], (BoneWeight[])lodInfo["boneWeights"], (Matrix4x4[])lodInfo["bindposes"], (int[])lodInfo["subMeshOffsets"], recalcNormals));
	}

	private static bool MergeMeshInto(Mesh fromMesh, Transform[] fromBones, Material[] fromMaterials, List<Vector3> vertices, List<Vector3> normals, List<Vector2> uv1s, List<Vector2> uv2s, List<Vector2> uv3s, List<Vector2> uv4s, List<Color32> colors32, List<BoneWeight> boneWeights, List<Transform> bones, List<Matrix4x4> bindposes, Dictionary<Material, List<int>> subMeshes, bool usesNegativeScale, Vector4 lightmapScaleOffset, Transform fromTransform, Transform topTransform, string submeshName, string[] skipSubmeshNames)
	{
		if (fromMesh == null)
		{
			return false;
		}
		bool result = true;
		int count = vertices.Count;
		Vector3[] vertices2 = fromMesh.vertices;
		Vector3[] normals2 = fromMesh.normals;
		Vector2[] array = fromMesh.uv;
		Vector2[] array2 = fromMesh.uv2;
		Vector2[] array3 = fromMesh.uv3;
		Vector2[] array4 = fromMesh.uv4;
		Color32[] array5 = fromMesh.colors32;
		BoneWeight[] array6 = fromMesh.boneWeights;
		Matrix4x4[] array7 = fromMesh.bindposes;
		List<int> list = new List<int>();
		Vector3 localPosition = fromTransform.localPosition;
		Quaternion localRotation = fromTransform.localRotation;
		Vector3 localScale = fromTransform.localScale;
		bool flag = false;
		if (fromBones != null)
		{
			fromTransform.localPosition = Vector3.zero;
			fromTransform.localRotation = Quaternion.identity;
			fromTransform.localScale = Vector3.one;
		}
		if (fromBones == null || fromBones.Length == 0)
		{
			flag = true;
		}
		if ((fromBones == null || fromBones.Length == 0) && bones != null && bones.Count > 0)
		{
			fromBones = new Transform[1] { fromTransform };
			Matrix4x4 matrix4x = fromTransform.worldToLocalMatrix * topTransform.localToWorldMatrix;
			array7 = new Matrix4x4[1] { matrix4x };
			array6 = new BoneWeight[vertices2.Length];
			for (int i = 0; i < vertices2.Length; i++)
			{
				array6[i].boneIndex0 = 0;
				array6[i].weight0 = 1f;
			}
		}
		if (fromBones != null)
		{
			bool flag2 = false;
			for (int j = 0; j < fromBones.Length; j++)
			{
				int k = 0;
				list.Add(j);
				for (; k < bones.Count; k++)
				{
					if (!(fromBones[j] == bones[k]))
					{
						continue;
					}
					list[j] = k;
					if (array7[j] != bindposes[k])
					{
						flag2 = true;
						if (fromBones[j] != null)
						{
							Debug.Log(fromTransform.gameObject.name + ": The bindpose of " + fromBones[j].gameObject.name + " is different, vertices will be moved to match the bindpose of the merged mesh");
						}
						else
						{
							Debug.LogError(fromTransform.gameObject.name + ": There is an error in the bonestructure. A bone could not be found.");
						}
					}
				}
				if (k >= bones.Count)
				{
					list[j] = bones.Count;
					bones.Add(fromBones[j]);
					bindposes.Add(array7[j]);
				}
			}
			if (flag2)
			{
				for (int l = 0; l < vertices2.Length; l++)
				{
					Vector3 vector = vertices2[l];
					BoneWeight boneWeight = array6[l];
					if (fromBones[boneWeight.boneIndex0] != null)
					{
						vector = ApplyBindPose(vertices2[l], fromBones[boneWeight.boneIndex0], array7[boneWeight.boneIndex0], boneWeight.weight0);
						if (boneWeight.weight1 > 0f)
						{
							vector += ApplyBindPose(vertices2[l], fromBones[boneWeight.boneIndex1], array7[boneWeight.boneIndex1], boneWeight.weight1);
						}
						if (boneWeight.weight2 > 0f)
						{
							vector += ApplyBindPose(vertices2[l], fromBones[boneWeight.boneIndex2], array7[boneWeight.boneIndex2], boneWeight.weight2);
						}
						if (boneWeight.weight3 > 0f)
						{
							vector += ApplyBindPose(vertices2[l], fromBones[boneWeight.boneIndex3], array7[boneWeight.boneIndex3], boneWeight.weight3);
						}
						Vector3 vertex = vector;
						vector = UnApplyBindPose(vertex, bones[list[boneWeight.boneIndex0]], bindposes[list[boneWeight.boneIndex0]], boneWeight.weight0);
						if (boneWeight.weight1 > 0f)
						{
							vector += UnApplyBindPose(vertex, bones[list[boneWeight.boneIndex1]], bindposes[list[boneWeight.boneIndex1]], boneWeight.weight1);
						}
						if (boneWeight.weight2 > 0f)
						{
							vector += UnApplyBindPose(vertex, bones[list[boneWeight.boneIndex2]], bindposes[list[boneWeight.boneIndex2]], boneWeight.weight2);
						}
						if (boneWeight.weight3 > 0f)
						{
							vector += UnApplyBindPose(vertex, bones[list[boneWeight.boneIndex3]], bindposes[list[boneWeight.boneIndex3]], boneWeight.weight3);
						}
						vertices2[l] = vector;
					}
				}
			}
		}
		if (boneWeights != null && array6 != null && array6.Length != 0)
		{
			for (int m = 0; m < array6.Length; m++)
			{
				BoneWeight item = default(BoneWeight);
				item.boneIndex0 = list[array6[m].boneIndex0];
				item.boneIndex1 = list[array6[m].boneIndex1];
				item.boneIndex2 = list[array6[m].boneIndex2];
				item.boneIndex3 = list[array6[m].boneIndex3];
				item.weight0 = array6[m].weight0;
				item.weight1 = array6[m].weight1;
				item.weight2 = array6[m].weight2;
				item.weight3 = array6[m].weight3;
				boneWeights.Add(item);
			}
		}
		Matrix4x4 matrix4x2 = topTransform.worldToLocalMatrix * fromTransform.localToWorldMatrix;
		if (flag)
		{
			for (int n = 0; n < vertices2.Length; n++)
			{
				Vector3 point = vertices2[n];
				vertices2[n] = matrix4x2.MultiplyPoint3x4(point);
			}
		}
		vertices.AddRange(vertices2);
		Quaternion quaternion = Quaternion.LookRotation(matrix4x2.GetColumn(2), matrix4x2.GetColumn(1));
		if (normals2 != null && normals2.Length != 0)
		{
			for (int num = 0; num < normals2.Length; num++)
			{
				normals2[num] = quaternion * normals2[num];
			}
			normals.AddRange(normals2);
		}
		if (array == null || array.Length != vertices2.Length)
		{
			array = new Vector2[vertices2.Length];
		}
		if (array != null && array.Length != 0)
		{
			uv1s.AddRange(array);
		}
		if (array2 == null || array2.Length != vertices2.Length)
		{
			array2 = new Vector2[vertices2.Length];
		}
		int num2 = 0;
		while (array2 != null && num2 < array2.Length)
		{
			uv2s.Add(new Vector2(lightmapScaleOffset.z + array2[num2].x * lightmapScaleOffset.x, lightmapScaleOffset.w + array2[num2].y * lightmapScaleOffset.y));
			num2++;
		}
		if (array3 == null || array3.Length != vertices2.Length)
		{
			array3 = new Vector2[vertices2.Length];
		}
		if (array3 != null && array3.Length != 0)
		{
			uv3s.AddRange(array3);
		}
		if (array4 == null || array4.Length != vertices2.Length)
		{
			array4 = new Vector2[vertices2.Length];
		}
		if (array4 != null && array4.Length != 0)
		{
			uv4s.AddRange(array3);
		}
		if (array5 == null || array5.Length != vertices2.Length)
		{
			array5 = new Color32[vertices2.Length];
		}
		if (array5 != null && array5.Length != 0)
		{
			colors32.AddRange(array5);
		}
		int num3 = 0;
		for (int num4 = 0; num4 < fromMaterials.Length; num4++)
		{
			if (num4 >= fromMesh.subMeshCount)
			{
				continue;
			}
			string text = submeshName + "_" + num4;
			int num5;
			for (num5 = 0; num5 < skipSubmeshNames.Length && !(text == skipSubmeshNames[num5]); num5++)
			{
			}
			if (num5 >= skipSubmeshNames.Length)
			{
				int[] triangles = fromMesh.GetTriangles(num4);
				if (triangles.Length == 0)
				{
					continue;
				}
				if (fromMaterials[num4] != null && !subMeshes.ContainsKey(fromMaterials[num4]))
				{
					subMeshes.Add(fromMaterials[num4], new List<int>());
				}
				List<int> list2 = subMeshes[fromMaterials[num4]];
				for (int num6 = 0; num6 < triangles.Length; num6 += 3)
				{
					if (usesNegativeScale)
					{
						int num7 = triangles[num6 + 1];
						int num8 = triangles[num6 + 2];
						triangles[num6 + 1] = num8;
						triangles[num6 + 2] = num7;
						num3++;
					}
					triangles[num6] += count;
					triangles[num6 + 1] += count;
					triangles[num6 + 2] += count;
				}
				list2.AddRange(triangles);
			}
			else
			{
				result = false;
			}
		}
		if (fromBones != null)
		{
			fromTransform.localPosition = localPosition;
			fromTransform.localRotation = localRotation;
			fromTransform.localScale = localScale;
		}
		return result;
	}

	private static Vector3 ApplyBindPose(Vector3 vertex, Transform bone, Matrix4x4 bindpose, float boneWeight)
	{
		Matrix4x4 matrix4x = bone.localToWorldMatrix * bindpose;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				matrix4x[i, j] *= boneWeight;
			}
		}
		return matrix4x.MultiplyPoint3x4(vertex);
	}

	private static Vector3 UnApplyBindPose(Vector3 vertex, Transform bone, Matrix4x4 bindpose, float boneWeight)
	{
		Matrix4x4 inverse = (bone.localToWorldMatrix * bindpose).inverse;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				inverse[i, j] *= boneWeight;
			}
		}
		return inverse.MultiplyPoint3x4(vertex);
	}
}
