using System;
using System.Collections.Generic;

namespace Assets.Tests.PlayMode;

public abstract class GameTestProperty : Attribute
{
	public List<int> Indexes = new List<int>();

	public abstract bool IsMatch(Type type);

	public abstract T GetValue<T>(int idx, int step) where T : IConvertible;

	public abstract object Get(int idx, Type type, int step);
}
