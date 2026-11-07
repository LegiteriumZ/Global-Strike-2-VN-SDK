using System;
using System.Collections.Generic;

namespace Assets.Sources.Info.Effect;

public class EffectTextureList
{
	private int _resId;

	private List<EffectTexture> _textures;

	private static Comparison<EffectTexture> _sortComparison;

	public int ResId => _resId;

	public EffectTextureList(int resId, List<EffectTexture> textures)
	{
		_resId = resId;
		_textures = textures;
		_sortComparison = Sort;
	}

	public List<EffectTexture> Values()
	{
		return _textures;
	}

	public Dictionary<TextureKey, List<EffectTexture>> GetTexturesByRuleModel(TextureType type)
	{
		Dictionary<TextureKey, List<EffectTexture>> dictionary = new Dictionary<TextureKey, List<EffectTexture>>();
		for (int i = 0; i < _textures.Count; i++)
		{
			EffectTexture effectTexture = _textures[i];
			if (effectTexture.Type == type)
			{
				TextureKey key = new TextureKey(effectTexture.ResId, effectTexture.RuleModel, effectTexture.Type, effectTexture.SubName);
				if (dictionary.TryGetValue(key, out var value))
				{
					value.Add(effectTexture);
					continue;
				}
				value = new List<EffectTexture> { effectTexture };
				dictionary.Add(key, value);
			}
		}
		foreach (KeyValuePair<TextureKey, List<EffectTexture>> item in dictionary)
		{
			item.Value.Sort(_sortComparison);
		}
		return dictionary;
	}

	private static int Sort(EffectTexture left, EffectTexture right)
	{
		return left.Index - right.Index;
	}
}
