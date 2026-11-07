using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.Refrenceless;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class RefrencelessHelper : MonoBehaviour
{
	[SerializeField]
	public string DefaultSprite = "0d34dc133a5a6344da29db38e63c1507";

	[SerializeField]
	public List<string> Images = new List<string>();

	[SerializeField]
	public List<string> Sprites = new List<string>();

	[SerializeField]
	public List<string> SpritePaths = new List<string>();

	[SerializeField]
	public List<bool> AutoLoad = new List<bool>();

	private void Start()
	{
	}

	private void Update()
	{
	}
}
