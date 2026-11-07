using System.Collections.Generic;
using SSJJBase.Cache;
using SSJJBase.Manager;
using Sharpen;

namespace Assets.Sources.Info.Effect;

public class EffectConfigFactory : BattleSingletonInstance<EffectConfigFactory>
{
	private readonly Dictionary<TextureType, ObjectCache<int, EffectTextureList>> _effectTexturesInfoCaches = new Dictionary<TextureType, ObjectCache<int, EffectTextureList>>
	{
		{
			TextureType.Effect,
			new ObjectCache<int, EffectTextureList>(null)
		},
		{
			TextureType.Half,
			new ObjectCache<int, EffectTextureList>(null)
		},
		{
			TextureType.Player,
			new ObjectCache<int, EffectTextureList>(null)
		},
		{
			TextureType.Weapon,
			new ObjectCache<int, EffectTextureList>(null)
		}
	};

	public override void Clear()
	{
		foreach (ObjectCache<int, EffectTextureList> value in _effectTexturesInfoCaches.Values)
		{
			value.Clear();
		}
	}

	public EffectTextureList GetEffectTextures(TextureType type, int resId)
	{
		return _effectTexturesInfoCaches[type].GetOrNull(resId);
	}

	public void AddEffectTextures(TextureType type, EffectTextureList texList)
	{
		_effectTexturesInfoCaches[type].Add(texList.ResId, texList);
	}

	public List<EffectTexture> GetAllEffectList(TextureType type)
	{
		List<EffectTexture> list = new AList<EffectTexture>();
		Dictionary<int, EffectTextureList>.Enumerator historyEnumerator = _effectTexturesInfoCaches[type].GetHistoryEnumerator();
		while (historyEnumerator.MoveNext())
		{
			EffectTextureList value = historyEnumerator.Current.Value;
			list.AddRange(value.Values());
		}
		return list;
	}
}
