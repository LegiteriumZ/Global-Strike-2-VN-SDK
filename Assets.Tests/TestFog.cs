using System.Linq;
using Assets.Scripts.Fog;
using UnityEngine;

namespace Assets.Tests;

public class TestFog : MonoBehaviour
{
	public SSJJFog.FogConfig[] Fogs;

	private void Start()
	{
	}

	private void Update()
	{
		base.gameObject.GetComponent<SSJJFog>().Fogs = Fogs.ToList();
	}
}
