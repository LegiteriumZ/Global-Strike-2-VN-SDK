using System;

namespace Assets.Sources.Info.Effect;

public struct TextureKey : IEquatable<TextureKey>
{
	public readonly int ResId;

	public readonly int RuleMode;

	public readonly TextureType Type;

	public readonly string SubName;

	public TextureKey(int resId, int ruleMode, TextureType type, string subName)
	{
		ResId = resId;
		RuleMode = ruleMode;
		Type = type;
		SubName = subName;
	}

	public override string ToString()
	{
		return $"{ResId}_{Type}_{RuleMode}_{SubName}";
	}

	public bool Equals(TextureKey other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == (object)other)
		{
			return true;
		}
		if (ResId == other.ResId && RuleMode == other.RuleMode && Type == other.Type)
		{
			return string.Equals(SubName, other.SubName);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if ((object)this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((TextureKey)obj);
	}

	public override int GetHashCode()
	{
		return (int)(((uint)(((ResId * 397) ^ RuleMode) * 397) ^ (uint)Type) * 397) ^ ((SubName != null) ? SubName.GetHashCode() : 0);
	}
}
