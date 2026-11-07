using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class TextureDictionary : MonoBehaviour
{
	[SerializeField]
	public List<string> Keys;

	[SerializeField]
	public List<Texture2D> Textures;

	public bool Contains(string key)
	{
		if (Keys != null)
		{
			return Keys.Contains(key);
		}
		return false;
	}

	public Texture2D GetTexture(string key)
	{
		if (Keys != null)
		{
			int num = Keys.IndexOf(key);
			if (num > -1 && num < Textures.Count)
			{
				return Textures[num];
			}
		}
		return null;
	}
}
