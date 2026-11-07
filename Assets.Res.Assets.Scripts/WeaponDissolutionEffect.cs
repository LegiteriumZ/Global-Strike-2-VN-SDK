using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class WeaponDissolutionEffect : MonoBehaviour
{
	public int[] visiblestates;

	public bool[] specialModeVisibles;

	public bool[] specialModes;

	public float time;

	public Renderer[] renders;

	public float c_time;

	public int c_index;

	public int n_index = -1;

	public PlayerEntity playerEntity;

	public MaterialPropertyBlock _MaterialPropertyBlock;

	public void Start()
	{
		if (renders.Length != 0)
		{
			_MaterialPropertyBlock = new MaterialPropertyBlock();
			for (int i = 1; i < renders.Length; i++)
			{
				_MaterialPropertyBlock.SetFloat("_WeaponCullAlpha", 1f);
				_MaterialPropertyBlock.SetFloat("_fill", 1f);
				renders[i].SetPropertyBlock(_MaterialPropertyBlock);
			}
			_MaterialPropertyBlock.SetFloat("_WeaponCullAlpha", 1f);
			_MaterialPropertyBlock.SetFloat("_fill", -1f);
			renders[0].SetPropertyBlock(_MaterialPropertyBlock);
			c_index = (n_index = 0);
		}
	}

	public void Update()
	{
		if (renders.Length == 0)
		{
			return;
		}
		if (playerEntity == null)
		{
			n_index = 0;
		}
		else
		{
			for (int i = 0; i < visiblestates.Length; i++)
			{
				if (specialModeVisibles[i])
				{
					if (playerEntity.GetCurrentWeaponSubType() == 2 == specialModes[i])
					{
						n_index = i;
					}
				}
				else if (((1 << visiblestates[i]) & playerEntity.GetCurrentWeaponEffectLevel()) > 0)
				{
					n_index = i;
				}
			}
		}
		if (n_index != c_index)
		{
			c_time += Time.deltaTime;
			float value = ((time != 0f) ? (c_time / time) : 1f);
			_MaterialPropertyBlock.SetFloat("_WeaponCullAlpha", value);
			_MaterialPropertyBlock.SetFloat("_fill", 1f);
			renders[c_index].SetPropertyBlock(_MaterialPropertyBlock);
			_MaterialPropertyBlock.SetFloat("_WeaponCullAlpha", value);
			_MaterialPropertyBlock.SetFloat("_fill", -1f);
			renders[n_index].SetPropertyBlock(_MaterialPropertyBlock);
			if (c_time >= time)
			{
				c_time = 0f;
				c_index = n_index;
			}
		}
	}
}
