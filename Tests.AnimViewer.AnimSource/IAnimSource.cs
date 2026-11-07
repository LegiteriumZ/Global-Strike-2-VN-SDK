using System.Collections.Generic;
using SSJJAnim.Parser;
using UnityEngine;

namespace Tests.AnimViewer.AnimSource;

public interface IAnimSource
{
	TextAsset Source { get; set; }

	AnimSourceType Type { get; set; }

	SJAnimationAsset Asset { get; set; }

	List<string> StateNames { get; set; }

	void Parse(TextAsset source);
}
