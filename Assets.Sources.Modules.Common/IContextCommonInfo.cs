using System;

namespace Assets.Sources.Modules.Common;

public interface IContextCommonInfo
{
	Type[] ComponentTypes { get; }

	string[] ComponentNames { get; }
}
