using Assets.Sources.Info.Weapon;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class TextureList : MonoBehaviour
{
	public Texture2D[] Textures;

	public Texture2D[] SkinTextures;

	public bool IsDissolve;

	public Texture2D[] GetWeaponEffectTextures()
	{
		return Textures;
	}

	public Texture2D[] GetWeaponTextures(WeaponSkinInfo info)
	{
		if (info != null && info.HasSkinTexture)
		{
			return SkinTextures;
		}
		return Textures;
	}

	public void SetSkinWeaponTextures(Texture2D texture)
	{
		if (SkinTextures == null || SkinTextures.Length == 0)
		{
			SkinTextures = new Texture2D[Textures.Length];
			for (int i = 0; i < SkinTextures.Length; i++)
			{
				SkinTextures[i] = texture;
			}
		}
	}
}
