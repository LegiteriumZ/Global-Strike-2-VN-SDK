using System;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class WallBloodEffect : MonoBehaviour
{
	public Texture2D[] Textures;

	private System.Random random = new System.Random();

	private Material material;

	public Mesh mesh;

	private MeshRenderer meshRenderer;

	private MeshFilter meshFilter;

	private void Awake()
	{
	}

	private void Update()
	{
		meshFilter.mesh = mesh;
	}

	private void OnEnable()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		meshFilter = GetComponent<MeshFilter>();
		material = meshRenderer.material;
		meshFilter.mesh = (mesh = null);
		int num = random.Next() % Textures.Length;
		material.mainTexture = Textures[num];
	}
}
