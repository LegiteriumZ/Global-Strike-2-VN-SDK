using System.Collections.Generic;
using SSJJAnim.Parser;
using SSJJAnim.Player;
using UnityEngine;

namespace Tests.AnimViewer.AnimSource;

public class DefaultAnimSource : IAnimSource
{
	public TextAsset Source { get; set; }

	public AnimSourceType Type { get; set; }

	public SJAnimationAsset Asset { get; set; }

	public List<string> StateNames { get; set; }

	public virtual void Parse(TextAsset source)
	{
		if (source != null)
		{
			StateNames = new List<string>();
			Asset = new SJAnimationAsset();
			Asset.Clips = SJAnimationPaser.GenerateAnimations(source.bytes);
			for (int i = 0; i < Asset.Clips.Count; i++)
			{
				StateNames.Add((Asset.Clips[i] as SJAnimationClip).StateName);
			}
		}
	}
}
